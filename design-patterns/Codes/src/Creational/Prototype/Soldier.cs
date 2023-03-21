namespace Prototype;

internal class Soldier : ICloneable
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public Accessory Accessories { get; set; }

    public Soldier()
    { }

    public Soldier(Soldier soldier)
    {
        Name = soldier.Name;
        Weapon = soldier.Weapon;
        Accessories = soldier.Accessories;
    }

    public object Clone() =>
        new Soldier(this);

    public object DeepClone()
    {
        Soldier soldier = (Soldier)MemberwiseClone();
        soldier.Accessories = (Accessory)Accessories.Clone();
        return soldier;
    }

    public override string ToString() =>
        $"\nName:    {Name} \nWeapon:  {Weapon} \nAcessory: {Accessories?.Name}";
}

internal class Accessory
{
    public string Name { get; set; }

    public object Clone() =>
       (Accessory)MemberwiseClone();
}