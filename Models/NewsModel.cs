using NewsPortal.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public class NewsModel
    {
        public List<News> News { get; set; }
        public List<Topic> Topics{ get; set; }
    }
}
