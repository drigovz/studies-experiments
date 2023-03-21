using System;
using System.Collections.Generic;
using System.Globalization;
using ShapeAreas.Entities;
using ShapeAreas.Entities.Enums;

namespace ShapeAreas
{
    class Program
    {
        static void Main(string[] args)
        {
            Color color;
            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Shape #{ i } data: ");
                Console.Write("Rectangle os Circle (r/c)? ");
                char typeShape = char.Parse(Console.ReadLine());

                if (typeShape == 'r')
                {
                    Console.Write("Color (Black/Blue/Red): ");
                    color = Enum.Parse<Color>(Console.ReadLine());

                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Color (Black/Blue/Red): ");
                    color = Enum.Parse<Color>(Console.ReadLine());

                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Circle(radius, color));
                }
            }

            Console.WriteLine("\nSHAPE AREAS");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
