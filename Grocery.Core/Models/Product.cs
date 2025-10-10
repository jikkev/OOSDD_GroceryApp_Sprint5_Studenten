using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        private int stock;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private DateOnly shelfLife;

        [ObservableProperty]
        private int categoryId;

        [ObservableProperty]
        private string categoryName = string.Empty;

        public Product() { }

        public Product(int id, string name, int stock, DateOnly shelfLife, decimal price)
            : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }

        public Product(int id, string name, int stock, DateOnly shelfLife, decimal price, int categoryId, string categoryName)
            : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Product(int id, string name, int stock)
            : this(id, name, stock, default, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife)
            : this(id, name, stock, shelfLife, default) { }

        public override string ToString()
        {
            return $"{Name} - {Stock} op voorraad - € {Price}";
        }
    }
}
