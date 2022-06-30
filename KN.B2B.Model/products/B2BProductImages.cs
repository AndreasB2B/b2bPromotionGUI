using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products
{
    public class B2BProductImages
    {
        [Key]
        public int id { get; set; }
        public string imagePath { get; set; }
        public B2BProduct fk_childProduct { get; set; }
    }
}
