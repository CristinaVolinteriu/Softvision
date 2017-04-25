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
        public ActionResult ShowCityMines(int? cityId)
         {
             var userId = this.User.Identity.GetUserId();
             var user = dbContext.Users.Find(userId);
             City city;
             if (!cityId.HasValue)
             {
                 city = user.Cities.First();
             }
             else
             {
                 city = dbContext.Cities.Find(cityId.Value);
             }
            this.UpdteResources(city);
            return View("Index", city);
         }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.First();
            this.UpdteResources(city);
            return View(city);
        }

        public ActionResult Details(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            return View(mine);
        }
        

        private void UpdteResources(City city)
        {
            var start = DateTime.Now;
            foreach (var res in city.Resources)
            {
                foreach (var mine in city.Mines)
                {
                    if (mine.Type == res.Type)
                    {
                        res.Level += mine.GetProductionPerHour() * (start - res.LastUpdate).TotalHours;
                    }
                }
                res.LastUpdate = start;
            }
            dbContext.SaveChanges();
        }
    }
}