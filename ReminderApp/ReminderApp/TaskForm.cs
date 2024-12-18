using ReminderApp.ApplicationLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class TaskForm : Form
    {
        private ReminderService _reminderService;
        private int FromId {  get; set; }
      
        public TaskForm(int id, ReminderService reminderService)
        {
            _reminderService = reminderService;
            FromId = id;    
            InitializeComponent();
        }

        private async void TaskForm_Load(object sender, EventArgs e)
        {
            await _reminderService.LoadRemindersFromDatabaseAsync(FromId, "Idle");
        }
    }
}
