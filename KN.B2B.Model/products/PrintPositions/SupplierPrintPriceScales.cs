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
        public int scale_minimumQuantity {get; set;}
        public float scale_price {get; set;}
        public int scale_nextPrice {get; set;}
    }
}
