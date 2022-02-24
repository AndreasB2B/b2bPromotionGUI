using KN.B2B.Model.SystemTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KN.B2B.Model
{
    public class Request
    {
        public int Id { get; set; }
        [DisplayName("Request Date")]
        public DateTime RequestDate { get; set; }
        public Customer Customer { get; set; }
        [DisplayName("Request Deadline")]
        public DateTime RequestDeadline { get; set; }
        public string Comment { get; set; }
        [DisplayName("Start Status")]
        public StartStatus StartStatus { get; set; }
        [DisplayName("End Status")]
        public EndStatus EndStatus { get; set; }
        [DisplayName("Current Status")]
        public CurrentStatus CurrentStatus { get; set; }
        [DisplayName("B2B Invoice Number")]
        public string B2bInvoiceNumber { get; set; }
        [DisplayName("B2B Order Number")]
        public string B2bOrderNumber { get; set; }
        [DisplayName("Invoice Date")]
        public DateTime? InvoiceDate { get; set; }
        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }
        [DisplayName("Payment Date")]
        public DateTime? PaymentDate { get; set; }
        [DisplayName("Cancellation Reason")]
        public CancellationReason CancellationReason { get; set; }
        [DisplayName("Trust Pilot")]
        public bool TrustPilot { get; set; }
        [DisplayName("Trust Pilot Date")]
        public DateTime? TrustPilotDate { get; set; }
        [DisplayName("Legal Action")]
        public bool LegalAction { get; set; }
        [DisplayName("Express Production")]
        public bool ExpressProduction { get; set; }
        [DisplayName("Express Delivery")]
        public bool ExpressDelivery { get; set; }
        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; }
        [DisplayName("Delivery Zip Code")]
        public ZipCode DeliveryZip { get; set; }
        public List<RequestCommunication> Communications { get; set; }
        public List<RequestProduct> Products { get; set; }
        [DisplayName("Sample Requested")]
        public DateTime? SampleRequested { get; set; }
        [DisplayName("Sample Sent")]
        public DateTime? SampleSent { get; set; }
        [DisplayName("Sample Approved")]
        public DateTime? SampleApproved { get; set; }
    }
}
