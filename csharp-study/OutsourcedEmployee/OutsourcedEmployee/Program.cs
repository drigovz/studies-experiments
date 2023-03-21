/**
 * Uma empresa possui funcionários próprios e terceirizados.
 * Para cada funcionário, deseja-se registrar nome, horas trabalhadas e valor por hora.
 * Funcionários terceirizados possuem ainda uma despesa adicional.
 * 
 * O pagamento dos funcionários correspondentes ao valor da hora multiplicado pelas horas
 * trabalhadas, sendo que os funcionários terceirizados ainda recebem um bônus correspondente
 * a 110% de sua despesa adicional.
 * 
 * Faça um programa para ler os dados de N funcionários e armazená-los em uma lista. Depois
 * de ler todos os dados, mostrar nome e pagamento de cada funcionário na mesma ordem em que 
 * foram digitados.
*/

using OutsourcedEmployeeExemple.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OutsourcedEmployeeExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int hours;
            double valuePerHour;

            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{ i } data:");
                Console.Write("Outsourced (y/n) ? ");
                char response = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                name = Console.ReadLine();

                Console.Write("Hours: ");
                hours = int.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (response == 'n')
                {
                    employees.Add(new Employee(name, hours, valuePerHour));
                }
                else
                {
                    Console.Write("Additional charge: ");
                    double aditionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employees.Add(new OutsourcedEmployee(name, hours, valuePerHour, aditionalCharge));
                }

                Console.WriteLine();
            }

            Console.WriteLine("PAYMENTS: ");

            foreach (Employee item in employees)
            {
                Console.WriteLine($"{ item.Name } - ${ item.Payment().ToString("F2", CultureInfo.InvariantCulture) }");
            }
        }
    }
}
