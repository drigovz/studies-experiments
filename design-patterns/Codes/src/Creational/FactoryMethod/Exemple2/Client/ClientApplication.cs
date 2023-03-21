using FactoryMethod.Exemple2;

/*public static void Main()
{
    CardFactory factory = null;
    Console.Write("Enter the card type you would like to visit: ");
    string card = Console.ReadLine();

    switch (card.ToLower())
    {
        case "moneyback":
            factory = new MoneyBackFactory(50000, 0);
            break;
        case "titanium":
            factory = new TitaniumFactory(100000, 500);
            break;
        case "platinum":
            factory = new PlatinumFactory(500000, 1000);
            break;
        default:
            break;
    }

    CreditCard creditCard = factory.GetCreditCard();
    Console.WriteLine($"Card Type: {creditCard.CardType}\nCredit Limit: {creditCard.CreditLimit}\nAnnual Charge: {creditCard.AnnualCharge}");
    Console.ReadKey();
}*/