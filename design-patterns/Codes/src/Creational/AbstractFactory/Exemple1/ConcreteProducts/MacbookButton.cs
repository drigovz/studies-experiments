using AbstractFactory.Interfaces;

namespace AbstractFactory.ConcreteProducts;

internal class MacbookButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Paint a Macbook Button");
    }
}
