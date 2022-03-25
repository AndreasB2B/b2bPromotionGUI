using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    public class SupplierHandles
    {
        [Key]
        public int handles_id {get; set;}
        // Throws data to = B2BPrintTechnique {get; set;}
        public string handles_code {get; set;}
        public string handles_description {get; set;}
        public float handles_price {get; set;}
    }
}
