using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ReminderApp.InfrastructureLayer.Context
{
    public class RminderAppDbContext
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
                Console.WriteLine("DATABSAE NOT CONNECTED ##", ex.Message);
                return null;
            }
        }
    }
}
