using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierPrintPriceScales
    {
        [Key]
        public int scale_id {get; set;}
        public float scale_minimumQuantity {get; set;}
        public float scale_priceDK {get; set;}
        public float scale_priceEU {get; set;}
        public float scale_priceFI {get; set; }
        public float scale_supplierPrice { get; set; }
        public float scale_nextPrice {get; set;}
        public SupplierPrintCost fk_supplerPrintCost {get; set;} 
    }
}
