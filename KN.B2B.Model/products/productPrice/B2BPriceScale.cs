using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.productPrice
{
    public class B2BPriceScaling
    {
        [Key]
        public int scale_id {get; set;}
        public int scale_minimumQuantity {get; set;}
        public string scale_supplierPrice {get; set;}
        public string scale_priceDK { get; set;}
        public string scale_priceEU { get; set;}
        public string scale_priceFI { get; set;}
        public bool alertActive { get; set; }
        public string alert { get; set; }
        public B2BProductPrices fk_priceId { get; set; }
    }
}
