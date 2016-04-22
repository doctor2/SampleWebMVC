using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            foreach (var item in categories)
            {
                ViewBag[item] = false;
            }
            return PartialView(categories);
        }
        //[HttpGet]
        public PartialViewResult MenuWithCheckbox()
        {
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            // var categories = repository.Products
            //.Select(x => x.Category)
            //.Distinct()
            //.OrderBy(x => x).ToList()
            //.Select(x => Tuple.Create(x, false));
            //Request.QueryString["ReturnUrl"] = "Get";
            return PartialView(categories);
        }
        //[HttpPost]
        //public PartialViewResult MenuWithCheckbox()// IEnumerable<Tuple<string, bool>> categ
        //{
        //   // IEnumerable<string> categories = repository.Products
        //   // .Select(x => x.Category)
        //   // .Distinct()
        //   // .OrderBy(x => x);
        //   // categ = repository.Products
        //   //.Select(x => x.Category)
        //   //.Distinct()
        //   //.OrderBy(x => x)
        //   //.Select(x =>Tuple.Create(x, false)) ;
        //    //Request.QueryString["ReturnUrl"] = "Post";
        //    //foreach (var item in categories)
        //    //{
        //    //    ViewBag[item] = (Request.Form[item] ?? string.Empty).Contains("true");
        //    //}
        //    return PartialView(categ);
        //    //return PartialView(categories);
        //}
    }
}