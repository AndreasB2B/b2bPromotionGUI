using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierPrintCost
    {
        [Key]
        public int printCost_id {get; set;}
        public string printCost_rangeId {get; set;}
        public float printCost_areaFrom {get; set;}
        public float printCost_areaTo {get; set; }
        public bool alert { get; set; }
        public string alertMessage { get; set; }
        public string alertStatus { get; set; }
        public SupplierPrintPrice fk_supplierPrintPrice {get; set;}
        // Foreign key to = PrintPriceScales {get; set;}
        //public SupplierPrintPriceScales fk_printPriceScales {get; set;}
    }
}
