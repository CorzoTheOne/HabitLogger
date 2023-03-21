using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Views
{
    /// <summary>
    /// This View shows the user the records of the selected habit.
    /// </summary>
    public static class RecordView
    {
        public static List<string> ViewAddRecord()
        {
            Console.WriteLine("Please type the fields noted 'INCLUDE!' - separated by a space:");
            string items = Console.ReadLine();
            List<string> itemsSplit = items.Split(" ").ToList();
            return itemsSplit;

        }
        public static string SelectHabitToAddEntryTo()
        {
            Console.WriteLine("Please type the name of the habit you would like to add a record to: ");
            HabitView.GetHabitList();
            string habitName = Console.ReadLine();
            // TODO : Add exception handling logic to verify that the table exists. 
            // TODO : Create view and logic that offers the user to create a new table if it does not (or type name again).
            return habitName;
        }


        public static void ViewAllRecords() { }

        public static void DeleteARecord() { }
        public static void UpdateARecord() { }

        /// <summary>
        ///     Called with a tuple of lists of field names and data types 
        ///     display these values in formatted order. 
        /// </summary>
        /// <param name="items"></param>
        public static List<string> ViewHabitData((List<string>, List<string>) items)
        {
            StringBuilder sb = new();
            List<string> typeManager = new();
            for (int i = 0; i < items.Item1.Count; i++)
            {
                if (items.Item1[i] == "Id" || items.Item1[i] == "Date")
                {
                    sb.AppendLine($"Column: {items.Item1[i]} | DATATYPE: {items.Item2[i]} - DO NOT INCLUDE!");
                    continue;
                }
                else
                {
                    typeManager.Add(items.Item2[i]);
                    sb.AppendLine($"Column: {items.Item1[i]} | DATATYPE: {items.Item2[i]} - INCLUDE!");
                }
            }
            Console.WriteLine(sb.ToString());
            return typeManager;
        }

    }
}
