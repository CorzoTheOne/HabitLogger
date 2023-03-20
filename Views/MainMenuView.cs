using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Views
{
    /// <summary>
    /// This view shows the main menu. 
    /// </summary>
    public static class MainMenuView
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine(@"Welcome to the Habit Tracker!
            You now have the following options:
                                
            1. Add Entry to a habit
            2. View Habits (and Records)
            3. Add Habit
            4. Exit Application

            Select your choice and press 'Enter'.");
            Controllers.MenuController.MainMenuSelection();
        }
    }
}
