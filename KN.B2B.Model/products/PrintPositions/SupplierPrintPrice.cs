using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierPrintPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string printPrice_id {get; set;}
        public string printPrice_description {get; set;}
        public string printPrice_pricingType {get; set;}
        public string printPrice_setup {get; set;}
        public string printPrice_repeat {get; set;}
        public string printPrice_nextColourIndicator {get; set;}
        // Foreign key for = SupplierPrintCost {get; set;}
    }
}
