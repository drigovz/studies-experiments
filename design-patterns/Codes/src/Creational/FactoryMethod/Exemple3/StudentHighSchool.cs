namespace FactoryMethod.Exemple3;

class StudentHighSchool : Student
{
    private StudentType _type;
    private string _name;
    private int _age;

    public StudentHighSchool(string name, int age)
    {
        _type = StudentType.HighSchool;
        _name = name;
        _age = age;
    }
}