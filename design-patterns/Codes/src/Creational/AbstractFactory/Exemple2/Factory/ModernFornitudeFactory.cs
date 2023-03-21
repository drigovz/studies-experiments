using AbstractFactory.Exemple2.Interfaces;
using AbstractFactory.Exemple2.Products;

namespace AbstractFactory.Exemple2.Factory;

internal class ModernFornitudeFactory : IFornitudeFactory
{
    public string FornitudeFamily() => 
        "Modern Fornitude";

    public IChair CreateChair() =>
        new Chair();

    public ICoffeTable CreateCoffeTable() =>
        new CoffeTable();

    public ISofa CreateSofa() =>
        new Sofa();
}