using MVC_CompanySecurityTest.DataAccess;
using MVC_CompanySecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CompanySecurityTest.Controllers
{
    public class MitreAttackTestController : Controller
    {
        private readonly BaseDbContext context = new BaseDbContext();
        // GET: MitreAttackTest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestNmap()
        {
            var procInfo1 = new ProcessStartInfo();
            string testCommand = "nmap -Pn -T5 --open -oN nmap_test_result.txt 127.0.0.1";
            procInfo1.UseShellExecute = true;
            procInfo1.WorkingDirectory = @"C:\Windows\SysWOW64";
            procInfo1.FileName = @"C:\Windows\System32\cmd.exe";
            procInfo1.Verb = "runas";
            procInfo1.Arguments = "/c " + testCommand;
            procInfo1.WindowStyle = ProcessWindowStyle.Normal;
            Process process = Process.Start(procInfo1);
            process.WaitForExit();

            string testResult1 = System.IO.File.ReadAllText(@"C:\Windows\SysWOW64\nmap_test_result.txt");
            var today = DateTime.Today;

            var company = context.Informations.SingleOrDefault(x => x.Email == Session["Email"].ToString());
            AttackOutcome attackOutcome = new AttackOutcome();
            
            attackOutcome.AttackType = 1;
            attackOutcome.AttackResult = testResult1;
            attackOutcome.CompanyID = company.CompanyID;
            context.AttackOutcomes.Add(attackOutcome);
            context.SaveChanges();
            Response.Write("<script>alert('Nmap test applied succesfully!');</script>");
            return RedirectToAction("Index", "MitreAttackTest");
        }

        [HttpPost]
        public ActionResult TestCreateLocalAccount()
        {
            var proc2 = new ProcessStartInfo();
            string anyCommand = "net user /add #{emreolca} #{123}";
            proc2.UseShellExecute = true;
            proc2.WorkingDirectory = @"C:\Users\tyfny";
            proc2.FileName = @"C:\Windows\System32\cmd.exe";
            proc2.Verb = "runas";
            proc2.Arguments = "/c " + anyCommand;
            proc2.WindowStyle = ProcessWindowStyle.Normal;
            Process process2 = Process.Start(proc2);
            process2.WaitForExit();

            var proc3 = new ProcessStartInfo();
            string anyCommand3 = "net user > net_user_test.txt";
            proc3.UseShellExecute = true;
            proc3.WorkingDirectory = @"C:\Users\tyfny";
            proc3.FileName = @"C:\Windows\System32\cmd.exe";
            proc3.Verb = "runas";
            proc3.Arguments = "/c " + anyCommand3;
            proc3.WindowStyle = ProcessWindowStyle.Normal;
            Process process3 = Process.Start(proc3);
            process3.WaitForExit();

            string testResult2 = System.IO.File.ReadAllText(@"C:\Windows\SysWOW64\net_user_test.txt");
            var today = DateTime.Today;

            var company = context.Informations.SingleOrDefault(x => x.Email == Session["Email"].ToString());
            AttackOutcome attackOutcome = new AttackOutcome();

            attackOutcome.AttackType = 1;
            attackOutcome.AttackResult = testResult2;
            attackOutcome.CompanyID = company.CompanyID;
            context.AttackOutcomes.Add(attackOutcome);
            context.SaveChanges();
            Response.Write("<script>alert('Create account test applied succesfully!');</script>");
            return RedirectToAction("Index", "MitreAttackTest");
        }
    }
}