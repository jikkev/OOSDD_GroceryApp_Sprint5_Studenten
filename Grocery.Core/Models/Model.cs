using CommunityToolkit.Mvvm.ComponentModel;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public abstract partial class Model : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        private string name;

        protected Model() { } 

        protected Model(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
