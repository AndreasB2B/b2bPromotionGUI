using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.SupplierTables.MidoceanAPI.printInfo
{
    public class MNPrintPricesRoot
    {
        public string currency { get; set; }
        public string pricelist_valid_from { get; set; }
        public string pricelist_valid_until { get; set; }
        public List<PrintManipulation> print_manipulations { get; set; }
        public List<PrintTechnique> print_techniques { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PrintManipulation
    {
        public string code { get; set; }
        public string description { get; set; }
        public string price { get; set; }
    }

    public class Scales
    {
        public string minimum_quantity { get; set; }
        public string price { get; set; }
        public string next_price { get; set; }
    }

    public class VarCost
    {
        public string range_id { get; set; }
        public string area_from { get; set; }
        public string area_to { get; set; }
        public List<Scales> scales { get; set; }
    }

    public class PrintTechnique
    {
        public string id { get; set; }
        public string description { get; set; }
        public string pricing_type { get; set; }
        public string setup { get; set; }
        public string setup_repeat { get; set; }
        public string next_colour_cost_indicator { get; set; }
        public List<VarCost> var_costs { get; set; }
    }
}
