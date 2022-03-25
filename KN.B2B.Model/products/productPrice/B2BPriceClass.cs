using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model
{
    public class B2BPriceClass
    {
        [Key]
        public int priceClass_id {get; set;}
        public string priceClass_name {get; set;}
        public int priceClass_quantity {get; set;}
        public int priceClass_price01 {get; set;}
        public int priceClass_price02 {get; set;}
        public int priceClass_price03 {get; set;}
        public int priceClass_price04 {get; set;}
        public int priceClass_price05 {get; set;}
        public int priceClass_price06 {get; set;}
        public int priceClass_price07 {get; set;}
    }
}
