namespace SympleFactory;

internal class PizzaSimpleFactory
{
    public static Pizza Create(string type)
    {
        Pizza pizza = type switch
        {
            "C" => new PizzaCalabreza(),
            "M" => new PizzaMussarela(),
            _ => throw new ApplicationException("Pizza not found!")
        };

        return pizza;
    }
}