using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Category : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int id, string name) : base(id, name)
        {
            Id = id;
            Name = name;
        }
    }
}