namespace FactoryMethod.Exemple3;

class StudentUniversityFactory : StudentFactory
{
    private string _name;
    private int _age;

    public StudentUniversityFactory(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public override Student GetStudent() =>
        new StudentUniversity(_name, _age);
}