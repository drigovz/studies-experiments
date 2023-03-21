/*
    Fazer um programa para ler os dados de uma conta bancária e depois realizar um saque nesta conta, mostrando
    o novo saldo. 
    Um saque não pode ocorrer ou se não houver saldo na conta, ou se o valor do saque for superior ao 
    limite de saque da conta.
*/
using System;
using System.Globalization;
using BankAccount.Entities;
using BankAccount.Entities.Exceptions;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Withdraw limit: ");
                double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, balance, withdraw);

                Console.Write("\nEnter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account.Withdraw(amount);

                Console.WriteLine(account);
                Console.ReadKey();
            }
            catch (DomainException de)
            {
                Console.WriteLine("Withdraw error: " + de.Message);
                Console.ReadKey();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Format error: " + fe.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
