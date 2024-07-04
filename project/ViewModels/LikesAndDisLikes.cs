using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
namespace project.ViewModels
{
    public class LikesAndDisLikes
    {
        public User user { get; set; }
        public IEnumerable<User> friends { get; set; }
    }
}