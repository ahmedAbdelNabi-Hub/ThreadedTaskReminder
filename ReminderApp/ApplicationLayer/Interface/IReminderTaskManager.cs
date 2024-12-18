using ReminderApp.ApplicationLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.ApplicationLayer.Interface
{
    public interface IReminderTaskManager
    {
        void StartReminderTask(Reminder reminder);
        void CancelReminderTask(int id);
        Task ShutdownServiceAsync();
    }
}
