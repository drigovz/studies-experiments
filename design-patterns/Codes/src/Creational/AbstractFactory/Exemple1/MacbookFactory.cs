using AbstractFactory.ConcreteProducts;
using AbstractFactory.Interfaces;

namespace AbstractFactory;

internal class MacbookFactory : IGuiFactory
{
    public IButton CreateButton()
    {
        return new MacbookButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacbookCheckbox();
    }
}
