namespace SympleFactory;

internal class PizzaMussarela : Pizza
{
    public PizzaMussarela()
    {
        Name = "Mussarela";
    }

    public override void Cook(int time)
    {
        Console.WriteLine($"Pizza {Name} is cooking!");
    }

    public override void Pack()
    {
        Console.WriteLine($"Pizza {Name} is packing!");
    }

    public override void Prepare()
    {
        Console.WriteLine($"Pizza {Name} is preparing!");
    }
}