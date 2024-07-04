using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Likes
    {
        public int ID { get; set; }
        public User user { get; set; }
        public int userid { get; set; }
        public Image image { get; set; }
        public int imageid { get; set; }
        public bool Like { get; set; }
    }
}