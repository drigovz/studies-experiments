using AbstractFactory.Exemple2.Interfaces;

namespace AbstractFactory.Exemple2.Products;

internal class CoffeTable : ICoffeTable 
{
    public void Eat(string familyName)
    {
        Console.WriteLine($"People sit on coffe table of family {familyName} to eat");
    }
}