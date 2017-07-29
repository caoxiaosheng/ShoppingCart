using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers.Api
{
    public class CartItemsController : ApiController
    {
        private readonly CartItemService _cartItemService=new CartItemService();

        public CartItemViewModel Post(CartItemViewModel cartItemViewModel)
        {
            var newCartItem =
                _cartItemService.AddToCart(AutoMapper.Mapper.Map<CartItemViewModel, CartItem>(cartItemViewModel));
            return AutoMapper.Mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
