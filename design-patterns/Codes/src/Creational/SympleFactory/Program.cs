using SympleFactory;

Console.WriteLine("Select Type of Pizza!\n(C) Calabreza \n(M) Mussarela");

var selectedPizza = Console.ReadLine().ToUpper();

Pizza pizza = PizzaSimpleFactory.Create(selectedPizza);
pizza.Prepare();
pizza.Cook(30);
pizza.Pack();

Console.ReadKey();