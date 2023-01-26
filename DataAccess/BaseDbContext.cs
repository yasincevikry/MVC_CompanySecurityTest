using Microsoft.EntityFrameworkCore;
using MVC_CompanySecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CompanySecurityTest.DataAccess
{
    public class BaseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DL108EG\SQLEXPRESS;Database=CompanySecurityTest;Trusted_Connection=true");

        }

        public DbSet<Information> Informations { get; set; }
        public DbSet<AttackOutcome> AttackOutcomes { get; set; }
        
    }
}