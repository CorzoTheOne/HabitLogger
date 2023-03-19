using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Views
{
    public static class HabitCreatorView
    {
        public static void AddFieldToHabitView()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Please enter the name of the field (Use CamelCase and no spaces).");
            Console.WriteLine("For an explanation of the type, type 'help'. ");
        }

        public static void AddFieldTypeToHabitView()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Please enter the TYPE of the field.");
            Console.WriteLine("For an explanation of the type, type 'help'. ");
        }

        public static void HabitDataTypeExplainer()
        {
            Console.WriteLine(@"Fields for you habit can include these three formats: 
                               TEXT, INTEGER, REAL. 

                               TEXT : Anything that includes letter characters (a,b,x,y,z,abc)
                               INTEGER : Whole numbers (1, 2, 3, 4, ..., 99, 100)
                               REAL : Decimal numbers (0.1, 1.0, 1.1, 1.5, 99.9)

                               Your habit can only include these inputs (Id and Datetime is automatically added.");
        }

        public static void FieldNameTooLongView(string fieldName)
        {
            Console.WriteLine($"The field name: {fieldName} is too long - Max size allowed = 25 characters");
        }

        public static void AddMoreFields()
        {
            Console.WriteLine("Would you like to add more fields to the habit? (y/n)");
        }
    }
}
