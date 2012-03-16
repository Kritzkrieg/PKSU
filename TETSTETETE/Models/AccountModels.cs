using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;

namespace TETSTETETE.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nuværende adgangskode")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} skal være minimum {2} tegn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Ny adgangskode")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Gentag ny adgangskode")]
        [Compare("NewPassword", ErrorMessage = "Den nye adgangskode og den gentagne adgangskode stemmer ikke overens.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [Display(Name = "Husk bruger.")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "{0} skal være minimum {2} tegn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Gentag adgangskode")]
        [Compare("Password", ErrorMessage = "Adgangskoden stemmer ikke overens med den gentagne adgangskode.")]
        public string ConfirmPassword { get; set; }
    }
}
