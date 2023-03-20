using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Models
{
    internal class RecordModel
    {
        private readonly string connectionString = @"Data Source=habit-Tracker.db";
        private SqliteConnection connection;
        private SqliteCommand command;
        //private SqliteDataReader reader;
    
        public RecordModel()
        {
            connection = new SqliteConnection(connectionString);
            command = connection.CreateCommand();
            // reader = command.ExecuteReader();
        }

        public void AddRecordToHabit(string habitName)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = $"INSERT INTO {habitName} VALUES ";
        }

        public void UpdateRecord(int id)
        {

        }
        public void DeleteRecord(int id)
        {

        }
        public void GetRecords(string habitName) { }

        //https://stackoverflow.com/questions/17284967/is-it-possible-to-get-column-name-header-in-sqlite-using-c
        public void GetFields(string habitName)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = $"SELECT * FROM {habitName}";
            using (connection)
            {
                connection.Open();
                var dr = command.ExecuteReader();
                for (var i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetName(i));
                    Console.WriteLine(dr.GetDataTypeName(i));
                }
            }

            connection.Close();
        }

    }
}
