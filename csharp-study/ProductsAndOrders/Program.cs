/**
    Ler os dados de um pedido com N itens (N fornecido pelo usuário). Depois, mostrar um sumário
    do pedido. 
    Nota: O instante do pedido deve ser o instante do sistema.
*/
using System;
using System.Globalization;
using ProductsAndOrders.Entities;
using ProductsAndOrders.Entities.Enums;

namespace ProductsAndOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);

            Console.WriteLine("\nEnter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("How many items ti this order? ");
            int numberItems = int.Parse(Console.ReadLine());
            Order order = new Order(DateTime.Now, status, client);

            for (int i = 0; i < numberItems; i++)
            {
                Console.WriteLine($"\nEnter #{ i + 1 } item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantity, productPrice, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
            Console.ReadKey();
        }
    }
}
