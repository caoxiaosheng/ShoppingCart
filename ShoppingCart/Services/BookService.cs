using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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

        public Book GetById(int id)
        {
            var books = _shoppingCartContext.Books.Include("Author").SingleOrDefault(item => item.Id == id);
            if (books == null)
            {
                throw new ObjectNotFoundException($"找不到Id为{id}的书");
            }
            return books;
        }

        public void Dispose()
        {
            _shoppingCartContext.Dispose();
        }
    }
}