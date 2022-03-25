using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.SupplierTables.MidoceanAPI.Products
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string master_code { get; set; }
        public string master_id { get; set; }
        public string type_of_products { get; set; }
        public string commodity_code { get; set; }
        public string number_of_print_positions { get; set; }
        public string material_group { get; set; }
        public string country_of_origin { get; set; }
        public string brand { get; set; }
        public string product_name { get; set; }
        public string category_code { get; set; }
        public string product_class { get; set; }
        public string dimensions { get; set; }
        public string length { get; set; }
        public string length_unit { get; set; }
        public string width { get; set; }
        public string width_unit { get; set; }
        public string height { get; set; }
        public string height_unit { get; set; }
        public string volume { get; set; }
        public string volume_unit { get; set; }
        public string gross_weight { get; set; }
        public string gross_weight_unit { get; set; }
        public string net_weight { get; set; }
        public string net_weight_unit { get; set; }
        public string inner_carton_quantity { get; set; }
        public string outer_carton_quantity { get; set; }
        public string carton_length { get; set; }
        public string carton_length_unit { get; set; }
        public string carton_width { get; set; }
        public string carton_width_unit { get; set; }
        public string carton_height { get; set; }
        public string carton_height_unit { get; set; }
        public string carton_volume { get; set; }
        public string carton_volume_unit { get; set; }
        public string carton_gross_weight { get; set; }
        public string carton_gross_weight_unit { get; set; }
        public DateTime timestamp { get; set; }
        public Digital_Assets[] digital_assets { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public string material { get; set; }
        public string printable { get; set; }
        public string polybag { get; set; }
        public Variant[] variants { get; set; }
        public string green { get; set; }
        public string themes { get; set; }
        public string commercial_description { get; set; }
        public string liquid_volume { get; set; }
        public string carton_nett_weight { get; set; }
        public string carton_nett_weight_unit { get; set; }
        public string gender { get; set; }
    }

    public class Digital_Assets
    {
        public string url { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
    }

    public class Variant
    {
        public string variant_id { get; set; }
        public string sku { get; set; }
        public string release_date { get; set; }
        public string product_proposition_category { get; set; }
        public string category_level1 { get; set; }
        public string category_level2 { get; set; }
        public string category_level3 { get; set; }
        public string color_description { get; set; }
        public string color_group { get; set; }
        public string plc_status { get; set; }
        public string plc_status_description { get; set; }
        public string gtin { get; set; }
        public string color_code { get; set; }
        public string pms_color { get; set; }
        public Digital_Assets1[] digital_assets { get; set; }
        public object discontinued_date { get; set; }
        public string product_variant_description { get; set; }
        public string size_textile { get; set; }
    }

    public class Digital_Assets1
    {
        public string url { get; set; }
        public string url_highress { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
    }

}
