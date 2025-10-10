using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "CategoryId")]
    public partial class ProductCategoriesViewModel : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private int categoryId;

        [ObservableProperty]
        private string categoryName = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Product> products = new();

        public ProductCategoriesViewModel(IProductService productService)
        {
            _productService = productService;
        }

        partial void OnCategoryIdChanged(int value)
        {
            LoadProductsByCategory(value);
        }

        private void LoadProductsByCategory(int categoryId)
        {
            var result = _productService
                .GetAll()
                .Where(p => p.CategoryId == categoryId)
                .ToList();

            Products = new ObservableCollection<Product>(result);

            if (Products.Any())
                CategoryName = Products.First().CategoryName;
            else
                CategoryName = "Geen producten gevonden";
        }
    }
}
