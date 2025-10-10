using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        [ObservableProperty]
        private ObservableCollection<Category> categories = new();

        [ObservableProperty]
        private ObservableCollection<Category> filteredCategories = new();

        [ObservableProperty]
        private ObservableCollection<Product> products = new();

        [ObservableProperty]
        private Category? selectedCategory;

        [ObservableProperty]
        private string searchQuery = string.Empty;

        [ObservableProperty]
        private string myMessage = string.Empty;

        public CategoriesViewModel(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;

            var allCategories = _categoryService.GetAll().ToList();
            Categories = new ObservableCollection<Category>(allCategories);
            FilteredCategories = new ObservableCollection<Category>(allCategories);
        }

        [RelayCommand]
        private void SearchUncategorizedProducts(string query)
        {
            
            var allProducts = _productService.GetAll()
                .Where(p =>
                    p.CategoryId == 0 ||
                    string.IsNullOrWhiteSpace(p.CategoryName) ||
                    p.CategoryName.Equals("geen", StringComparison.OrdinalIgnoreCase))
                .ToList();

            
            if (!string.IsNullOrWhiteSpace(query))
            {
                var lower = query.ToLower();
                allProducts = allProducts
                    .Where(p => p.Name.ToLower().Contains(lower))
                    .ToList();
            }

            
            Products = new ObservableCollection<Product>(allProducts);

            
            if (Products.Count == 0)
                MyMessage = "Geen producten zonder categorie gevonden.";
            else
                MyMessage = $"Gevonden {Products.Count} producten zonder categorie.";
        }


        [RelayCommand]
        private void LoadProductsByCategory(int categoryId)
        {
            var productsFromCategory = _productService.GetByCategoryId(categoryId).ToList();
            Products = new ObservableCollection<Product>(productsFromCategory);

            if (Products.Count == 0)
                MyMessage = "Geen producten gevonden voor deze categorie.";
            else
                MyMessage = $"Producten geladen voor categorie '{SelectedCategory?.Name}'.";
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            if (category == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}?CategoryId={category.Id}");
        }


        [RelayCommand]
        private void AddCategory(Category category)
        {
            if (category == null)
                return;

            if (!Categories.Any(c => c.Id == category.Id))
            {
                Categories.Add(category);
                MyMessage = $"{category.Name} toegevoegd aan de lijst.";
            }
            else
            {
                MyMessage = $"{category.Name} bestaat al.";
            }

            FilteredCategories = new ObservableCollection<Category>(Categories);

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(3000);
                MyMessage = string.Empty;
            });
        }
    }
}
