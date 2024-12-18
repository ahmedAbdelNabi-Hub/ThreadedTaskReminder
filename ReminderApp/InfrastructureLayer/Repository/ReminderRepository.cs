using ReminderApp.ApplicationLayer.Entities;
using ReminderApp.ApplicationLayer.Interface;
using ReminderApp.InfrastructureLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ReminderApp.InfrastructureLayer.Repository
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly RminderAppDbContext _context;

        public ReminderRepository()
        {
            _context = new RminderAppDbContext();
        }
        public ReminderRepository(RminderAppDbContext context)
        {
            _context = context;
        }
        public async Task AddReminderAsync(Reminder reminder)
        {
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();

                var query = @"INSERT INTO Reminder (Title, Description, ReminderTime, StatusId)
                              VALUES (@Title, @Description, @ReminderTime, @StatusId)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", reminder.Title);
                    command.Parameters.AddWithValue("@Description", reminder.Description);
                    command.Parameters.AddWithValue("@ReminderTime", reminder.ReminderTime);
                    command.Parameters.AddWithValue("@StatusId", reminder.StatusId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteReminderAsync(int id)
        {
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Reminder WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Reminder>> GetAllReminderAsync()
        {
            var reminders = new List<Reminder>();

            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();

                var query = @"SELECT r.Id, r.Title, r.Description, r.ReminderTime, r.StatusId, s.Name AS StatusName
                              FROM Reminder r
                              INNER JOIN Status s ON r.StatusId = s.Id
                              WHERE s.Name = 'Idle';
                              ";
                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        reminders.Add(new Reminder
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            ReminderTime = reader.GetDateTime(reader.GetOrdinal("ReminderTime")),
                            StatusId = reader.GetInt32(reader.GetOrdinal("StatusId")),
                            Status = new Status
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("StatusId")),
                                Name = reader.GetString(reader.GetOrdinal("StatusName"))
                            }
                        });
                    }
                }
            }

            return reminders;
        }

        public async Task<Reminder> GetReminderByIdAsync(int id)
        {
            Reminder reminder = null;

            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();

                var query = @"SELECT r.Id, r.Title, r.Description, r.ReminderTime, r.StatusId, s.Name AS StatusName
                              FROM Reminder r
                              INNER JOIN Status s ON r.StatusId = s.Id
                              WHERE r.Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            reminder = new Reminder
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ReminderTime = reader.GetDateTime(reader.GetOrdinal("ReminderTime")),
                                StatusId = reader.GetInt32(reader.GetOrdinal("StatusId")),
                                Status = new Status
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("StatusId")),
                                    Name = reader.GetString(reader.GetOrdinal("StatusName"))
                                }
                            };
                        }
                    }
                }
            }

            return reminder;
        }

        public async Task UpdateReminderAsync(int id, Reminder reminder)
        {
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync();

                var query = @"UPDATE Reminder
                              SET Title = @Title, Description = @Description, ReminderTime = @ReminderTime, StatusId = @StatusId
                              WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", reminder.Title);
                    command.Parameters.AddWithValue("@Description", reminder.Description);
                    command.Parameters.AddWithValue("@ReminderTime", reminder.ReminderTime);
                    command.Parameters.AddWithValue("@StatusId", reminder.StatusId);
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
