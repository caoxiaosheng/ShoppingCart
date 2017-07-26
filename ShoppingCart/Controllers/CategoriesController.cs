using System.Collections.Generic;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private  readonly  CategoryService _categoryService=new CategoryService();
        
        public ActionResult Menu(int selectedcategoryid)
        {
            var categories = _categoryService.Get();
            ViewBag.SelectedCategoryId = selectedcategoryid;
            return PartialView(AutoMapper.Mapper.Map<List<Category>, List<CategoryViewModel>>(categories));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}