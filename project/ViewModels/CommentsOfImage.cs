using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
namespace project.ViewModels
{
    public class CommentsOfImage
    {
        public User user { get; set; }
        public Comments comment { get; set; }
    }
}