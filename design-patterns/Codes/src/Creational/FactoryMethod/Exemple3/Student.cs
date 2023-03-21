namespace FactoryMethod.Exemple3;

abstract class Student
{
    public StudentType Type { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString() =>
        $"Student: {Name}\n Is: {Type}\n Have: {Age} years old";
}
