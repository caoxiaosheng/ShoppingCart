using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using ShoppingCart.DAL;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(item =>
            {
                item.CreateMap<Cart, CartViewModel>();
                item.CreateMap<CartItem, CartItemViewModel>();
                item.CreateMap<Book, BookViewModel>();
                item.CreateMap<Author, AuthorViewModel>();
                item.CreateMap<Category, CategoryViewModel>();

                item.CreateMap<CartItemViewModel, CartItem> ();
                item.CreateMap< BookViewModel, Book > ();
                item.CreateMap<AuthorViewModel ,Author> ();
                item.CreateMap<CategoryViewModel, Category> ();
            });

            var dbContext=new ShoppingCartContext();
            Database.SetInitializer(new DataInitialization());
            dbContext.Database.Initialize(true);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("__MyAppSession",string.Empty);
        }
    }
}
