using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTools
{
    public class EmployeeManager
    {

        private static List<Employee> Employees = new();

        public EmployeeManager()
        {
        }

        /// <summary>
        /// Registers a new employee with the specified name and salary.
        /// </summary>
        /// <remarks>Salary is the employees hourly wage in euros.</remarks>
        /// <param name="firstName">Given name of the employee.</param>
        /// <param name="lastName">Family name of the employee.</param>
        /// <param name="salary">Employee's salary.</param>
        public static void RegisterEmployee(string firstName, string lastName, decimal salary)
        {
            Employee employee = new Employee(firstName, lastName, salary);
            Employees?.Add(employee);

            Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} with salary {employee.Salary} euro/h registered successfully.");
        }

        /// <summary>
        /// Checks if the employee with the specified name exists in the database and prints their salary.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static bool ListEmployeeSalaryByName(string firstName, string lastName)
        {
            Employee? employee = Employees.FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
            if (employee == null)
            {
                Console.WriteLine($"Employee {firstName} {lastName} not found.");
                return false;
            }
            Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} has a salary of {employee.Salary} euro/h");
            return true;
        }


        /// <summary>
        /// Lists all registered employees in the database by alphabetical order and displays their salaries.
        /// </summary>
        public static void ListAllEmployees()
        {
            var sortedEmployees = Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName);
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary} euro/h");
            }
        }

        public static void EmployeeRandomizer()
        {
            string[] firstNames =
            {
                "Liam", "Emma", "Noah", "Olivia", "Elijah",
                "Ava", "James", "Sophia", "Benjamin", "Isabella",
                "Lucas", "Mia", "Henry", "Charlotte", "Alexander",
                "Amelia", "Daniel", "Harper", "Michael", "Evelyn",
                "Ethan", "Abigail", "Mason", "Ella", "Logan",
                "Scarlett", "Jackson", "Grace", "Sebastian", "Chloe",
                "Jack", "Victoria", "Owen", "Lily", "Levi",
                "Hannah", "Wyatt", "Zoe", "Julian", "Nora"
            };

            string[] lastNames =
            {
                "Anderson", "Brown", "Clark", "Davis", "Evans",
                "Garcia", "Harris", "Johnson", "King", "Lewis",
                "Martinez", "Nelson", "Parker", "Robinson", "Scott",
                "Taylor", "Walker", "White", "Young", "Zimmerman",
                "Adams", "Baker", "Carter", "Diaz", "Edwards",
                "Foster", "Gray", "Hill", "Irwin", "Jackson",
                "Knight", "Lopez", "Mitchell", "Nguyen", "Ortiz",
                "Price", "Ramirez", "Sanders", "Turner", "Ward"
            };

            for (int i = 0; i < 10; i++)
            {
                string firstName = firstNames[Random.Shared.Next(firstNames.Length)];
                string lastName = lastNames[Random.Shared.Next(lastNames.Length)];
                decimal salary = Random.Shared.Next(10, 50); // Random salary between 10 and 50 euro/h
                RegisterEmployee(firstName, lastName, salary);
            }
        }

        class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal Salary { get; set; } //Hourly wage in euros

            public Employee(string firstName, string lastName, decimal salary)
            {
                FirstName = firstName;
                LastName = lastName;
                Salary = salary;
            }
        }
    }
}
