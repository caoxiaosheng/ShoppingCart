using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class BookService:IDisposable
    {
        private readonly ShoppingCartContext _shoppingCartContext=new ShoppingCartContext();

        public List<Book> GetFeatured()
        {
            return _shoppingCartContext.Books.Include("Author").Where(item => item.Featured).ToList();
        }

        public List<Book> GetByCategoryId(int categoryId)
        {
            return _shoppingCartContext.Books.Include("Author").Where(b => b.CategoryId == categoryId)
                .OrderByDescending(b => b.Featured).ToList();
        }

        public void Dispose()
        {
            _shoppingCartContext.Dispose();
        }
    }
}