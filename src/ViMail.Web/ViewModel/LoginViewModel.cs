using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViMail.Web.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
