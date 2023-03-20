using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Controllers
{
    /// <summary>
    /// Handles MainMenu view logic and flow control. 
    /// </summary>
    public static class MenuController
    {
        public static void MainMenuSelection()
        {
            bool accept = true;
            while (accept)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MenuAddEntryToHabit();
                        accept = false;
                        break;
                    case "2":
                        MenuViewHabits();
                        accept = false;
                        break;
                    case "3":
                        MenuAddHabit();
                        accept= false;
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input (1-4).");
                        continue;
                }
            }
        }
        public static void MenuAddEntryToHabit() { }
        public static void MenuViewHabits() { }
        public static void MenuAddHabit() { }


    }
}
