using System;
using System.Globalization;
using ComposicaoDeObjetos.Entities;
using ComposicaoDeObjetos.Entities.Enums;

namespace ComposicaoDeObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(departmentName);
            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("How many contracts to this worker? ");
            int contracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < contracts; i++)
            {
                Console.WriteLine($"Enter #{ i } contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(hourContract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = Convert.ToInt32(monthAndYear.Substring(0, 2));
            int year = Convert.ToInt32(monthAndYear.Substring(3));

            Console.WriteLine($"Name: { worker.Name }\nDepartment: { worker.Department.Name }\nIncome for { monthAndYear }: { worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture) }");
        }
    }
}
