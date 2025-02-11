using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
