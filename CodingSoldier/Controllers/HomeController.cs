using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CodingSoldier.Controllers
{
    public class HomeController : Controller
    {               
        public IActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {            
            ViewBag.Me = Constants.Me;
            return View();
        }

        public ActionResult Technologies()
        {
            var technologies = @"ASP.NET Core 2.0,EF Core,AutoMapper,EF Identity,BootStrap,Attribute Based Routing, Nginx";

            var patternsAndPractices = @"UnitOfWork Pattern,Repository Pattern, CodeFirst Migration,BaseControllers using Generics";

            ViewBag.technologies = technologies.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ViewBag.patternsAndPractices = patternsAndPractices.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return View();
         }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}