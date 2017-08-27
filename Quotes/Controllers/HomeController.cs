using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quotes.Models;
using Quotes.DAL;

namespace Quotes.Controllers
{
    public class HomeController : Controller
    {
        private DataAccessLayer database = new DataAccessLayer();

        private List<Quote> quotes = new List<Quote>();
        private List<Category> categoriesList = new List<Category>();
        private Dictionary<int, string> categoriesDict = new Dictionary<int, string>();

        private static String _filterByAuthor = "";
        private static int _filterByCategory = 0;
        private static bool _filter = false;

        public ActionResult Index()
        {
            getData();
            ViewBag.categoriesList = categoriesList;
            ViewBag.categoriesDict = categoriesDict;
            ViewBag.filterByAuthor = _filterByAuthor;
            ViewBag.filterByCategory = _filterByCategory;
            ViewBag.filter = _filter;
            return View(quotes);
        }

        [HttpPost]
        public RedirectToRouteResult Index(string filterByAuthor, int filterByСategory = 0, bool filter = false) {
            _filterByAuthor = filterByAuthor;
            _filterByCategory = filterByСategory;
            _filter = filter;
            return RedirectToAction("Index");
        }
 

        [HttpGet]
        public ActionResult addQuote() {
            ViewBag.categories = database.getAllCategories();
            return View();
        }

        [HttpGet]
        public ActionResult editQuote(int quoteId)
        {
            ViewBag.categoriesList = database.getAllCategories();
            return View(database.getSingleQuote(quoteId));
        }

        //C
        [HttpPost]
        public RedirectToRouteResult addQuote(Quote q)
        {
            database.createQuote(q);
            return RedirectToAction("index");
        }

        public RedirectToRouteResult addCat(string name)
        {
            database.createCategory(name);
            return RedirectToAction("index");
        }

        //R
        private void getData()
        {
            quotes.Clear();
            categoriesList.Clear();
            categoriesDict.Clear();

            if (_filter) {
                quotes.AddRange(database.getFilteredQuotes(_filterByAuthor, _filterByCategory));
            }
            else { quotes.AddRange(database.getAllQuotes()); }
            
            categoriesList.AddRange(database.getAllCategories());
            foreach (Category cat in categoriesList)
            {
                categoriesDict.Add(cat.id, cat.name);
            }
        }

        //U
        [HttpPost]
        public RedirectToRouteResult editQuote(Quote q)
        {
            database.updateQuote(q);
            return RedirectToAction("index");
        }

        public RedirectToRouteResult editCat(int selectedCategoryToEdit = 0, string newName = "name")
        {
            database.updateCategory(new Category(selectedCategoryToEdit, newName));
            return RedirectToAction("index");
        }

        //D
        public RedirectToRouteResult removeQuote(int quoteId)
        {
            database.deleteQuote(quoteId);
            return RedirectToAction("index");
        }

        public RedirectToRouteResult delCat(int selectedCategoryToDelete = 0)
        {
            database.deleteCategory(selectedCategoryToDelete);
            return RedirectToAction("index");
        }

    }
}