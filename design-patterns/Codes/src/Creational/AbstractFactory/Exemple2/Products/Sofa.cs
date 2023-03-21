using AbstractFactory.Exemple2.Interfaces;

namespace AbstractFactory.Exemple2.Products;

internal class Sofa : ISofa
{
    public void SitOn(string family)
    {
        Console.WriteLine($"People sit on sofa of family {family}");
    }
}