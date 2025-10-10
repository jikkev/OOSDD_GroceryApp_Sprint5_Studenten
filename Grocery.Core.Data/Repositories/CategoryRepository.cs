using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;
        public CategoryRepository()
        {
            categories = [
                new Category(1, "Brood"),
                new Category(2, "Zuivel"),
                new Category(3, "Ontbijt")];
        }
        public List<Category> GetAll()
        {
            return categories;
        }

        public Category? Get(int id)
        {
            return categories.FirstOrDefault(p => p.Id == id);
        }

        public Category Add(Category item)
        {
            categories.Add(item);
            return item;
        }

        public Category? Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(p => p.Id == item.Id);
            if (category == null) return null;
            category.Id = item.Id;
            return category;
        }
    }
}