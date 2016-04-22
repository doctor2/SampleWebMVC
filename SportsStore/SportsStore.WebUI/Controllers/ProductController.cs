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
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        [HttpGet]
        public ViewResult ListWithOtherPage( int page = 1)
        {
            //var Products = repository.Products
            //                                .Where(p => category == null || p.Category == category)
            //                                .OrderBy(p => p.ProductID)
            //                                .Skip((page - 1) * PageSize)
            //                                .Take(PageSize);
            var data = new PageableData<Product>(repository.Products.ToList(), page, 5);
            return View(data);
        }
        [HttpPost]
        public ViewResult ListWithOtherPagePost( )
        {
            int page = 1;
            var categories = repository.Products;
            List<string> categor = new List<string>();
            string filter = string.Empty;
            foreach (var categ in repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x))
            {
                if (Request.Form[categ] != null && Request.Form[categ] == "true,false")
                {
                    categor.Add(categ);
                    filter += categ + "_or_";
                }
            }
            ViewBag.FilterDiscr = filter.Remove(filter.Length-4);
            if (categor.Count > 0)
            {
                categories = categories.Where(e => categor.Contains(e.Category));
            }
            var data = new PageableData<Product>(categories.ToList(), page, 5);
            return View( data);
        }
        public ViewResult ListWithOtherPagePost(string filterDiscr,int page = 1)
        {
            var categories = repository.Products;
            List<string> categor = new List<string>();
            foreach (var word in Regex.Split(filterDiscr,"_or_"))
            {
                categor.Add(word);
            }
            ViewBag.FilterDiscr = filterDiscr;
            //foreach (var categ in repository.Products
            //    .Select(x => x.Category)
            //    .Distinct()
            //    .OrderBy(x => x))
            //{
            //    if (Request.Form[categ] != null && Request.Form[categ] == "true,false")
            //    {
            //        categor.Add(categ);
            //    }
            //}
            if (categor.Count > 0)
            {
                categories = categories.Where(e => categor.Contains(e.Category));
            }
            var data = new PageableData<Product>(categories.ToList(), page, 5);
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
                                            .Where(p => category == null || p.Category == category)
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
                                        repository.Products.Where(e => e.Category == category).Count()
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

        //public ViewResult List(string[] category, int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = repository.Products
        //                                    .Where(p => category == null || category.Contains(p.Category) )
        //                                    .OrderBy(p => p.ProductID)
        //                                    .Skip((page - 1) * PageSize)
        //                                    .Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            //TotalItems = repository.Products.Count()
        //            TotalItems = category == null ?
        //                                repository.Products.Count() :
        //                                repository.Products.Where(e => category.Contains(e.Category)).Count()
        //        },
        //        CurrentCategory = "Chess"
        //    };
        //    return View(model);
        //}
    }
}