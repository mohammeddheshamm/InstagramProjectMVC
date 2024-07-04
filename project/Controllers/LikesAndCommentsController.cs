using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using project.ViewModels;
namespace project.Controllers
{
    public class LikesAndCommentsController : Controller
    {
        DbModel db = new DbModel();
        // GET: LikesAndComments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Likes(int imgid,int userid)
        {
            User user = db.Users.Single(x => x.ID == userid);
            var l = db.likes.Where(x => x.imageid == imgid && x.Like == true);
            List<User> ll = new List<User>();
            
         foreach(var i in l)
                {
              try
               {

                   User u = db.Users.Single(x => x.ID == i.userid);
                   ll.Add(u);
               }
           catch
             {
                       
             }
              }
            LikesAndDisLikes likes = new LikesAndDisLikes
            {
                user = user,
                friends = ll
            };
            
            return View(likes);
        }
        public ActionResult DisLikes(int imgid, int userid)
        {
            User user = db.Users.Single(x => x.ID == userid);
            var l = db.likes.Where(x => x.imageid == imgid && x.Like == false);
            List<User> ll = new List<User>();

            foreach (var i in l)
            {
                try
                {

                    User u = db.Users.Single(x => x.ID == i.userid);
                    ll.Add(u);
                }
                catch
                {

                }
            }
            LikesAndDisLikes Dislikes = new LikesAndDisLikes
            {
                user = user,
                friends = ll
            };

            return View(Dislikes);
        }
       
        public ActionResult Comments(int imgid, int userid)
        {
            List<CommentsOfImage> commentsOfImages = new List<CommentsOfImage>();
            var l = db.comments.Where(x => x.imageid == imgid);
            foreach(var i in l)
            {
                User us = db.Users.Single(x => x.ID == i.userid);
                CommentsOfImage c = new CommentsOfImage
                {
                    user = us, comment = i
                };
                commentsOfImages.Add(c);
            }
            GetComments getComments = new GetComments
            {
                MainUser = db.Users.Single(x => x.ID == userid),
                commentsOfImages = commentsOfImages
            };
            return View(getComments);
        }
    }
}