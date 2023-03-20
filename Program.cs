using Microsoft.Data.Sqlite;
using System.Text;
using HabitLogger.Models;
using HabitLogger.Views;

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

        RecordModel recordModel = new RecordModel();
        recordModel.GetFields("table_name");
        //StringBuilder test = new();
        //test = HabitLogger.Controllers.HabitController.CreateQueryCommand();
        //HabitModel.AddHabitToDB(test);
        MainMenuView.DisplayMainMenu();
        HabitView.GetHabitList();
    }
}