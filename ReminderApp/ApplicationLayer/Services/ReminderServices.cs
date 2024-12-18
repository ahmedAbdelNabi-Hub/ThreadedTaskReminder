using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Interface;
using ReminderApp.InfrastructureLayer.Context;
using ReminderApp.InfrastructureLayer.Repository;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReminderApp.Service
{
    public class ReminderService
    {
        /*private readonly IReminderRepository _reminderRepository;

        public ReminderService()
        {
            _reminderRepository = new ReminderRepository();
            LoadRemindersFromDatabaseAsync().Wait();
        }

        private async Task LoadRemindersFromDatabaseAsync()
        {
            var reminders = await _reminderRepository.GetAllReminderAsync();
            if (reminders != null && reminders.Any())
            {
                foreach (var reminder in reminders)
                {
                    _reminderTaskManager.StartReminderTask(reminder);
                }
            }
        }

        
        public async Task AddReminderAsync(Reminder reminder)
        {
            await _reminderRepository.AddReminderAsync(reminder);
            _reminderTaskManager.StartReminderTask(reminder);
        }

        public async Task UpdateReminderAsync(int id, Reminder reminder, DateTime? newTriggerTime)
        {
            var getReminder = await _reminderRepository.GetReminderByIdAsync(id);
            if (reminder != null)
            {
                _reminderTaskManager.CancelReminderTask(id);
                if (!newTriggerTime.HasValue)
                {
                    reminder.ReminderTime = reminder.ReminderTime.AddMinutes(5);
                }
                else
                {
                    reminder.ReminderTime = newTriggerTime.Value;
                }

                await _reminderRepository.UpdateReminderAsync(id, reminder);
                _reminderTaskManager.StartReminderTask(reminder);
            }
        }


        public async Task DeleteReminderAsync(int id)
        {
            _reminderTaskManager.CancelReminderTask(id);
            await _reminderRepository.DeleteReminderAsync(id);
        }

        public async Task ShutdownServiceAsync()
        {
            await _reminderTaskManager.ShutdownServiceAsync();
        }
    }*/

    }
}
