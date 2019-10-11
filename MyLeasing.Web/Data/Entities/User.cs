using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class User: IdentityUser
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Display(Name = "Firts Name")]
        public string FirtsName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }

        [Display(Name = "Owner Name")]
        public string FullName => $"{FirtsName} {LastName}";

        [Display(Name = "Owner Name")]
        public string FullNameWithDocument => $"{FirtsName} {LastName} - {Document}";
    }
}
