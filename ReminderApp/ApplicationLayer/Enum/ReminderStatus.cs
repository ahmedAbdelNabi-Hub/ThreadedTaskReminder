using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.ApplicationLayer.Enum
{
    public enum ReminderStatus
    {
        Open = 1,        // Reminder is in progress or yet to be triggered
        Completed = 2,   // Reminder has been triggered and marked as completed
        Snooze = 3       // Reminder is snoozed for later
    }
}
