﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.IdentityDto.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
    }
}