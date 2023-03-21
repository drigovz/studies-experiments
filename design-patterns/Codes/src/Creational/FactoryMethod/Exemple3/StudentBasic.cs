namespace FactoryMethod.Exemple3;

class StudentBasic : Student
{
    private StudentType _type;
    private string _name;
    private int _age;

    public StudentBasic(string name, int age)
    {
        _type = StudentType.Basic;
        _name = name;
        _age = age;
    }
}