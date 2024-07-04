using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    public class HomeController : Controller
    {
            DbModel db = new DbModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
       
    }
}