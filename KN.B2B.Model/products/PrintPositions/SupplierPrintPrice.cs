using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierPrintPrice
    {
        // TODO ==> CHANGE FROM STRING TO INT
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string printPrice_id {get; set;}
        public string printPrice_descId {get; set;}
        public string printPrice_description {get; set;}
        public string printPrice_pricingType {get; set;}
        public string printPrice_setupDK {get; set;}
        public string printPrice_setupEU {get; set;}
        public string printPrice_setupFI { get; set;}
        public string printPrice_repeat {get; set;}
        public string printPrice_nextColourIndicator {get; set;}
        public bool alert { get; set; }
        public string alertMessage { get; set; }
        public string alertStatus { get; set; }
        // Foreign key for = SupplierPrintCost {get; set;}
    }
}
