using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class Custodian
    {
        public string    Id     { get; set; }
        public string Assets { get; set; }
        public ApplicationUser IdentityUser { get; set; }
    }
}
