using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace project.Controllers
{
    public class LoginController : Controller
    {
        DbModel db = new DbModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account user)
        {
            if(!ModelState.IsValid)
            {
                return View("Index",user);
            }
            try
            {

              User acc=db.Users.Single(x=>x.Email==user.Email&&x.Password==user.Password);
                return RedirectToAction("Index","UserPage", acc);
            }
            catch(Exception e)
            {
                ViewData["Message"] = "Wrong password or Email";
                
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult ava()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ava(Likes likes)
        {
            if(!ModelState.IsValid)
            {
                return View("ava");
            }
            return View();
        }
        [HttpGet]
        public ActionResult bva()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bva(Comments com)
        {
            if (!ModelState.IsValid)
            {
                return View("ava");
            }
            return View();
        }

    }
}