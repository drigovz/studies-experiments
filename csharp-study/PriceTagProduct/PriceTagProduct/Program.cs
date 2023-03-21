/**
 * Fazer um programa para ler os dados de N produtos. E ao final, mostrar a etiqueta de 
 * preço de cada produto na mesma ordem em que foram digitados.
 * 
 * Todo produto possui nome e preço. Produtos importados possuem uma taxa de alfândega,
 * e produtos usados possuem data de fabricação. Estes dados específicos devem ser acrescentados
 * na etiqueta de preço. Para produtos importados, a taxa e alfândega deve ser acrescentada ao preço final do produto.
 */
using PriceTagProduct.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PriceTagProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{ i } data: ");
                Console.Write("Commom, Used or Imported (c/u/i): ");
                char option = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (option)
                {
                    case 'c':
                        products.Add(new Product(name, price));
                        break;
                    case 'u':
                        Console.Write("Manufactured date (DD/MM/YYYY): ");
                        DateTime manufacturedDate = DateTime.Parse(Console.ReadLine());
                        products.Add(new UsedProduct(name, price, manufacturedDate));
                        break;
                    case 'i':
                        Console.Write("Customs fee: ");
                        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        products.Add(new ImportedProduct(name, price, customsFee));
                        break;
                    default:
                        Console.WriteLine("Option not valid!");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("PRICE TAGS: ");
            foreach (Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
