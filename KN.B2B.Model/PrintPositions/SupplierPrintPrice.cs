using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    internal class SupplierPrintPrice
    {
        private string printPrice_code;
        private string printPrice_pricingType;
        private string printPrice_setup;
        private string printPrice_repeat;
        private string printPrice_nextColourIndicator;
        // Foreign key for = SupplierPrintCost;
        private SupplierPrintCost fk_printCost;
    }
}
