using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
{
    private readonly ICategoryService _categoryService;
    public ObservableCollection<Category> Categories { get; set; } = new();

    public CategoriesViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        Categories = [];
        foreach (Category p in _categoryService.GetAll()) Categories.Add(p);
    }
}
}