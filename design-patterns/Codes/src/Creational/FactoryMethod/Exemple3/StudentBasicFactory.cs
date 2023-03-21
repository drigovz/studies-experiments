namespace FactoryMethod.Exemple3;

class StudentBasicFactory : StudentFactory
{
    private string _name;
    private int _age;

    public StudentBasicFactory(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public override Student GetStudent() =>
        new StudentBasic(_name, _age);
}