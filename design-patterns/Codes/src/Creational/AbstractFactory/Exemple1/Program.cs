/*
using AbstractFactory;

Console.WriteLine("Enter the system: \n(W)indows \n(M)acbook:");
var os = Console.ReadLine()?.ToUpper();

IGuiFactory factory = os switch
{
    "W" => new WindowsFactory(),
    "M" => new MacbookFactory(),
    _ => throw new Exception("Error! Unknown operating system.")
};

CreateUi app = new(factory);
app.Create();
app.Paint();

Console.ReadKey();
*/
