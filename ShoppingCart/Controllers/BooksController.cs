using System.Collections.Generic;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService=new BookService();

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();
            return PartialView(AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books));
        }

        public ActionResult Index(int categoryId)
        {
            var books = _bookService.GetByCategoryId(categoryId);
            ViewBag.SelectedCategoryId = categoryId;
            return View(AutoMapper.Mapper.Map<List<Book>, List<BookViewModel>>(books));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}