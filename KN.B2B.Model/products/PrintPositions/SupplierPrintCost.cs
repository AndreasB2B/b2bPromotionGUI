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
        public int printCost_rangeId {get; set;}
        public int printCost_areaFrom {get; set;}
        public int printCost_areaTo {get; set;}
        // Foreign key to = PrintPriceScales {get; set;}
        public SupplierPrintPriceScales fk_printPriceScales {get; set;}
    }
}
