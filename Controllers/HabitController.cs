using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Controllers
{
    /// <summary>
    /// This class contains logic for getting habit related views and flow control. 
    /// </summary>
    public static class HabitController
    {
        /// <summary>
        /// Ask for user to select the name and type of the field that they wish to input.
        /// </summary>
        /// <returns>A tuple with the (Name, Type) pair</returns>
        public static (string, string) AddFieldToHabit()
        {
            (string, string) fieldData = default;
            bool getFieldInput = true;
            while (getFieldInput)
            {
                Views.HabitCreatorView.AddFieldToHabitView();
                string field = Console.ReadLine();
                if (field.Length > 25)
                {
                    Views.HabitCreatorView.FieldNameTooLongView(field);
                    continue;
                }
                switch (field)
                {
                    case "help":
                        Views.HabitCreatorView.HabitDataTypeExplainer();
                        break;
                    default:
                        fieldData.Item1 = field;
                        getFieldInput = false;
                        break;
                }
            }
            bool getTypeInput = true;
            while (getTypeInput)
            {
                Views.HabitCreatorView.AddFieldTypeToHabitView();
                string fieldType = Console.ReadLine();
                
                switch (fieldType.ToUpper())
                {
                    case "TEXT":
                        fieldData.Item2 = fieldType.ToUpper();
                        getTypeInput = false;
                        break;
                    case "INTEGER":
                        fieldData.Item2 = fieldType.ToUpper();
                        getTypeInput = false;
                        break;
                    case "REAL":
                        fieldData.Item2 = fieldType.ToUpper();
                        getTypeInput = false;
                        break;
                    default:
                        continue;
                }
            }
            return fieldData;
        }

        public static StringBuilder CreateQueryCommand()
        {
            // TODO : Add Viewmessage that asks the user for the name of the habit.
            string habitName = Console.ReadLine();
            StringBuilder command = new();
            List<(string, string)> fieldsList = new();

            string create = $"CREATE TABLE IF NOT EXISTS {habitName} (";
            string setId = "Id INTEGER PRIMARY KEY AUTOINCREMENT,";
            command.AppendLine(create);
            command.AppendLine(setId);
            int fieldCount = 0;
            /// All habits must have at least 1 field.
            if (fieldCount < 1)
            {
                fieldsList.Add(AddFieldToHabit());
            }
            bool moreFieldsFlag = true;
            while (moreFieldsFlag)
            {
                // TODO : VIEW THAT DISPLAYS THE CURRENT HABIT TABLE. 
                Views.HabitCreatorView.AddMoreFields();
                string more = Console.ReadLine();
                if (more.ToLower() == "y" || more.ToLower() == "yes")
                {
                    fieldsList.Add(AddFieldToHabit());
                }
                else
                {
                    // TODO : VIEW THAT DISPLAYS THE CURRENT HABIT TABLE.
                    // TODO : VIEW WITH MESSAGE THAT HABIT WILL BE ADDED TO DB.
                    moreFieldsFlag = false;
                }
            }

            foreach ((string, string) n in fieldsList)
            {
                command.AppendLine($"{n.Item1} {n.Item2},");
            }
            command.AppendLine("Date TEXT )");
            Console.WriteLine(command);
            return command;
        }
    }
}
