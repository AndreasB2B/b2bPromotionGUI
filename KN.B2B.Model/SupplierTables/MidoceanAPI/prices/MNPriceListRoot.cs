using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.SupplierTables.MidoceanAPI.prices
{
    public class MNPriceListRoot
    {
        public string currency { get; set; }
        public string date { get; set; }
        public List<Price> price { get; set; }
    }

    public class Scale
    {
        public string minimum_quantity { get; set; }
        public string price { get; set; }
    }

    public class Price
    {
        public string sku { get; set; }
        public string variant_id { get; set; }
        public string price { get; set; }
        public string valid_until { get; set; }
        public List<Scale> scale { get; set; }
    }
}
