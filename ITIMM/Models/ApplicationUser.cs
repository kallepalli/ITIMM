using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class ApplicationUser:IdentityUser
    {
        public Custodian CustodianUser { get; set; }
    }
}
