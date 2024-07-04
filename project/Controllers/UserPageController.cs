using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using project.Models;
using project.ViewModels;
namespace project.Controllers
{
    public class UserPageController : Controller
    {
        DbModel db = new DbModel();
        // GET: UserPage
        public ActionResult Index(User user)
        {
            var images = db.images.Where(c => c.userid == user.ID);
            UserPageinfo pageinfo = new UserPageinfo { user = user,images=images };
            return View(pageinfo);
        }

       

        /////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = db.Users.Single(c => c.ID == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            if (user.imageFile != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(user.imageFile.FileName);
                string extensions = Path.GetExtension(user.imageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                user.Image = "/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
                user.imageFile.SaveAs(fileName);
            }

            var userDB = db.Users.Single(c => c.ID == user.ID);
            userDB.ID = user.ID;
            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            if(user.Image!=null)
            {
              userDB.Image = user.Image;
            }
            userDB.Mobile = user.Mobile;
            userDB.Email = user.Email;
            userDB.Gender = user.Gender;
            userDB.Password = user.Password;
            userDB.RePassword = user.Password;
            db.SaveChanges();
            return RedirectToAction("Index",userDB);

        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            Image image = new Image();

            return View(image);
        }

        [HttpPost]
        public ActionResult Create(Image image)
        {
            image.userid = image.ID;
             image.ID=0;
            string fileName = Path.GetFileNameWithoutExtension(image.imageFile.FileName);
            string extensions = Path.GetExtension(image.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
            image.image = "/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
            image.imageFile.SaveAs(fileName);
            using (DbModel db = new DbModel())
            {
                db.images.Add(image);
                db.SaveChanges();
            }
            User user = db.Users.Single(c => c.ID == image.userid);
            return RedirectToAction("Index", user);
        }
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        public ActionResult Search(int id)
        {
            User user = db.Users.Single(x => x.ID == id);
            var userslist = db.Users.Where(x => x.ID != id).ToList();
           foreach(var i in userslist)
            {
                if(db.Friendships.Single(x=>x.user1id==i.ID)!=null)
                {
                    userslist.Remove(i);
                }
            }
            SearchModelView searchModelview = new SearchModelView
            {
                user = user,
                SerachUsers=userslist
                //SerachUsers = db.Users.Where(x=>x.ID!=id).ToList()
            };
            return View(searchModelview);
        }
        [HttpGet]
        public async Task<ActionResult> Search(string usersearch,int id)
        {
            User user = db.Users.Single(x => x.ID == id);
            ViewData["userserach"] = usersearch;
            var emptquery = from x in db.Users.Where(x=>x.ID!=id) select x;
          
            if (!string.IsNullOrEmpty(usersearch))
            {
                emptquery = emptquery.Where(x => x.FirstName.Contains(usersearch) || x.LastName.Contains(usersearch) ||
                  x.Email.Contains(usersearch));
            }
            SearchModelView searchModelview = new SearchModelView
            {
                user = user,
                SerachUsers = await emptquery.AsNoTracking().ToListAsync()
            };
            var ll = searchModelview.SerachUsers.ToList();
            List<User> users = new List<User>();
            foreach(var i in ll)
            {
                try
                {

                    var y = db.Friendships.Single(x => x.user1id == id && x.user2id == i.ID);
                    
                }
                catch(Exception e)
                {
                    users.Add(i);
                }
            }
            searchModelview.SerachUsers = users;
            return View(searchModelview);
        }
        public ActionResult AddFriend(int id,int id2)
        {
            User us1 = db.Users.Single(x => x.ID == id);
            User us2 = db.Users.Single(x => x.ID == id2);
            Friendship friendship = new Friendship
            {
                user1id = us2.ID,
                user2id = us1.ID,
                Friend = false
            };
            db.Friendships.Add(friendship);
            db.SaveChanges();
            return RedirectToAction("Search", new { id = id2 });
        }
        ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////
        public ActionResult FriendsRequests(int id)
        {
            User user = db.Users.Single(c => c.ID == id);
            var idlist = db.Friendships.Where(x => x.user2id == id&&x.Friend==false);
            List<User> ts = new List<User>();
            foreach(var i in idlist)
            {
                ts.Add(db.Users.Single(x => x.ID == i.user1id));
            }
            SearchModelView searchModelView = new SearchModelView
            {
                user = user,
                SerachUsers = ts
            };
            return View(searchModelView);
        }

        ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////
        ///
        public ActionResult Accept(int id,int id2)
        {
            User user = db.Users.Single(x => x.ID == id);
            Friendship friendship = db.Friendships.Single(x => x.user1id == id2 && x.user2id == id);
            friendship.Friend = true;
            db.SaveChanges();
            return RedirectToAction("FriendsRequests",new { id = id });
        }
        public ActionResult Reject(int id, int id2)
        {
            User user = db.Users.Single(x => x.ID == id);
            Friendship friendship = db.Friendships.Single(x => x.user1id == id2 && x.user2id == id);
            db.Friendships.Remove(friendship);
            db.SaveChanges();
            return RedirectToAction("FriendsRequests", new { id = id });
        }
        /////////////////////////////////////////////////////
        ///////////////////////////////////////////////
        ///
        public ActionResult Following(int id)
        {
            User user = db.Users.Single(c => c.ID == id);
            var idlist = db.Friendships.Where(x => x.user1id == id && x.Friend == true);
            List<User> ts = new List<User>();
            foreach (var i in idlist)
            {
                ts.Add(db.Users.Single(x => x.ID == i.user2id));
            }
            SearchModelView searchModelView = new SearchModelView
            {
                user = user,
                SerachUsers = ts
            };
            return View(searchModelView);
        }
        public ActionResult Followers(int id)
        {
            User user = db.Users.Single(c => c.ID == id);
            var idlist = db.Friendships.Where(x => x.user2id == id && x.Friend == true);
            List<User> ts = new List<User>();
            foreach (var i in idlist)
            {
                ts.Add(db.Users.Single(x => x.ID == i.user1id));
            }
            SearchModelView searchModelView = new SearchModelView
            {
                user = user,
                SerachUsers = ts
            };
            return View(searchModelView);
        }
        [HttpGet]
        public ActionResult ViewPage(int id,int id2)
        {
            User mainuser = db.Users.Single(x => x.ID == id);
            User Visited = db.Users.Single(x => x.ID == id2);
            VisistFriend visistFriend = new VisistFriend
            {
                MainUser = mainuser,
                Friend = Visited,
                Images = db.images.Where(x => x.userid == id2)
            };
            return View(visistFriend);
        }
       
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////
        ///
        public ActionResult Like(int id, int id2,int id3)
        {
            VisistFriend visistFriend = new VisistFriend
            {
                MainUser = db.Users.Single(x => x.ID == id2),
                Friend = db.Users.Single(x => x.ID == id3),
                Images = db.images.Where(x => x.userid == id3)
            };
            try
            {
              var lik = db.likes.Single(x => x.imageid == id && x.userid == visistFriend.MainUser.ID);
                lik.Like = true;
                db.SaveChanges();
            }
            catch
            {
                var lik = new Likes { userid = visistFriend.MainUser.ID, imageid = id,Like=true };
                db.likes.Add(lik);
                db.SaveChanges();
            }
            return RedirectToAction("ViewPage",new { id=id2, id2=id3 });
        }
        public ActionResult DisLike(int id, int id2, int id3)
        {
            VisistFriend visistFriend = new VisistFriend
            {
                MainUser = db.Users.Single(x => x.ID == id2),
                Friend = db.Users.Single(x => x.ID == id3),
                Images = db.images.Where(x => x.userid == id3)
            };
            try
            {
                var lik = db.likes.Single(x => x.imageid == id && x.userid == visistFriend.MainUser.ID);
                lik.Like = false;
                db.SaveChanges();
            }
            catch
            {
                var lik = new Likes { userid = visistFriend.MainUser.ID, imageid = id, Like = false };
                db.likes.Add(lik);
                db.SaveChanges();
            }
            return RedirectToAction("ViewPage", new { id = id2, id2 = id3 });
        }
        [HttpGet]
        public ActionResult Comment(int id, int id2, int id3)
        {
            Comments c = new Comments
            {
                userid = id2, imageid = id
            };
            User friend = db.Users.Single(x => x.ID == id3);
            var comment = new CommentView
            {
                frind = friend.ID,
                comments = c
            };
            return View(comment);
        }
        [HttpPost]
        public ActionResult Comment(CommentView commentView)
        {
            if(!ModelState.IsValid)
            {
                return View("Comment", commentView);
            }
            try
            {
                db.comments.Add(commentView.comments);
                db.SaveChanges();
            }
            catch
            {
                return View("Comment", commentView);
            }
            return RedirectToAction("ViewPage", new { id = commentView.comments.userid, id2 = commentView.frind });
        }

    }
}