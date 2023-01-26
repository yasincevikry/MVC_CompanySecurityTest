using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_CompanySecurityTest.Models
{
    public class Information
    {
        [Key]
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Company Area is required.")]
        public string CompanyArea { get; set; }
        [Required(ErrorMessage = "Company City is required.")]
        public string CompanyCity { get; set; }
        [Required(ErrorMessage = "Company District is required.")]
        public string CompanyDistrict { get; set; }
        [Required(ErrorMessage = "Company Country is required.")]
        public string CompanyCountry { get; set; }
        [Required(ErrorMessage = "Contact is required.")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}