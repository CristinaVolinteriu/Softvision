using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using DataAccess;
using BusinessLogic;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class MinesController : Controller
    {
        // GET: Default
        ApplicationDbContext dbContext = new ApplicationDbContext();
        MinesService MinesService = new MinesService();
        /* public ActionResult ShowCityMines(int? cityId)
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
          }*/

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            return View(MinesService.UpdteResources(userId));
        }

        public ActionResult Details(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            return View(mine);
        }
        
    }
}