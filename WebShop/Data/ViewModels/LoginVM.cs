using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Ваш E-Mail")]
        [Required(ErrorMessage = "Это поле обязательно")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
