using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.ViewModels
{
    public class CommentView
    {
        //[Required]
        public Comments comments { get; set; }
        public int frind { get; set; }
    }
}