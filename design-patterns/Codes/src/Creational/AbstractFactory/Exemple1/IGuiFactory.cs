/*
 A interface fábrica abstrata declara um conjunto de métodos
 que retorna diferentes produtos abstratos. Estes produtos são chamados uma família e estão relacionados por um tema ou
 conceito de alto nível. Produtos de uma família são geralmente capazes de colaborar entre si. Uma família de
 produtos pode ter várias variantes, mas os produtos de uma variante são incompatíveis com os produtos de outro variante.
*/

using AbstractFactory.Interfaces;

namespace AbstractFactory;

internal interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}
