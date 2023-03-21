namespace FactoryMethod.Exemple2;

public class PlatinumFactory : CardFactory
{
    private int _creditLimit;
    private int _annualCharge;

    public PlatinumFactory(int creditLimit, int annualCharge)
    {
        _creditLimit = creditLimit;
        _annualCharge = annualCharge;
    }

    public override CreditCard GetCreditCard() =>
        new PlatinumCreditCard(_creditLimit, _annualCharge);
}