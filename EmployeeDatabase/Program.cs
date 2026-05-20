using EmployeeTools;

namespace EmployeeDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee database. Press any key to continue.");
            Console.ReadLine();
            ChooseAction();
        }

        private static void ChooseAction()
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Register a new employee");
            Console.WriteLine("2. List an employee's salary by name");
            Console.WriteLine("3. List all employees and their salaries");
            Console.WriteLine("4. Add 10 random employees to the database");
            Console.WriteLine("5. Exit");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    EnterRegistration();
                    break;
                case "2":
                    EnterEmployeeSearch();
                    break;
                case "3":
                    EmployeeManager.ListAllEmployees();
                    Console.WriteLine("\nPress any key to continue to main menu");
                    Console.ReadLine();
                    break;
                case "4":
                    EmployeeManager.EmployeeRandomizer();
                    Console.WriteLine("\n10 random employees added. Press any key to continue to main menu");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            ChooseAction();
        }

        private static void EnterRegistration()
        {
            Console.Write("\nFirst name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Salary in euro/h: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("\nInvalid salary input. Please enter a valid number.");
                Console.WriteLine("Salary in euro/h: ");
                Console.ReadLine();
            }
            EmployeeManager.RegisterEmployee(firstName ?? "-" , lastName ?? "-", salary);
        }

        private static void EnterEmployeeSearch()
        {
            Console.Write("\nFirst name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string? lastName = Console.ReadLine();

            if (!EmployeeManager.ListEmployeeSalaryByName(firstName ?? "", lastName ?? ""))
            {
                Console.WriteLine("1: Try again");
                Console.WriteLine("2: Return to main menu");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        EnterEmployeeSearch();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Returning to main menu.");
                        break;
                }
            }
        }
    }
}

