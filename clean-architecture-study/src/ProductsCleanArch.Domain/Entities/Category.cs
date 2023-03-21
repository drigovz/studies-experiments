using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProductsCleanArch.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; } = new Collection<Product>();

        public Category(int id, string name)
        {
            //ValidateId(id);
            //ValidateCategory(name);

            Id = id;
        }

        public Category(string name)
        {
            //ValidateCategory(name);

            Name = name;
        }

        public void UpdateCategory(int id, string name)
        {
            //ValidateId(id);
            //ValidateCategory(name);
        }

        //private void ValidateCategory(string name)
        //{
        //    DomainExceptionValidation.Validate(string.IsNullOrEmpty(name), "Name is required!");
        //    DomainExceptionValidation.Validate(name.Length <= 2, "Name need more than 2 chars!");
        //}

        //private void ValidateId(int id)
        //{
        //    DomainExceptionValidation.Validate(id <= 0, "Invalid Id!");
        //}
    }
}