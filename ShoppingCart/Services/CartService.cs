using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CartService:IDisposable
    {
        private readonly ShoppingCartContext _shoppingCartContext=new ShoppingCartContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = _shoppingCartContext.Carts.Include("CartItems")
                .SingleOrDefault(item => item.SessionId == sessionId);
            cart = CreateCartIfItDoesntExist(sessionId, cart);
            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (cart == null)
            {
                cart=new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                _shoppingCartContext.Carts.Add(cart);
                _shoppingCartContext.SaveChanges();
            }
            return cart;
        }

        public void Dispose()
        {
            _shoppingCartContext.Dispose();
        }
    }
}