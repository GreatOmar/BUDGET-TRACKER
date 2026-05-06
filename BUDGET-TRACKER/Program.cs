using System;
using System.IO;

namespace BUDGET_TRACKER
{
    class Program
    {
        // 1. Global Variables (Module 2: Data Types)
        static double monthlySalary = 0;      
        static double totalExpenses = 0;      
        static double savingsGoal = 0;      
        static string userPassword = ""; 
        
        // Setting the file path to the project root directory
        static string dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "budget.txt"); 

        // Dynamic console width for centering text
        static int ConsoleWidth => Console.WindowWidth > 0 ? Console.WindowWidth : 80;

        static void Main(string[] args)
        {
            Console.Title = "Budget Tracker Professional";

            // Displaying the data file path
            string fullPath = Path.GetFullPath(dataFile);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[SYSTEM INFO] Storage File: {fullPath}");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);

            // Load existing data on startup
            InitializeSystem();

            // Authentication and Initial Setup (Module 5: Loops)
            if (!HandleLogin()) return;

            // Main Application Loop (Module 4: Control flow)
            RunApp();
        }

        // ==========================================================
        // Core System Functions
        // ==========================================================

        static bool HandleLogin()
        {
            // First-time user setup: Set password and salary immediately
            if (string.IsNullOrEmpty(userPassword))
            {
                ShowHeader();
                PrintCentered("--- FIRST TIME SETUP ---");
                
                PrintCentered("Step 1: Set your security password.");
                userPassword = GetPasswordInput("Create Password: ");
                
                Console.WriteLine();
                PrintCentered("Step 2: Set your financial basics.");
                monthlySalary = GetSafeDouble("Enter Monthly Salary: $");
                savingsGoal = GetSafeDouble("Enter Savings Goal:   $");
                
                SaveData(); // Save all initial data
                
                PrintCentered("Setup Complete! Press Enter to start...");
                Console.ReadLine();
                return true;
            }

            // Existing user login (Module 5)
            int attempts = 0;
            while (attempts < 3)
            {
                ShowHeader();
                PrintCentered("--- SECURITY ACCESS ---");
                string input = GetPasswordInput($"Enter Password ({3 - attempts} left): ");
                
                if (input == userPassword) return true;

                attempts++;
                Console.ForegroundColor = ConsoleColor.Red;
                PrintCentered("Invalid Password!");
                Console.ResetColor();
                System.Threading.Thread.Sleep(800);
            }
            return false;
        }

        static string GetPasswordInput(string prompt)
        {
            Console.Write(new string(' ', Math.Max(0, (ConsoleWidth / 2) - 15)));
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void InitializeSystem()
        {
            // Read data from file if it exists (Module 6: File Handling)
            if (File.Exists(dataFile)) 
            {
                try {
                    string[] lines = File.ReadAllLines(dataFile);
                    if (lines.Length >= 4)
                    {
                        monthlySalary = double.Parse(lines[0]);
                        totalExpenses = double.Parse(lines[1]);
                        savingsGoal = double.Parse(lines[2]);
                        userPassword = lines[3]; 
                    }
                } catch { /* Handle file corruption silently */ }
            }
        }

        static void RunApp()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ShowHeader();
                PrintCentered($"SALARY: ${monthlySalary:F2} | SPENT: ${totalExpenses:F2}");
                PrintCentered("------------------------------------------------------------------");
                PrintCentered("1. Add Expense | 2. Summary | 3. 12-Month Forecast");
                PrintCentered("4. Change Monthly Salary | 5. Exit"); 
                Console.WriteLine(new string('-', ConsoleWidth - 1));
                
                Console.Write(new string(' ', Math.Max(0, (ConsoleWidth / 2) - 8)));
                Console.Write("Your Choice: ");
                switch (Console.ReadLine()) 
                {
                    case "1": AddExpense(); break;
                    case "2": ShowSummary(); break;
                    case "3": ShowForecast(); break;
                    case "4": ChangeSalary(); break; 
                    case "5": isRunning = false; break;
                }
            }
        }

        static void ChangeSalary()
        {
            ShowHeader();
            PrintCentered("--- UPDATE MONTHLY SALARY ---");
            PrintCentered($"Current: ${monthlySalary:F2}");
            monthlySalary = GetSafeDouble("New Monthly Salary: $");
            SaveData();
            PrintCentered("Salary Updated! Press Enter...");
            Console.ReadLine();
        }

        static void SaveData()
        {
            // Writing 4 lines to the file: Salary, Expenses, Goal, Password
            string[] content = { 
                monthlySalary.ToString(), 
                totalExpenses.ToString(), 
                savingsGoal.ToString(),
                userPassword 
            };
            File.WriteAllLines(dataFile, content); 
        }

        // ==========================================================
        // UI & Formatting Helpers
        // ==========================================================

        static void ShowHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; // Sky Blue color as requested
            string[] logo = {
                @"  ____  _   _ ____   ____ _____ _____   _____ ____     _     ____ _  _______ ____  ",
                @" | __ )| | | |  _ \ / ___| ____|_   _| |_   _|  _ \   / \   / ___| |/ / ____|  _ \ ",
                @" |  _ \| | | | | | | |  _|  _|   | |     | | | |_) | / _ \ | |   | ' /|  _| | |_) |",
                @" | |_) | |_| | |_| | |_| | |___  | |     | | |  _ < / ___ \| |___| . \| |___|  _ < ",
                @" |____/ \___/|____/ \____|_____| |_|     |_| |_| \_/_/   \_\\____|_|\_\_____|_| \_\"
            };
            foreach (string line in logo) PrintCentered(line);
            Console.WriteLine();
            PrintCentered("=====================================================================================");
            PrintCentered("S M A R T   B U D G E T   A S S I S T A N T   v 1.3");
            PrintCentered("=====================================================================================");
            Console.ResetColor();
        }

        static void PrintCentered(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            int spaces = (ConsoleWidth - text.Length) / 2;
            if (spaces > 0) Console.Write(new string(' ', spaces));
            Console.WriteLine(text);
        }

        static double GetSafeDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(new string(' ', Math.Max(0, (ConsoleWidth / 2) - 20)));
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result)) return result;
                PrintCentered("Invalid input! Please enter a number.");
            }
        }

        static void AddExpense()
        {
            ShowHeader();
            PrintCentered("--- ADD EXPENSE ---");
            totalExpenses += GetSafeDouble("Amount: $");
            SaveData();
            PrintCentered("Updated! Press Enter...");
            Console.ReadLine();
        }

        static void ShowSummary()
        {
            ShowHeader();
            double balance = monthlySalary - totalExpenses;
            PrintCentered($"SALARY: ${monthlySalary:F2} | SPENT: ${totalExpenses:F2}");
            PrintCentered($"REMAINING BALANCE: ${balance:F2}");
            if (balance < 0) { Console.ForegroundColor = ConsoleColor.Red; PrintCentered("OVER BUDGET!"); }
            else { Console.ForegroundColor = ConsoleColor.Green; PrintCentered("WITHIN BUDGET"); }
            Console.ResetColor();
            Console.ReadLine();
        }

        static void ShowForecast()
        {
            ShowHeader();
            double savings = monthlySalary - totalExpenses;
            PrintCentered("--- 12-MONTH SAVINGS FORECAST ---");
            for (int i = 1; i <= 12; i++) PrintCentered($"Month {i:D2}: ${(savings * i):F2}");
            Console.ReadLine();
        }
    }
}