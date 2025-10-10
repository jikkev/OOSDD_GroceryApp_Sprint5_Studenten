using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]
        private ObservableCollection<Product> uncategorizedProducts = new();

        public ProductCategoriesViewModel(IProductService productService)
        {
            _productService = productService;
            LoadUncategorizedProducts(); 
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
                CategoryName = "Categorie zonder producten";

            LoadUncategorizedProducts(); 
        }

        private void LoadUncategorizedProducts()
        {
            var uncategorized = _productService
                .GetAll()
                .Where(p => p.CategoryId == 0 || string.IsNullOrWhiteSpace(p.CategoryName))
                .ToList();

            UncategorizedProducts = new ObservableCollection<Product>(uncategorized);
        }

        [RelayCommand]
        private void SearchUncategorizedProducts(string query)
        {
            var allProducts = _productService
                .GetAll()
                .Where(p => p.CategoryId == 0 || string.IsNullOrWhiteSpace(p.CategoryName))
                .ToList();

            if (!string.IsNullOrWhiteSpace(query))
            {
                allProducts = allProducts
                    .Where(p => p.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            UncategorizedProducts = new ObservableCollection<Product>(allProducts);
        }

        [RelayCommand]
        private void AddProductToCategory(Product product)
        {
            if (product == null)
                return;

            product.CategoryId = CategoryId;
            product.CategoryName = CategoryName;

            UncategorizedProducts.Remove(product);
            Products.Add(product);
        }
    }
}
