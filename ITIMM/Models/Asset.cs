using System;
using System.Collections.Generic;

namespace ITIMM.Models
{
    public class Asset
    {
        public int      Id                  { get; set; }
        public string   Slno                { get; set; }
        public string   Make                { get; set; }
        public string   Model               { get; set; }
        public int      WarrantyInMonths    { get; set; }
        public DateTime InstallationDate    { get; set; }
        public DateTime WarrantyExpiryDate  { get; set; }
        public DateTime AMCDate             { get; set; }
        public string   PoNo                { get; set; }
        public string   OS                  { get; set; }
        public string   HostName            { get; set; }
        public string   WorkGroup           { get; set; }
        public Custodian CustodianAsset     { get; set; }
        public Category AssetCategory { get; set; }
        public List<Complaints> AssetComplaints { get; set; }
    }
}
