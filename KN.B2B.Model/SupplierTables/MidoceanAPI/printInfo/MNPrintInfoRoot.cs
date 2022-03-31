using System;
using System.Collections.Generic;
using System.Text;

namespace KN.B2B.Model.SupplierTables.MidoceanAPI.printInfo
{
    internal class MNPrintInfoRoot
    {
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class PRINTINGINFORMATION
    {

        public string sUPPLIERField;

        public uint dATEField;

        public System.DateTime tIMEField;

        public PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION[] pRINTING_TECHNIQUE_DESCRIPTIONSField;

        public PRINTINGINFORMATIONPRODUCT[] pRODUCTSField;

        /// <remarks/>
        public string SUPPLIER
        {
            get
            {
                return this.sUPPLIERField;
            }
            set
            {
                this.sUPPLIERField = value;
            }
        }

        /// <remarks/>
        public uint DATE
        {
            get
            {
                return this.dATEField;
            }
            set
            {
                this.dATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime TIME
        {
            get
            {
                return this.tIMEField;
            }
            set
            {
                this.tIMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PRINTING_TECHNIQUE_DESCRIPTION", IsNullable = false)]
        public PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION[] PRINTING_TECHNIQUE_DESCRIPTIONS
        {
            get
            {
                return this.pRINTING_TECHNIQUE_DESCRIPTIONSField;
            }
            set
            {
                this.pRINTING_TECHNIQUE_DESCRIPTIONSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", IsNullable = false)]
        public PRINTINGINFORMATIONPRODUCT[] PRODUCTS
        {
            get
            {
                return this.pRODUCTSField;
            }
            set
            {
                this.pRODUCTSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION
    {

        public PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTIONNAME[] nAMEField;

        public string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAME")]
        public PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTIONNAME[] NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTIONNAME
    {

        public string languageField;

        public string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRODUCT
    {

        public string pRODUCT_BASE_NUMBERField;

        public uint pRODUCT_PRINT_IDField;

        public string pRINT_EXPRESS_POSSIBLEField;

        public string iTEM_COLOR_NUMBERField;

        public string mANIPULATIONField;

        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITION[] pRINTING_POSITIONSField;

        public string pRINT_POSITION_DOCUMENTField;

        /// <remarks/>
        public string PRODUCT_BASE_NUMBER
        {
            get
            {
                return this.pRODUCT_BASE_NUMBERField;
            }
            set
            {
                this.pRODUCT_BASE_NUMBERField = value;
            }
        }

        /// <remarks/>
        public uint PRODUCT_PRINT_ID
        {
            get
            {
                return this.pRODUCT_PRINT_IDField;
            }
            set
            {
                this.pRODUCT_PRINT_IDField = value;
            }
        }

        /// <remarks/>
        public string PRINT_EXPRESS_POSSIBLE
        {
            get
            {
                return this.pRINT_EXPRESS_POSSIBLEField;
            }
            set
            {
                this.pRINT_EXPRESS_POSSIBLEField = value;
            }
        }

        /// <remarks/>
        public string ITEM_COLOR_NUMBER
        {
            get
            {
                return this.iTEM_COLOR_NUMBERField;
            }
            set
            {
                this.iTEM_COLOR_NUMBERField = value;
            }
        }

        /// <remarks/>
        public string MANIPULATION
        {
            get
            {
                return this.mANIPULATIONField;
            }
            set
            {
                this.mANIPULATIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PRINTING_POSITION", IsNullable = false)]
        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITION[] PRINTING_POSITIONS
        {
            get
            {
                return this.pRINTING_POSITIONSField;
            }
            set
            {
                this.pRINTING_POSITIONSField = value;
            }
        }

        /// <remarks/>
        public string PRINT_POSITION_DOCUMENT
        {
            get
            {
                return this.pRINT_POSITION_DOCUMENTField;
            }
            set
            {
                this.pRINT_POSITION_DOCUMENTField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRODUCTPRINTING_POSITION
    {

        public string idField;

        public string pRINTING_SIZE_UNITField;

        public string mAX_PRINT_SIZE_HEIGHTField;

        public string mAX_PRINT_SIZE_WIDTHField;

        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINT_POSITION_URL[] pRINT_POSITION_URLField;

        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE[] pRINTING_TECHNIQUEField;

        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string PRINTING_SIZE_UNIT
        {
            get
            {
                return this.pRINTING_SIZE_UNITField;
            }
            set
            {
                this.pRINTING_SIZE_UNITField = value;
            }
        }

        /// <remarks/>
        public string MAX_PRINT_SIZE_HEIGHT
        {
            get
            {
                return this.mAX_PRINT_SIZE_HEIGHTField;
            }
            set
            {
                this.mAX_PRINT_SIZE_HEIGHTField = value;
            }
        }

        /// <remarks/>
        public string MAX_PRINT_SIZE_WIDTH
        {
            get
            {
                return this.mAX_PRINT_SIZE_WIDTHField;
            }
            set
            {
                this.mAX_PRINT_SIZE_WIDTHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PRINT_POSITION_URL")]
        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINT_POSITION_URL[] PRINT_POSITION_URL
        {
            get
            {
                return this.pRINT_POSITION_URLField;
            }
            set
            {
                this.pRINT_POSITION_URLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PRINTING_TECHNIQUE")]
        public PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE[] PRINTING_TECHNIQUE
        {
            get
            {
                return this.pRINTING_TECHNIQUEField;
            }
            set
            {
                this.pRINTING_TECHNIQUEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINT_POSITION_URL
    {

        public byte colorField;

        public string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE
    {

        public string idField;

        public byte mAX_COLORSField;

        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public byte MAX_COLORS
        {
            get
            {
                return this.mAX_COLORSField;
            }
            set
            {
                this.mAX_COLORSField = value;
            }
        }
    }


}
