using AbstractFactory.Interfaces;

namespace AbstractFactory.ConcreteProducts;

internal class WindowsButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Paint a Windows Button");
    }
}
