using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CategoryService:IDisposable
    {
        private readonly ShoppingCartContext _shoppingCartContext=new ShoppingCartContext();

        public List<Category> Get()
        {
            return _shoppingCartContext.Categories.OrderBy(item => item.Name).ToList();
        }

        public void Dispose()
        {
            _shoppingCartContext.Dispose();
        }
    }
}