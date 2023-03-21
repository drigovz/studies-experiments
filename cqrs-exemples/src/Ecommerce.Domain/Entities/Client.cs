using Ecommerce.Domain.Validations;

namespace Ecommerce.Domain.Entities
{
    public sealed class Client : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public Client(int id, string firstName, string lastName, string email)
        {
            Id = id;

            EntityValidation(this, new ClientValidator());
        }

        public Client(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            EntityValidation(this, new ClientValidator());
        }

        public void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            EntityValidation(this, new ClientValidator());
        }
    }
}
