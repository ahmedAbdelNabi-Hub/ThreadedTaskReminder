using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Enum;
using ReminderApp.ApplicationLayer.Interface;
using ReminderApp.ApplicationLayer.Service;
using ReminderApp.InfrastructureLayer.Repository;
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
    public partial class RminderGui : Form
    {
        private ReminderService _reminderService;
        private ReminderRepository _reminderRepository;
        private int _FromId { get; set; }

        public RminderGui(int id, ReminderService reminderService)
        {
            _reminderService = reminderService;
            _reminderRepository = new ReminderRepository();
            _FromId = id;
            InitializeComponent();
        }

        private async void RminderGui_Load(object sender, EventArgs e)
        {
            await _reminderService.LoadRemindersFromDatabaseAsync(_FromId, "Idle");
            panel2.Hide();  
            dateTimePicker1.Visible = true;
            await LoadRemindersIsIdleAsync();
        }

        private async Task LoadRemindersIsIdleAsync()
        {
            var reminders = await _reminderRepository.GetAllReminderAsync("Idle", _FromId);
            dataGridView1.Rows.Clear();
            foreach (var reminder in reminders)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.Title });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.Description });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.ReminderTime.ToString() });
                var deleteButtonCell = new DataGridViewButtonCell { Value = "Delete" };
                row.Cells.Add(deleteButtonCell);
                row.Tag = reminder.Id;
                dataGridView1.Rows.Add(row);
            }
        }
        private async Task LoadRemindersIsCompletedAsync()
        {
            var idleReminders = await _reminderRepository.GetAllReminderAsync("Completed", _FromId);
            dataGridView2.Rows.Clear();

            foreach (var reminder in idleReminders)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.Title });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.Description });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = reminder.ReminderTime.ToString() });
                var deleteButtonCell = new DataGridViewButtonCell { Value = "Delete" };
                row.Cells.Add(deleteButtonCell);
                row.Tag = reminder.Id;
                dataGridView2.Rows.Add(row);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string taskText = txtaddtask.Text;
            string description = "hello from Reminder app";
            var dateTimePicker = dateTimePicker1.Value;

            var reminder = new Reminder()
            {
                Title = taskText,
                Description = description,
                FormId = _FromId,
                StatusId = (int)ReminderStatus.Idel,
                ReminderTime = dateTimePicker
            };
            await _reminderService.AddReminderAsync(reminder);
            await LoadRemindersIsIdleAsync();
            txtaddtask.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["action"].Index && e.RowIndex >= 0)
            {
                var reminderId = (int)dataGridView1.Rows[e.RowIndex].Tag;

                await _reminderService.deleteReminderAsync(reminderId);

                await LoadRemindersIsIdleAsync();
            }
        }

 

        private void Fullpanel_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void txtaddtask_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

      

        private void btnComplete_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show(); 
        }

        private async void btnTask_Click_1(object sender, EventArgs e)
        {
           panel2.Hide();   
           panel1.Show();
           await LoadRemindersIsIdleAsync() ;   
        }

        private async void panel2_Paint(object sender, PaintEventArgs e)
        {
           await LoadRemindersIsCompletedAsync() ;  
        }

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var reminderId = (int)dataGridView2.Rows[e.RowIndex].Tag;
                await _reminderService.deleteReminderAsync(reminderId);
                await LoadRemindersIsCompletedAsync();  
            }
        }
    }
}
