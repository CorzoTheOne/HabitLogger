using HabitLogger.Models;
using HabitLogger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Controllers
{
    /// <summary>
    /// This controller contains logic to finding the correct record view and record related flowcontol.
    /// </summary>
    public static class RecordController
    {
        public static void AddEntryToHabit(string habitName) 
        {
            // Connect with the Record Model and get the field and data types from the relevant Habit table.
            RecordModel recordObject = new();
            (List<string>, List<string>) items = recordObject.GetFields(habitName);

            // Displays the field names and data types.
            // Also gets the types out of the data, so that they can be correctly queried. 
            List<string> typeManager = RecordView.ViewHabitData(items);

            // Container to store the valeus and types after unpacking.
            List<(string, string)> valuesAndTypes = new List<(string, string)>(); 
            
            // Asks for user input and splits it. 
            List<string> record = RecordView.ViewAddRecord();
            for (int i = 0; i < typeManager.Count; i++)
            {
                valuesAndTypes.Add((record[i], typeManager[i]));                
            }

            // Builds and returns the query string. 
            RecordModel newRecordObject = new();
            string query = newRecordObject.BuildRecordQuery(habitName, valuesAndTypes);
            newRecordObject.AddRecordToHabit(query);   
        }
        public static void GetAllRecords() { }
        public static void ChangeARecord(int id) { }
        public static void DeleteRecord(int id) { }
        
    }
}
