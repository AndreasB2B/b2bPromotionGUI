using KN.B2B.Model.SystemTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model
{
    [Serializable]
    public class Customer //Test customer ID = 700 in main menu
    {
        public int Id { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Customer")]
        public string Name { get; set; }
        public string Address { get; set; }
        [DisplayName("Zip Code")]
        public ZipCode ZipCode { get; set; }
        
        [DisplayName("B2B Responsible")]
        public B2BResponsible B2BResponsible { get; set; }
        [DisplayName("Att.")]
        public string Att { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string CVR { get; set; }
        public CustomerChannel Channel { get; set; }
        public string EAN { get; set; }
        public Reseller Reseller { get; set; }
        public DUNSGroup Industry { get; set; }
        [DisplayName("Job Title")]
        public JobTitle JobTitle { get; set; }
        [DisplayName("Invoicing Address")]
        public string InvoicingAddress { get; set; }
        [DisplayName("Invoicing Email")]
        public string InvoicingEmail { get; set; }
        [DisplayName("Invoicing Zip Code")]
        public ZipCode InvoicingZip { get; set; }
        public bool Newsletter { get; set; }
        public bool Showroom { get; set; }
    }
}
