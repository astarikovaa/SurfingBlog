using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]

        public String Nickname { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        public String Password { get; set; }
        public bool RemoveName { get; set; }
    }
}
