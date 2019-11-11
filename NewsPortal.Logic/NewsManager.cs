using NewsPortal.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Logic
{
    public class NewsManager
    {
        NewsPortalDB _db;
        public NewsManager(NewsPortalDB db)
        {
            _db = db;
        }
        public List<News> GetAll()
        {
            var news = _db.News
                .OrderByDescending(i => i.CreatedOn)
                .Take(10)
                .ToList();
            return news;
        }
        public List<News>GetByCategory(int categoryId)
        {
            var news = _db.News.Where(u => u.CategoryId == categoryId).ToList();
            return news;
        }
        public News GetWithTopic(int id)
        {
            var data = _db.News
               .Where(a => a.Id == id)
               .Join(_db.Topics, a => a.CategoryId, c => c.Id, (a, c) => new { News = a, Topic = c }).FirstOrDefault();

            data.News.Topic = data.Topic;

            return data.News;
        }
        public News Get(int id)
        {
            var news = _db.News.FirstOrDefault(u => u.Id == id);
            return news;
        }
    }
}
