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

        /// <summary>
        ///     Gets a query with data to add to the database
        /// </summary>
        public void AddRecordToHabit(string query)
        {
            Console.WriteLine(query);
            using (connection)
            {
                connection.Open();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateRecord(int id)
        {

        }
        public void DeleteRecord(int id)
        {

        }
        public void GetLatestRecords(string habitName) 
        { 
            
        }


        //https://stackoverflow.com/questions/17284967/is-it-possible-to-get-column-name-header-in-sqlite-using-c
        public (List<string>, List<string>) GetFields(string habitName)
        {
            List<string> names = new List<string>();
            List<string> types = new List<string>();

            command.CommandText = $"SELECT * FROM {habitName}";
            using (connection)
            {
                connection.Open();
                var dr = command.ExecuteReader();
                for (var i = 0; i < dr.FieldCount; i++)
                {
                    names.Add(dr.GetName(i));
                    types.Add(dr.GetDataTypeName(i));
                }
                connection.Close();
            }
            return (names, types);
        }

        public string BuildRecordQuery(string habitName, List<(string, string)> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"INSERT INTO {habitName}");
            sb.Append($"(");

            // Get the column names again...
            (List<string>, List<string>) fieldNames = GetFields(habitName);
            for (int i = 0; i < fieldNames.Item1.Count; i++)
            {
                if (fieldNames.Item1[i] == "Id")
                {
                    continue;
                }
                else if (fieldNames.Item1[i] == "Date")
                {
                    sb.Append($"{fieldNames.Item1[i]}");
                }
                else
                {
                    sb.Append($"{fieldNames.Item1[i]}, ");
                }
            }
            sb.Append(") ");
            sb.AppendLine($"VALUES ");
            sb.Append("(");
            for (int i = 0; i < items.Count;i++)
            {
                if (items[i].Item2 == "REAL")
                {
                    double temp = ConvertStringToReal(items[i].Item1);
                    sb.Append($"{temp},");
                }
                else if (items[i].Item2 == "INTEGER")
                {
                    int temp = ConvertStringToInteger(items[i].Item1);
                    sb.Append($"{temp},");
                }
                else
                {
                    sb.Append($"'{items[i].Item1}', ");
                }
            }
            DateTime date = DateTime.Now;
            string dateString = date.ToString("MM/dd/yyyy");
            sb.Append($"'{dateString}'");
            sb.Append(")");
            string query = sb.ToString();
            return query;
        }

        public double ConvertStringToReal(string value) 
        {
            return Double.Parse(value);
        }
        public int ConvertStringToInteger(string value) 
        {
            return Int32.Parse(value);
        }
    }
}
