using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.SystemTables;

namespace KN.B2B.Model.products
{
    public class B2BProduct
    {
        [Key]
        public int product_id { get; set; }
        // Foreign Key for print positions, was called p1,p2,etc.. before; = B2BPrintPositions;
        public B2BPrintPosition fk_printPosition { get; set; }
        //Grapping data for product price, was called q1,q2,etc.. before; = B2BProductPrice;
        public string product_sku { get; set; }
        //Foreign key
        public B2BParrentProducts fk_ParentSKU { get; set; }
        public string product_ColorName { get; set; }
        public string product_brandNames { get; set; }
        [StringLength(31)]
        public string product_shortDescriptionDK { get; set; }
        [StringLength(31)]
        public string product_shortDescriptionEN { get; set; }
        [StringLength(31)]
        public string product_shortDescriptionFI { get; set; }
        public string product_longDescriptionDK { get; set; }
        public string product_longDescriptionEN { get; set; }
        public string product_longDescriptionFI { get; set; }
        public string product_PriceClass_IL1_T1 { get; set; }
        public string product_PriceClass_IL1_T2 { get; set; }
        public string product_PriceClass_IL1_T3 { get; set; }
        public string product_PriceClass_IL1_T4 { get; set; }
        public string product_PriceClass_IL1_T5 { get; set; }
        public string product_PriceClass_IL1_T6 { get; set; }
        public string product_PriceClass_IL1_CN { get; set; }
        public string product_PriceClass_IL1_CN2 { get; set; }
        public string product_PriceClass_IL1_CN3 { get; set; }
        public string product_PriceClass_IL1_CN4 { get; set; }
        public string product_PriceClass_IL1_CN5 { get; set; }
        public string product_PriceClass_IL1_CN6 { get; set; }
        public string product_IntraCode { get; set; }
        public string product_CountryOfOrigin { get; set; }
        public string product_CommercialItemLength { get; set; }
        public string product_CommercialItemWidth { get; set; }
        public string product_CommercialItemHeight { get; set; }
        public string product_CommercialItemWeight { get; set; }
        public string product_Flavours { get; set; }
        public string product_Sizes { get; set; }
        public string product_WritingColor { get; set; }
        public int product_OrderUnit { get; set; }
        public string product_BatteryType { get; set; }
        public int product_NumberOfBatteries { get; set; }
        public string product_ProductImageURL { get; set; }
        public DateTime product_DeliveryTimeMT_IL1_T1 { get; set; }
        public string product_SearchTerms { get; set; }
        public string product_Q_OnPallet { get; set; }
    }
}
