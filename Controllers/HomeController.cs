using MVC_CompanySecurityTest.DataAccess;
using MVC_CompanySecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CompanySecurityTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Information info)
        {
            try
            {
                var companyDB = context.Informations.SingleOrDefault(x => x.Email == info.Email && x.Password == info.Password);
                if (companyDB != null)
                {
                    HttpContext.Session["email"] = companyDB.Email;
                    Session["email"] = info.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Response.Write("<script>alert('Invalid E-mail or Password!');</script>");
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                throw ex;
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Information info)
        {
            if (ModelState.IsValid)
            {
                context.Informations.Add(info);
                context.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}