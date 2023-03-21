using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Views
{
    /// <summary>
    /// This habit is responsible for displaying the habits and guiding the user.
    /// </summary>
    public static class HabitView
    {
        private static readonly string connectionString = @"Data Source=habit-Tracker.db";
        private static SqliteConnection connection = new SqliteConnection(connectionString);
        private static SqliteCommand command = connection.CreateCommand();
        private static SqliteDataReader reader;

        public static void DisplayHabits()
        {
            var sql = "SELECT name FROM sqlite_master WHERE type='table'";
            string connectionString = @"Data Source=habit-Tracker.db";

            SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;

            connection.Open();

            SqliteCommand command = new SqliteCommand(sql, connection);
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine(reader.Read());
            }
            connection.Close();
        }

        public static void GetHabitList()
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
            using (connection)
            {
                connection.Open();
                reader = command.ExecuteReader();
                int inc = 0;
                while (reader.Read())
                {
                    if (inc == 0)
                    {
                        inc++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{inc} = " + reader.GetString(0));
                        inc++;
                    }
                }
                connection.Close();
            }
        }

    }
}
