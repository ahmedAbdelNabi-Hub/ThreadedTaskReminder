using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReminderApp.ApplicationLayer.Entities
{
    public class Reminder
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReminderTime { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int FormId { get; set; }
     }
}
