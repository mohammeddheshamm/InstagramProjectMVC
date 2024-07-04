using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public User user { get; set; }
        public int userid { get; set; }
        public Image image { get; set; }
        public int imageid { get; set; }
        [Required]
        public string comment { get; set; }
    }
}