using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Interface;
using ReminderApp.Infrastructure.Data;
using ReminderApp.Infrastructure.Helper;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReminderApp.InfrastructureLayer.Repository;
using ReminderApp.ApplicationLayer.Enum;



namespace ReminderApp.ApplicationLayer.Service
{
    public class ReminderService
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private readonly IReminderRepository _reminderRepository;
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _reminderTasks = new ConcurrentDictionary<int, CancellationTokenSource>();
        private readonly ToolkitHelper toolkitHelper;
        public ReminderService()
        {
            _reminderRepository = new ReminderRepository(new ReminderAppDbContext());
            toolkitHelper = new ToolkitHelper(this);
        }

        public async Task LoadRemindersFromDatabaseAsync(int formId , string status)
        {
            var reminders = await _reminderRepository.GetAllReminderAsync(status,formId);
            if(reminders != null && reminders.Any())
            {
                
                foreach (var reminder in reminders)
                {
                    StartReminderTask(reminder);
                }
            }   
        }
        private void StartReminderTask(Reminder reminder)
        {
            if (_reminderTasks.ContainsKey(reminder.Id)) return;
            var cts = new CancellationTokenSource();
            _reminderTasks[reminder.Id] = cts;
            Task.Run(async () =>{ await ProcessReminderTask(reminder,cts) ;}, cts.Token);
        }
        private async Task ProcessReminderTask(Reminder reminder, CancellationTokenSource cts)
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
                    await toolkitHelper.ShowNotification(reminder.Title, reminder.Description, reminder);
                }
            }
            finally
            {
                _reminderTasks.TryRemove(reminder.Id, out _);
            }
        }
        public async Task AddReminderAsync(Reminder reminder)
        {
            await _semaphore.WaitAsync();
            try
            {
                await _reminderRepository.AddReminderAsync(reminder);
                await LoadRemindersFromDatabaseAsync(reminder.FormId, "Idle");
            }
            finally
            {
                _semaphore.Release();   
            }
        
        }
        public async Task UpdateReminderAsync(int id, Reminder reminder, DateTime? newTriggerTime)
        {
            var getReminder = await _reminderRepository.GetReminderByIdAsync(id);
            if (reminder != null)
            {
                cancelReminderTask(id);
                if (!newTriggerTime.HasValue)
                {
                    reminder.ReminderTime = reminder.ReminderTime.AddSeconds(30);
                }
                else
                {
                    reminder.ReminderTime = newTriggerTime.Value;
                }
                await _reminderRepository.UpdateReminderAsync(id, reminder);

                if (reminder.StatusId == 3)
                {
                    StartReminderTask(reminder);
                    return;
                }
                return; 
            }
        }
        public async Task handleSnoozeReminder(Reminder reminder)
        {
            if (reminder.StatusId == (int) ReminderStatus.Idel)
            {
                reminder.StatusId = (int)ReminderStatus.Snooze;
                await UpdateReminderAsync(reminder.Id, reminder, null);
            }
            else if(reminder.StatusId == (int)ReminderStatus.Snooze)
            {
                await UpdateReminderAsync(reminder.Id, reminder, null);
            }
        }
        public async Task handleCompleteReminder(Reminder reminder)
        {
            if (reminder.StatusId == (int)ReminderStatus.Snooze || reminder.StatusId== (int)ReminderStatus.Idel)
            {
                reminder.StatusId = (int)ReminderStatus.Completed;
                await UpdateReminderAsync(reminder.Id, reminder, DateTime.Now);
            }
           
        }
        public async Task deleteReminderAsync(int id)
        {
            cancelReminderTask(id);
            await _reminderRepository.DeleteReminderAsync(id);
        }
        private void cancelReminderTask(int id)
        {
            if (_reminderTasks.TryRemove(id, out var cts))
            {
                cts.Cancel();
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is dead");
            }
        }

    }
}
