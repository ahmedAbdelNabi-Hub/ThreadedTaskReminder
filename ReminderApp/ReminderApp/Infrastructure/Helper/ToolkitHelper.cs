using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Service;

namespace ReminderApp.Infrastructure.Helper
{
    public class ToolkitHelper
    {
        private readonly ReminderService _reminderService;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private bool _userInteracted = false;
        private readonly object _lockObj = new object();
        private Reminder _reminder;
        public ToolkitHelper(ReminderService reminderService)
        {
            
            _reminderService = reminderService;

            ToastNotificationManagerCompat.OnActivated += async toastArgs =>
            {
                try
                {
                    var argument = toastArgs.Argument;
                    var action = GetActionFromArgument(argument);
                    var reminderId = GetIdFromArgument(argument);
                    if (reminderId == _reminder.Id)
                    {
                        await HandleToastAction(action);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"error here: {ex.Message}");
                }
            };
        }

        public async Task ShowNotification(string title, string message, Reminder reminder)
        {
            await _semaphore.WaitAsync();
            _reminder = reminder;
            try
            {
                Console.WriteLine($"{_reminder.Id}: ${Thread.CurrentThread.ManagedThreadId}");

                new ToastContentBuilder()
                    .AddText(title)
                    .AddText(message)
                    .AddText("Form id :"+reminder.FormId)
                    .AddButton(new ToastButton()
                        .SetContent("Complete")
                        .AddArgument("action", "Complete")
                        .AddArgument("id", _reminder.Id + "")
                        .SetBackgroundActivation())
                    .AddButton(new ToastButton()
                        .SetContent("Snooze")
                        .AddArgument("action", "Snooze")
                        .AddArgument("id", _reminder.Id + "")
                        .SetBackgroundActivation())
                    .Show();

                await Task.Delay(4000);

                if (!_userInteracted)
                {
                    await _reminderService.handleSnoozeReminder(reminder);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task HandleToastAction(string action)
        {
            _userInteracted = true;
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
            try { 

                if (action == "Complete")
                {
                    await _reminderService.handleCompleteReminder(_reminder);
                }
                if (action == "Snooze")
                {
                    await _reminderService.handleSnoozeReminder(_reminder);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"error here : {ex.Message}");
            }
            finally
            {
                _userInteracted = false;
            }
        }


        private string GetActionFromArgument(string argument)
        {
            lock (_lockObj)
            {
                var keyValuePairs = argument.Split('&')
                    .Select(part => part.Split('='))
                    .ToDictionary(split => split[0], split => split[1]);

                if (keyValuePairs.ContainsKey("action"))
                {
                    var action = keyValuePairs["action"];
                    return action.Split(';')[0];
                }
                return null;
            }
        }

        private int? GetIdFromArgument(string argument)
        {
            lock (_lockObj)
            {
                var parts = argument.Split(';');
                foreach (var part in parts)
                {
                    if (part.StartsWith("id="))
                    {
                        var idValue = part.Substring(3);
                        if (int.TryParse(idValue, out int id))
                        {
                            return id;
                        }
                    }
                }
                return null;
            }
        }
    }
}

