namespace FactoryMethod.Exemple3;

class StudentUniversity : Student
{
    private StudentType _type;
    private string _name;
    private int _age;

    public StudentUniversity(string name, int age)
    {
        _type = StudentType.University;
        _name = name;
        _age = age;
    }
}