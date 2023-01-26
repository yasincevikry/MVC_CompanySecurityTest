using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_CompanySecurityTest.Models
{
    public class AttackOutcome
    {
        [Key]
        public int AttackID { get; set; }
        public string AttackResult { get; set; }
        public int AttackType { get; set; }
        public int CompanyID { get; set; }
    }
}