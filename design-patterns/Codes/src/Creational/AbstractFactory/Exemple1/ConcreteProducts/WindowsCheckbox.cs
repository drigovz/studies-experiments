using AbstractFactory.Interfaces;

namespace AbstractFactory.ConcreteProducts;

internal class WindowsCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Paint a Windows Checkbox");
    }
}
