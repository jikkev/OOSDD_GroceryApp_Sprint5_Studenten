﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public decimal prijs;
        public DateOnly ShelfLife { get; set; }
        public Product(int id, string name, int stock) : this(id, name, stock, default, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife) : this(id, name, stock, shelfLife, default) { }
        public Product(int id, string name, int stock, DateOnly shelfLife, decimal prijs)
             : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Prijs = prijs;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - €{Prijs}";
        }
    }
}
