/*
 * Classe concreta do cliente que irá usar o factory
 */
using AbstractFactory.Exemple2.Interfaces;

namespace AbstractFactory.Exemple2;

internal class CreateFornitude
{
    private readonly IFornitudeFactory _factory;
    private IChair _chair;
    private ICoffeTable _coffeTable;
    private ISofa _sofa;

    public CreateFornitude(IFornitudeFactory factory)
    {
        _factory = factory;
    }

    public void Create()
    {
        _chair = _factory.CreateChair();
        _coffeTable = _factory.CreateCoffeTable();
        _sofa = _factory.CreateSofa();
    }

    public void Paint()
    {
        string family = _factory.FornitudeFamily();
        
        _chair.HasLegs(family);
        _chair.SitOn(family);
        _coffeTable.Eat(family);
        _sofa.SitOn(family);
    }
}