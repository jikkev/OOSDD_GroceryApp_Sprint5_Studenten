using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            Products = [];
            foreach (Product p in _productService.GetAll())
            {
                System.Diagnostics.Debug.WriteLine($"{p.Name}: €{p.Price}");
                Products.Add(p);
            }
            //foreach (Product p in _productService.GetAll()) Products.Add(p);
        }
    }
}
