namespace SympleFactory;

internal abstract class Pizza
{
    public string Name { get; set; }
    public abstract void Prepare();
    public abstract void Cook(int time);
    public abstract void Pack();
}