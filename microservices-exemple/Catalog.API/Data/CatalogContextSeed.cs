using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.API.Data
{
   public class CatalogContextSeed
   {
      public static void SeedData(IMongoCollection<Product> productCollection)
      {
         bool existsProduct = productCollection.Find(p => true).Any();
         if (!existsProduct)
            productCollection.InsertManyAsync(GetMyProducts());
      }

      private static IEnumerable<Product> GetMyProducts()
      {
         return new List<Product>()
            {
               new Product()
               {
                  Id = "602d2149e773f2a3990b47f5",
                  Name = "IPhone X",
                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                  Image = "product-1.png",
                  Price = 950.00M,
                  Category = "Smart Phone"
               },
               new Product()
               {
                  Id = "602d2149e773f2a3990b47f6",
                  Name = "Samsung 10",
                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                  Image = "product-2.png",
                  Price = 650.00M,
                  Category = "Smart Phone"
               },
               new Product()
               {
                  Id = "602d2149e773f2a3990b47fa",
                  Name = "Samsung 10",
                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                  Image = "product-3.png",
                  Price = 380.00M,
                  Category = "Home Kitchen"
               }
         };
      }
   }
}
