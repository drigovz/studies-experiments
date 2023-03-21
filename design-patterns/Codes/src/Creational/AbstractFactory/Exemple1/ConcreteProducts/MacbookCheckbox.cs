using AbstractFactory.Interfaces;

namespace AbstractFactory.ConcreteProducts;

internal class MacbookCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Paint a Macbook Checkbox");
    }
}
