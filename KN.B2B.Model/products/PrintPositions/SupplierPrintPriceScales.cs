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
        public float scale_nextPriceSupplier {get; set;}
        public float scale_nextPriceDK {get; set;}
        public float scale_nextPriceEU {get; set;}
        public float scale_nextPriceFI {get; set;}
        public bool alert { get; set; }
        public string alertMessage { get; set; }
        public string alertStatus { get; set; }
        public SupplierPrintCost fk_supplerPrintCost {get; set;} 
    }
}
