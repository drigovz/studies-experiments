using AbstractFactory.Exemple2.Factory;
using AbstractFactory.Exemple2.Interfaces;

namespace AbstractFactory.Exemple2;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Select type of fornitude: \nM - Modern Fornitude \nV - Victorian Family :");
        string fornitudeSelected = Console.ReadLine().ToUpper();

        IFornitudeFactory factory = fornitudeSelected switch
        {
            "M" => new ModernFornitudeFactory(),
            "V" => new VictorianFornitudeFactory(),
            _ => throw new Exception("Fornitude not found"),
        };

        CreateFornitude fornitude = new(factory);
        fornitude.Create();
        fornitude.Paint();

        Console.ReadKey();
    }
}