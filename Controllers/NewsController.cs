using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Logic;
using NewsPortal.Models;

namespace NewsPortal.Controllers
{
    public class NewsController : Controller
    {
       TopicManager _topics;
        NewsManager _news;
        public NewsController(TopicManager topicManager, NewsManager newsManager)
        {
            _topics = topicManager;
            _news = newsManager;
        }
        public IActionResult Index(int id)
        {
            var topics = _topics.GetAll();
            var news = _news.GetByCategory(id);
            
            var model = new NewsModel()
            {
                News = news,
                Topics = topics
            };

            return View(model);
        }
        public IActionResult Zina(int id)
        {
            var news = _news.GetWithTopic(id);

            return View(news);
        }
    }
}