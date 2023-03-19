using Microsoft.Data.Sqlite;
using System.Text;
using HabitLogger.Models;

/*
string connectionString = @"Data Source=habit-Tracker.db";

using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();

    var tableCmd = connection.CreateCommand();

    tableCmd.CommandText = 
        @"CREATE TABLE IF NOT EXISTS drinking_water (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT,
            Quantity INTEGER
            )";

    tableCmd.ExecuteNonQuery();

    connection.Close();
}

*/

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder test = new();
        test = HabitLogger.Controllers.HabitController.CreateQueryCommand("new_table");
        HabitModel.AddHabitToDB(test);
    }
}