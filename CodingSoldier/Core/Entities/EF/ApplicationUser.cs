using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingSoldier.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
