using System;
using System.Windows.Forms;
using ReminderApp.ApplicationLayer.Service;
namespace ReminderApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1(new ReminderService()));

        }
    }
}
