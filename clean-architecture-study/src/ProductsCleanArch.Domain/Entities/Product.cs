using ProductsCleanArch.Domain.Validations;

namespace ProductsCleanArch.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Id = id;

            EntityValidation(this, new ProductValidator());
        }

        public Product(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;

            EntityValidation(this, new ProductValidator());
        }

        public void UpdateProduct(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            CategoryId = categoryId;

            EntityValidation(this, new ProductValidator());
        }
    }
}
