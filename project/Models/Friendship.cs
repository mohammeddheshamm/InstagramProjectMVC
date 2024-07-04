using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace project.Models
{
    public class Friendship
    {
        public int ID { get; set; }
        public User user1 { get; set; }
        public int user1id { get; set; }
        public User user2 { get; set; }
        public int user2id { get; set; }
        public bool Friend { get; set; }
    }
}