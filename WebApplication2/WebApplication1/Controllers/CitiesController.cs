using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DataAccess;

namespace WebApplication1.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index(CityFilterViewModel filterModel)
        {
            IQueryable<City> query = dbContext.Cities;
            if(filterModel.Name!=null)
            {
                query = query.Where(u => u.ApplicationUser.UserName.Contains(filterModel.Name));
            }
            if (filterModel.Email != null)
            {
                query = query.Where(u => u.ApplicationUser.Email.Contains(filterModel.Email));
            }
            if (filterModel.MaxTroupCount != null)
            {
                query = query.Where(u => u.Troups.Sum(t => t.TroupCount)<=filterModel.MaxTroupCount);
            }
            if (filterModel.MinTroupCount != null)
            {
                query = query.Where(u => u.Troups.Sum(t => t.TroupCount)>=filterModel.MinTroupCount);
            }
            filterModel.Results = query.ToList();
            return View(filterModel);
        }
    }
}