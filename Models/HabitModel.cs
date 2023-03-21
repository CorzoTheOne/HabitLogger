using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Models
{
    public static class HabitModel
    {
        /// <summary>
        /// TODO : Make the stringbuilder that will be used to structure the queryable CommandText call.
        /// </summary>
        public static void AddHabitToDB(StringBuilder command)
        {
            string connectionString = @"Data Source=habit-Tracker.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                string commands = command.ToString();
                Console.WriteLine(commands);
                tableCmd.CommandText = $"{commands}";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }






    }
}
