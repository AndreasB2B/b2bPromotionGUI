using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    internal class B2BPrintPosition
    {
        private string print_supplier;
        private string print_product;
        private int print_express;
        private string print_position;
        private float print_size;
        private float print_height;
        // Foreign key for fk techniqueID = B2BPrintTechnique;
        private B2BPrintTechnique fk_techniqueId;
    }
}
