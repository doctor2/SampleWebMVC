using LessonProject.Models.Info;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 3;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        //[HttpPost]
        public RedirectToRouteResult ToListPost()
        {
            var categories = repository.Products;
            List<string> categor = new List<string>();
            string filterDiscr = string.Empty;
            foreach (var categ in repository.Products
                .Select(x => x.CategoryUrl)
                .Distinct()
                .OrderBy(x => x))
            {
                if (Request.Form[categ] != null && Request.Form[categ] == "true,false")
                {
                    categor.Add(categ);
                    filterDiscr += categ + "_or_";
                }
            }
            if (filterDiscr!="")
            {
                filterDiscr = filterDiscr.Remove(filterDiscr.Length - 4);
            }       
            return RedirectToAction("ListWithFilter", new { filterDiscr });
        }

        [HttpGet]
        public ViewResult ListWithOtherPage( int page = 1)
        {
            var data = new PageableData<Product>(repository.Products.ToList(), page, PageSize);
            return View(data);
        }

        public ViewResult ListWithFilter(string filterDiscr = "",int page = 1)
        {
            var categories = repository.Products;
            if (filterDiscr!="")
            {
                List<string> categor = new List<string>();
                foreach (var word in Regex.Split(filterDiscr, "_or_"))
                {
                    categor.Add(word);
                }
                ViewBag.FilterDiscr = filterDiscr;
                categories = categories.Where(e => categor.Contains(e.CategoryUrl));
            }           
            var data = new PageableData<Product>(categories.ToList(), page, PageSize);
            return View(data);
        }
        //GET: Product
        public ViewResult List(string category, int page = 1)
        {
            //return View(repository.Products
            //.OrderBy(p => p.ProductID)
            //.Skip((page - 1) * PageSize)
            //.Take(PageSize));
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                                            .Where(p => category == null || p.CategoryUrl == category)
                                            .OrderBy(p => p.ProductID)
                                            .Skip((page - 1) * PageSize)
                                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()
                    TotalItems = category == null ?
                                        repository.Products.Count() :
                                        repository.Products.Where(e => e.CategoryUrl == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}