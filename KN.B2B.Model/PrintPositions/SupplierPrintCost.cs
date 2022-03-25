using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.products.B2BPrintPositions
{
    internal class SupplierPrintCost
    {
        private int printCost_rangeId;
        private int printCost_areaFrom;
        private int printCost_areaTo;
        // Foreign key to = PrintPriceScales;
        private SupplierPrintPriceScales fk_printPriceScales;
    }
}
