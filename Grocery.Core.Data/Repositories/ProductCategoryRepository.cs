using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            var products = new ProductRepository().GetAll();

            productCategories = new List<ProductCategory>
            {
                new ProductCategory { Id = 1, ProductId = 1, CategoryId = 2, Product = products.First(p => p.Id == 1) },
                new ProductCategory { Id = 2, ProductId = 2, CategoryId = 2, Product = products.First(p => p.Id == 2) },
                new ProductCategory { Id = 3, ProductId = 3, CategoryId = 1, Product = products.First(p => p.Id == 3) },
                new ProductCategory { Id = 4, ProductId = 4, CategoryId = 3, Product = products.First(p => p.Id == 4) }
            };
        }

        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            productCategories.Add(item);
            return item;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? ProductCategory = productCategories.FirstOrDefault(p => p.Id == item.Id);
            if (ProductCategory == null) return null;
            ProductCategory.Id = item.Id;
            return ProductCategory;
        }

    }
}