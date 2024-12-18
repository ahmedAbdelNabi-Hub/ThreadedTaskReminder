using ReminderApp.ApplicationLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.ApplicationLayer.Interface
{
    public interface IReminderRepository
    {
        Task<Reminder> GetReminderByIdAsync(int id);
        Task<List<Reminder>> GetAllReminderAsync();
        Task AddReminderAsync(Reminder reminder); 
        Task UpdateReminderAsync(int id , Reminder reminder);
        Task DeleteReminderAsync(int id);
    }
}
