using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class Comments
    {
        public int      CommentId   { get; set; }
        public int      CustodiaId  { get; set; }
        public int      AssetId     { get; set; }
        public string   Comment     { get; set; }
        public DateTime CommentDT   { get; set; }

    }
}
