using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class MinesController : Controller
    {
        // GET: Default
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult ShowCityMines(int? id)
         {
             var userId = this.User.Identity.GetUserId();
             var user = dbContext.Users.Find(userId);
             City city;
             if (!id.HasValue)
             {
                 city = user.Cities.First();
             }
             else
             {
                 city = user.Cities.ElementAt(id.Value);
             }
            return View("Index", city);
         }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            return View(user);
        }

        public ActionResult Details(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            return View(mine);
        }
    }
}