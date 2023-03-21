/*
 As fábricas concretas produzem uma família de produtos que
 pertencem a uma única variante. A fábrica garante que os
 produtos resultantes sejam compatíveis. Assinaturas dos
 métodos fabrica retornam um produto abstrato, enquanto que
 dentro do método um produto concreto é instanciado.
*/

using AbstractFactory.ConcreteProducts;
using AbstractFactory.Interfaces;

namespace AbstractFactory;

internal class WindowsFactory : IGuiFactory
{
    public IButton CreateButton() =>
        new WindowsButton();

    public ICheckbox CreateCheckbox() =>
        new WindowsCheckbox();
}