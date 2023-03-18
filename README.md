# HabitLogger

In this application - i need to be able to create and track habits. 
The app stores and retrieves data from a real database. 
On startup - Create a 'SQLite' database, if one isn't present.
	The app must create tables in the database, where the habits will be logged.
The app has a menu of options (CRUD) and Exit. 
The app must be crash proof. 

TODO's  before project start:
1. DONE - Get a very basic understanding of SQL -> Enough to do CRUD operations 
	https://www.w3schools.com/sql/sql_exercises.asp
2. Detailed project description and Sequence/Detail Flow Diagrams for the user flows. 
3. 


2 - DETAILED PROJECT DESCRIPTION

This is a habit tracking application. It gives the user the ability to create habits, and store records of the habits in a database (Sqlite).
The user must be able to: Create a habit -> and select how to record it. 
Get the data from the habit, including basic search functionality. 

Requirements:
- Menu with options to choose from: 
	/ Add Habit
		## Action flow appears which guides the user, step by step to create a habit. 
		// Select a Habit name -> Store variable with the name (need to have correct formatting logic)
		### The id field is chosen by defualt, set as primary key and autoincremented. 
		// Values (NOT DATE) can be chosen -> While loop that lets the user choose any number of fields to add - at least 1, and the user can say 'no' to adding more.
		// The option to include a DATE field is presented for user choice. (Boolean)
		#### A AddHabitToDB function is called, with the values and the DB table is created. 
		TODO : Figure out the best way to transport the values to the 'AddHabitToDB' function -> 
			LIST - Can store all variables as string, and then try to convert them to int, if fail -> then text? 
				 - Or use a switch case with a few helper functions to guarantee that the user cannot mess it up? 

	/ View Habits
		// Add Habit
			# Follows the 'Add Habit' flow. 
		// Select specific Habit 
			/// The user is pinged to select a habit, probably by name - But could maybe store a table of all habits with an ID? 
				## All records are loaded from the DB and shown 
				## Options are shown at the bottom:
				/// Add Record
					### Logic to Add Record
				/// Modify Record
					## Message requesting the user to type a valid record ID. 
						## The record is shown - user to select field: 1,2,3,4,...,n to update.
				/// Delete Record
					## Message requesting the user to type a valid record ID. 
					// Logic to delete the record from the DB. 
	/ Exit application. 

