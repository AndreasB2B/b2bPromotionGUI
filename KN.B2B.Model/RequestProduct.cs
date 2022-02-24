using KN.B2B.Model.SystemTables;
using System;
using System.ComponentModel;

namespace KN.B2B.Model
{
    public class RequestProduct
    {
        public int Id { get; set; }
        public Request Request { get; set; }
        [DisplayName("B2B Category")]
        public B2BCategory B2BCategory { get; set; }
        public Supplier Supplier { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Shipping Date")]
        public DateTime? ShippingDate { get; set; }
        [DisplayName("Delivery Date")]
        public DateTime? DeliveryDate { get; set; }
        [DisplayName("Track & Trace #")]
        public string TrackingCode { get; set; }
        public string Comment { get; set; }
        public Complaint Complaint { get; set; }
        //public int Sugar { get; set; }
        //public int SugarTax { get; set; }
        //public int SugarFree { get; set; }
        //public int SugarFreeTax { get; set; }
        //public int Copydan { get; set; }
        //public int CopydanTax { get; set; }
        //public int Packaging { get; set; }
        //public int PackagingTax { get; set; }
        //public int Design { get; set; }
        //public int DesignFee { get; set; }
    }
}
