namespace FactoryMethod;

class ConcreteProduct1 : IProduct
{
    public string Operation() =>
        "{Result of ConcreteProduct1}";
}

class ConcreteProduct2 : IProduct
{
    public string Operation() =>
        "{Result of ConcreteProduct2}";
}