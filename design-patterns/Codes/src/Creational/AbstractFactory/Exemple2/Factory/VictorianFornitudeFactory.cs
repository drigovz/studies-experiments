using AbstractFactory.Exemple2.Interfaces;
using AbstractFactory.Exemple2.Products;

namespace AbstractFactory.Exemple2.Factory;

internal class VictorianFornitudeFactory : IFornitudeFactory
{
    public string FornitudeFamily() =>
        "Victorian Fornitude";

    public IChair CreateChair() =>
        new Chair();

    public ICoffeTable CreateCoffeTable() =>
        new CoffeTable();

    public ISofa CreateSofa() =>
        new Sofa();
}