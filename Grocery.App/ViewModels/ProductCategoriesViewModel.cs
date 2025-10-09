using Grocery.Core.Interfaces.Services;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public class ProductCatagoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<ProductCategory> ProductCatagories { get; set; }

        public ProductCatagoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            ProductCatagories = [];
        }
    }
}