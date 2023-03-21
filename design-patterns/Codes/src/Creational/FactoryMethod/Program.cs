using FactoryMethod.Exemple3;

Console.WriteLine("Insert type of student: ");
int type = Convert.ToInt32(Console.ReadLine());

StudentFactory? factory = type switch
{
    1 => new StudentBasicFactory("Student Basic Exemple", 10),
    2 => new StudentHighSchoolFactory("Student High School Exemple", 15),
    3 => new StudentBasicFactory("Student Exemple University", 19),
    _ => null
};

Student student = factory.GetStudent();
Console.WriteLine(student.ToString());

Console.ReadKey();