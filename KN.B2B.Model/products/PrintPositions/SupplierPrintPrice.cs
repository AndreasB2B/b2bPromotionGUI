using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierPrintPrice
    {
        [Key]
        public string printPrice_id {get; set;}
        public string printPrice_code {get; set;}
        public string printPrice_pricingType {get; set;}
        public string printPrice_setup {get; set;}
        public string printPrice_repeat {get; set;}
        public string printPrice_nextColourIndicator {get; set;}
        // Foreign key for = SupplierPrintCost {get; set;}
        public SupplierPrintCost fk_printCost {get; set;}
    }
}
