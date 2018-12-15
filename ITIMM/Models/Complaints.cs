using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITIMM.Models
{
    public class Complaints
    {
        public int Id { get; set; }
        public DateTime ComplaintDT   { get; set; }
        public bool     Status          { get; set; }
        public string   Descriprion     { get; set; }
        public Asset AssetComplaints { get; set; }
        public List<Comments> ComplaintComments { get; set; }
        public Custodian CustodianComplaint { get; set; }

    }
}
