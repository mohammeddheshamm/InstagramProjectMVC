using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.ViewModels
{
    public class VisistFriend
    {
        public User MainUser { get; set; }
        public User Friend { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string comment { get; set; }
    }
}