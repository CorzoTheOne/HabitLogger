using Microsoft.Data.Sqlite;
using System.Text;
using HabitLogger.Models;
using HabitLogger.Views;
using HabitLogger.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {

        /*      RecordModel recordModel = new RecordModel();
                RecordView.ViewAddRecord();
                recordModel.GetFields("table_name");
                StringBuilder test = new();
                test = HabitLogger.Controllers.HabitController.CreateQueryCommand();
                HabitModel.AddHabitToDB(test);

                HabitView.GetHabitList();*/

        MainMenuView.DisplayMainMenu();
    }
}