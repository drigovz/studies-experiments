/*
 * As classes criadoras concretas herdam da classe criadora, e implementam o FactoryMethod,
 * retornando uma interface IProduct, que será comum a todos os produtos criados pelo FactoryMethod.
 */

namespace FactoryMethod;

class ConcreteCreator1 : Creator
{
    // método fábrica contendo toda a lógica para a criação dos objetos
    protected override IProduct FactoryMethod() =>
        new ConcreteProduct1();
}

class ConcreteCreator2 : Creator
{
    protected override IProduct FactoryMethod() =>
        new ConcreteProduct2();
}