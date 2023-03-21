/*
 * Interface para a criação de mobília (fornitude)
 */
namespace AbstractFactory.Exemple2.Interfaces;

internal interface IFornitudeFactory
{
    string FornitudeFamily();
    IChair CreateChair();
    ICoffeTable CreateCoffeTable();
    ISofa CreateSofa();
}