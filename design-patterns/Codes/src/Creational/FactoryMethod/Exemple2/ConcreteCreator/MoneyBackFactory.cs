namespace FactoryMethod.Exemple2;

public class MoneyBackFactory : CardFactory
{
    private int _creditLimit;
    private int _annualCharge;

    public MoneyBackFactory(int creditLimit, int annualCharge)
    {
        _creditLimit = creditLimit;
        _annualCharge = annualCharge;
    }

    public override CreditCard GetCreditCard() =>
        new MoneyBackCreditCard(_creditLimit, _annualCharge);
}