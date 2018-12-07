using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class Complaints
    {
        public int      AssetId         { get; set; }
        public int      ComplaintId     { get; set; }
        public DateTime ComplaintDate   { get; set; }
        public bool     Status          { get; set; }
        public string   Descriprion     { get; set; }
        public int      CustodianId     { get; set; }
    }
}
