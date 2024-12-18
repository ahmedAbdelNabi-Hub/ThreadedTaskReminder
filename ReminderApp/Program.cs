using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReminderApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ReminderServiceV1 reminderService = new ReminderServiceV1();
            
            Form1 form1 = new Form1();
            Application.Run(form1);

            
        }
    }
}
