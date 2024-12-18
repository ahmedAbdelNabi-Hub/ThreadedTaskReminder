using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReminderApp.Infrastructure.Data
{
    public class ReminderAppDbContext
    {
        private string connectionString = "Server=LAPTOP-MLVV73RA; Database=Reminderdb; Trusted_Connection=true;";

        public SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the connection: " + ex.Message);
                return null;
            }

        }
    }
}
