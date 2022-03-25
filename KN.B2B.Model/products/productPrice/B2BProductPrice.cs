using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products.productPrice
{
    public class B2BProductPrice
    {
        [Key]
        public int id {get; set;}
        public B2BProduct fk_productSku {get; set;}
        public int price_startingPrice {get; set;}
        public int price_scale {get; set;}
    }
}
