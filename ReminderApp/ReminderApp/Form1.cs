using ReminderApp.ApplicationLayer.Entities;
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
    public partial class Form1 : Form
    {
        private ReminderService _reminderService;
        public Form1(ReminderService reminderService)
        {
            _reminderService = reminderService; 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfForms = 0;

            if (int.TryParse(textBox1.Text, out numberOfForms) && numberOfForms > 0)
            {
                this.Hide();
           

                for (int i = 1; i <= numberOfForms; i++)
                {
                    RminderGui ReminderGui = new RminderGui(i,_reminderService);
                    ReminderGui.Show(); 
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number greater than 0.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
