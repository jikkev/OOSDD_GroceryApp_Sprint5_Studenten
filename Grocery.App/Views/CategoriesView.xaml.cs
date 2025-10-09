using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class CategoriesView : ContentPage
    {
       public CategoriesView(CategoriesViewModel viewModel) 
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
