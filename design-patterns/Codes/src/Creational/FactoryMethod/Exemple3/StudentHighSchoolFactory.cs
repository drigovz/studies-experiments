namespace FactoryMethod.Exemple3;

class StudentHighSchoolFactory : StudentFactory
{
    private string _name;
    private int _age;

    public StudentHighSchoolFactory(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public override Student GetStudent() =>
        new StudentHighSchool(_name, _age);
}