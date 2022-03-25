using KN.B2B.Model.SystemTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.products
{
    internal class B2BParrentProducts
    {
        private int parrentProduct_masterId;
        // Throw parrentsku to B2BProducts entity
        private string parrentProduct_parrentSku;
        private int parrentProduct_printPositions;
        private string parrentProduct_dimensions;
        private float parrentProduct_length;
        private float parrentProduct_width;
        private float parrentProduct_height;
        private string parrentProduct_longDescription;
        private string parrentProduct_shortDescription;
        private bool parrentProduct_printable;
        private string parrentProduct_mertial;
        private string parrentProduct_mainCategory;
        private string parrentProduct_subCategory;
        // Get data from cagetgory groups
        private B2BCategoryGroup fk_B2BCategoryGroups;
        // Get data from categories
        private B2BCategory fk_B2BCategories;

    }
}
