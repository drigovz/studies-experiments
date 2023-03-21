using System;

namespace BankAccount.Entities.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {            
        }
    }
}