using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
namespace project.ViewModels
{
    public class UserPageinfo
    {
        public User user { get; set; }
        public IEnumerable<Image> images { get; set; }
    }
}