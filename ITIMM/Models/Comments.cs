using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class Comments
    {
        public int      Id   { get; set; }
        public string   Comment     { get; set; }
        public DateTime CommentDT   { get; set; }
        public Complaints CommentComplaint { get; set; }
        public Asset    AssetComment { get; set; }
        public Custodian CutodianComment { get; set; }
    }
}
