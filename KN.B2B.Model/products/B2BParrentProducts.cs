using KN.B2B.Model.SystemTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KN.B2B.Model.products
{
    public class B2BParrentProducts
    {
        [Key]
        public int parrentProduct_id {get; set;}
        public string parrentProduct_productName { get; set; }
        public int parrentProduct_masterId {get; set;}
        // Throw parrentsku to B2BProducts entity
        public string parrentProduct_parrentSku {get; set;}
        public int parrentProduct_printPositions {get; set;}
        public string parrentProduct_dimensions {get; set;}
        public float parrentProduct_length {get; set;}
        public float parrentProduct_width {get; set;}
        public float parrentProduct_height {get; set;}
        public string parrentProduct_longDescription {get; set;}
        public string parrentProduct_shortDescription {get; set;}
        public bool parrentProduct_printable { get; set; }
        public string parrentProduct_material { get; set;}
        public string parrentProduct_mainCategory {get; set;}
        public string parrentProduct_subCategory {get; set;}
        // Get data from cagetgory groups
        public B2BCategoryGroup fk_B2BCategoryGroups {get; set;}
        // Get data from categories
        public B2BCategory fk_B2BCategories {get; set;}

    }
}
