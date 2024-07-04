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
    public class RegisterController : Controller
    {
        DbModel db = new DbModel();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            if(user.imageFile!=null)
            {

            string fileName = Path.GetFileNameWithoutExtension(user.imageFile.FileName);
            string extensions = Path.GetExtension(user.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
            user.Image = "/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
            user.imageFile.SaveAs(fileName);
            }
                db.Users.Add(user);
                db.SaveChanges();
                ViewData["Message"] = "User Record " + user.FirstName + " is saved succesfully..";
            return RedirectToAction("Index", "Home");
           
        }
    }
}