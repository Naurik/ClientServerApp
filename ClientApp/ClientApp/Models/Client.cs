using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class Client
    {
        [Required(ErrorMessage = "Введите номер человека")]
        [Display(Name = "Номер: ")]
        public string PhoneNumber { get; set; }
    }
}