/*
 * As fábricas concretas produzem uma família de produtos que pertencem a uma única variante. 
 * A fábrica garante que os produtos resultantes sejam compatíveis. 
 * Assinaturas dos métodos fabrica retornam um produto abstrato, 
 * enquanto que dentro do método um produto concreto é instanciado.
 */
using AbstractFactory.Interfaces;

namespace AbstractFactory;

internal class CreateUi
{
    private readonly IGuiFactory _factory;
    private IButton _button;
    private ICheckbox _checkbox;

    public CreateUi(IGuiFactory factory)
    {
        _factory = factory;
    }

    public void Create()
    {
        _button = _factory.CreateButton();
        _checkbox = _factory.CreateCheckbox();
    }

    public void Paint()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}
