﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomDataBase.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This  field is required.")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}