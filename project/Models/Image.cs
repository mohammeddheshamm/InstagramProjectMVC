using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public User user { get; set; }
        public int userid { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }
    }
}