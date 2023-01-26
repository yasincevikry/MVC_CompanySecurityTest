using MVC_CompanySecurityTest.DataAccess;
using MVC_CompanySecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CompanySecurityTest.Controllers
{
    
    public class ProfileController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            var info = context.Informations.SingleOrDefault(m => m.Email == Session["email"].ToString());
            return View(info);
            
        }

        [HttpPost]
        public ActionResult ChangeInformations(Information Information)
        {
            var updatedCompany = context.Informations.SingleOrDefault(i => i.Email == Session["email"].ToString());

            if (updatedCompany != null)
            {
                updatedCompany.CompanyName = Information.CompanyName;
                updatedCompany.CompanyArea = Information.CompanyArea;
                updatedCompany.CompanyCity = Information.CompanyCity;
                updatedCompany.CompanyDistrict = Information.CompanyDistrict;
                updatedCompany.CompanyCountry = Information.CompanyCountry;
                updatedCompany.Contact = Information.Contact;
                updatedCompany.Email = Information.Email;
                updatedCompany.Password = Information.Password;
                updatedCompany.Description = Information.Description;
                context.Informations.Update(updatedCompany);
                context.SaveChanges();
                
            }
            else
            {
                ViewBag.Message = "User not found.";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}