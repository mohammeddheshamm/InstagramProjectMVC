using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.ViewModels
{
    public class SearchModelView
    {
        public User user { get; set; }
        public IEnumerable<User> SerachUsers { get; set; }
    }
}