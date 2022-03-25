using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.ProductModels
{
    internal class B2BProducts
    {
        // Foreign Key for print positions, was called p1,p2,etc.. before; = B2BPrintPositions;
        private B2BPrintPosition fk_printPosition;
        //Grapping data for product price, was called q1,q2,etc.. before; = B2BProductPrice;
        private string product_sku;
        //Foreign key
        private B2BParrentProducts fk_ParentSKU;
        private string product_ColorName;
        private string product_brandNames;
        [StringLength(31)]
        private string product_shortDescriptionDK;
        [StringLength(31)]
        private string product_shortDescriptionEN;
        [StringLength(31)]
        private string product_shortDescriptionFI;
        private string product_longDescriptionDK;
        private string product_longDescriptionEN;
        private string product_longDescriptionFI;
        private string product_PriceClass_IL1_T1;
        private string product_PriceClass_IL1_T2;
        private string product_PriceClass_IL1_T3;
        private string product_PriceClass_IL1_T4;
        private string product_PriceClass_IL1_T5;
        private string product_PriceClass_IL1_T6;
        private string product_PriceClass_IL1_CN;
        private string product_PriceClass_IL1_CN2;
        private string product_PriceClass_IL1_CN3;
        private string product_PriceClass_IL1_CN4;
        private string product_PriceClass_IL1_CN5;
        private string product_PriceClass_IL1_CN6;
        private string product_IntraCode;
        private string product_CountryOfOrigin;
        private string product_CommercialItemLength;
        private string product_CommercialItemWidth;
        private string product_CommercialItemHeight;
        private string product_CommercialItemWeight;
        private string product_Flavours;
        private string product_Sizes;
        private string product_WritingColor;
        private int product_OrderUnit;
        private string product_BatteryType;
        private int product_NumberOfBatteries;
        private string product_ProductImageURL;
        private DateTime product_DeliveryTimeMT_IL1_T1;
        private string product_SearchTerms;
        private string product_Q_OnPallet;
        private string product_Brandnames;
    }
}
