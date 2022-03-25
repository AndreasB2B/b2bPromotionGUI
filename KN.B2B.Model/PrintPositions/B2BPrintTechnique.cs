using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    internal class B2BPrintTechnique
    {
        private string technique_name;
        private string technique_description;
        private int technique_maxColors;
        private string technique_supplier;
        // Foreign key for = SupplierHandles;
        private SupplierHandles fk_supplierHandleCode;
        // Foreign key for = SupplierPrintPrice;
        private SupplierPrintPrice fk_supplierPriceCode;
    }
}
