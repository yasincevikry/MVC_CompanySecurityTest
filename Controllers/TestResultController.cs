using MVC_CompanySecurityTest.DataAccess;
using MVC_CompanySecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CompanySecurityTest.Controllers
{
    public class TestResultController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TestResults()
        {
            var info = context.Informations.SingleOrDefault(x => x.Email == Session["email"].ToString());
            var results = (from a in context.AttackOutcomes where a.CompanyID == info.CompanyID select a).ToList();
            var result = context.AttackOutcomes.Where(a => a.CompanyID == info.CompanyID).ToList();
            return View(result);
        }
    }
}