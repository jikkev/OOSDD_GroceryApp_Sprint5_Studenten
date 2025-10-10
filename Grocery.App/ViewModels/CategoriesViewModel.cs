using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.App.Views;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Reflection.Metadata;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
{
    private readonly ICategoryService _categoryService;
    public ObservableCollection<Category> Categories { get; set; } = new();

    public CategoriesViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        Categories = [];
        foreach (Category p in _categoryService.GetAll()) Categories.Add(p);
    }

        [RelayCommand]
        
        public async Task SelectCategory(Category category)
        {
            if (category == null)
                return;

            try
            {
                await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}?CategoryId={category.Id}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation Exception: {ex}");
            }
        }

    }
}
