using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class B2BPrintTechnique
    {
        [Key]
        public int technique_id {get; set;}
        public string technique_name {get; set;}
        public string technique_description {get; set;}
        public int technique_maxColors {get; set;}
        public string technique_supplier {get; set;}
        // Foreign key for = SupplierHandles {get; set;}
        public SupplierHandles fk_supplierHandleCode {get; set;}
        // Foreign key for = SupplierPrintPrice {get; set;}
        public SupplierPrintPrice fk_supplierPriceCode {get; set;}
    }
}
