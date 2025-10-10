﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        public List<ProductCategory> GetAll();

        public ProductCategory? Get(int id);

        public ProductCategory Add(ProductCategory item);

        public ProductCategory? Delete(ProductCategory item);

        public ProductCategory? Update(ProductCategory item);
    }
}