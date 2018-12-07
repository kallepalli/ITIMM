using System;

namespace ITIMM.Models
{
    public class Asset
    {
        public int      Id                  { get; set; }
        public int      AssetCategoryId     { get; set; }
        public string   Slno                { get; set; }
        public string   Make                { get; set; }
        public string   Model               { get; set; }
        public int      WarrantyInMonths    { get; set; }
        public DateTime InstallationDate    { get; set; }
        public DateTime WarrantyExpiryDate  { get; set; }
        public DateTime AMCDate             { get; set; }
        public string   PoNo                { get; set; }
        public int      CustodianId         { get; set; }
        public string   OS                  { get; set; }
        public string   HostName            { get; set; }
        public string   WorkGroup           { get; set; }
    }
}
