using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Logic;
using NewsPortal.Models;

namespace NewsPortal.Controllers
{
    public class HomeController : Controller
    {

        private NewsManager _news;
        public HomeController(NewsManager newsManager)
        {
            _news = newsManager;
            //categoryManager tiek aizpildīts ar Dependency Injection
            //_categories ir pieejams visas klases ietvaros
        }
        public IActionResult Index()
        {
            var news = _news.GetAll();
            var model = new NewsModel()
            {
                News = news
            };
           
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Topics()
        {
          

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
