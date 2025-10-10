using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

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

        public Product() { }

        public Product(int id, string name, int stock, DateOnly shelfLife, decimal price)
            : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
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
