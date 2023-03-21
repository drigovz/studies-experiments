using AbstractFactory.Exemple2.Interfaces;

namespace AbstractFactory.Exemple2.Products;

internal class Chair : IChair
{
    public void HasLegs(string familyName)
    {
        Console.WriteLine($"The Chair of family {familyName} have four legs");
    }

    public void SitOn(string familyName)
    {
        Console.WriteLine($"The people sit on in the chairs of family {familyName}");
    }
}