using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
namespace project.ViewModels
{
    public class GetComments
    {
        public User MainUser { get; set; }
        public IEnumerable<CommentsOfImage> commentsOfImages { get; set; }
    }
}