using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.productPrice
{
    public class B2BProductPrices
    {
        [Key]
        public int id {get; set;}
        public string parrentSku{get; set;}
        public string price_startingPriceSupplier {get; set;}
        public string price_startingPriceDK {get; set;}
        public string price_startingPriceEU {get; set;}
        public string price_startingPriceFI { get; set;}
        public string price_validUntill { get; set;}
    }
}
