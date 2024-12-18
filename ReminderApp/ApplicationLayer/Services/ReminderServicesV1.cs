using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Interface;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReminderApp.InfrastructureLayer.Context;
using ReminderApp.InfrastructureLayer.Repository;
using ReminderApp.ApplicationLayer.Enum;
using ReminderApp.Service;
using System.Windows.Forms;
using ReminderApp.Infrastructure.Helper;



namespace ReminderApp.ApplicationLayer.Service
{
    public class ReminderServiceV1
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _reminderTasks = new ConcurrentDictionary<int, CancellationTokenSource>();
        private readonly NotificationHelper _notificationHelper;

        public ReminderServiceV1()
        {
            _reminderRepository = new ReminderRepository(new RminderAppDbContext());
            _notificationHelper = new NotificationHelper();

            LoadRemindersFromDatabaseAsync().Wait();
          
        }

        private async Task LoadRemindersFromDatabaseAsync()
        {
            var reminders = await _reminderRepository.GetAllReminderAsync();
            if (reminders != null && reminders.Any())
            {

                foreach (var reminder in reminders)
                {
                    StartReminderTask(reminder);
                }
            }
        }

        public void StartReminderTask(Reminder reminder)
        {
            if (_reminderTasks.ContainsKey(reminder.Id)) return;
            var cts = new CancellationTokenSource();
            _reminderTasks[reminder.Id] = cts;

            Task.Run(async () =>
            {
                try
                {
                    var delay = reminder.ReminderTime - DateTime.Now;
                    if (delay > TimeSpan.Zero)
                    {
                        await Task.Delay(delay);

                    }

                    if (!cts.Token.IsCancellationRequested)
                    {

                        _notificationHelper.ShowNotification("Reminder Triggered", reminder.Title);

                    }
                }
                catch (Exception)
                {
                    CancelReminderTask(reminder.Id);
                }
            }, cts.Token);
        }

        /*     private async Task TriggerReminderAsync(Reminder reminder)
             {
                 try
                 {
                     _notificationHelper.ShowNotification("Reminder Triggered", reminder.Title);
                     reminder.IsCompleted = true;
                     await _reminderRepository.UpdateReminderAsync(reminder.Id, reminder);
                 }
                 finally
                 {
                     CancelReminderTask(reminder.Id);
                     _notificationHelper.Dispose();
                 }
             }*/

       

        public async Task AddReminderAsync(Reminder reminder)
        {
            await _reminderRepository.AddReminderAsync(reminder);
            StartReminderTask(reminder);
        }

        public async Task UpdateReminderAsync(int id, Reminder reminder, DateTime? newTriggerTime)
        {
            var getReminder = await _reminderRepository.GetReminderByIdAsync(id);
            if (reminder != null)
            {
                CancelReminderTask(id);
                if (!newTriggerTime.HasValue)
                {
                    reminder.ReminderTime = reminder.ReminderTime.AddMinutes(5);
                }
                else
                {
                    reminder.ReminderTime = newTriggerTime.Value;
                }

                await _reminderRepository.UpdateReminderAsync(id, reminder);
                StartReminderTask(reminder);    
            }
        }
        public async Task HandleSnoozeReminder(Reminder reminder)
        {
            if (reminder.StatusId != 2)
            {
                reminder.StatusId = (int)ReminderStatus.Snooze;
                await UpdateReminderAsync(reminder.Id, reminder, null);
            }
            else
            {
                await UpdateReminderAsync(reminder.Id, reminder, null);
            }
        }

        public async Task DeleteReminderAsync(int id)
        {
            CancelReminderTask(id);
            await _reminderRepository.DeleteReminderAsync(id);
        }

        private void CancelReminderTask(int id)
        {
            if (_reminderTasks.TryRemove(id, out var cts))
            {
                cts.Cancel();
            }
        }

        private bool TryAddReminderTaskIntoDic(int reminderId, CancellationTokenSource cts)
        {
            if (!_reminderTasks.TryAdd(reminderId, cts))
            {
                cts.Dispose();
                return false;
            }
            return true;
        }

        public async Task ShutdownServiceAsync()
        {
            foreach (var cts in _reminderTasks.Values)
            {
                cts.Cancel();
            }

            _reminderTasks.Clear();

           
            await Task.CompletedTask;
        }
    }
}
