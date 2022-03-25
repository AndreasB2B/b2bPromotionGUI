using KN.B2B.Model;
using KN.B2B.Model.SystemTables;
using KN.B2B.Model.products;
using Microsoft.EntityFrameworkCore;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.products.productPrice;

namespace KN.B2B.Data
{
    public class B2BDbContext : DbContext
    {
        public B2BDbContext(DbContextOptions<B2BDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestCommunication> RequestCommunications { get; set; }
        public DbSet<RequestProduct> RequestProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<B2BCategory> B2BCategories { get; set; }
        public DbSet<B2BCategoryGroup> B2BCategoryGroups { get; set; }
        public DbSet<B2BResponsible> B2BResponsibles { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        //public DbSet<B2BSupplierProducts> b2BSupplierProducts { get; set; }
        public DbSet<DUNSGroup> Industries { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<StartStatus> StartStatuses { get; set; }
        public DbSet<EndStatus> EndStatuses { get; set; }
        public DbSet<CurrentStatus> CurrentStatuses { get; set; }
        public DbSet<Reseller> Resellers { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<CancellationReason> CancellationReasons { get; set; }
        public DbSet<CustomerChannel> CustomerChannels { get; set; }
        public DbSet<B2BPrintPosition> B2BPrintPositions { get; set; }
        public DbSet<B2BPrintType> B2BPrintTypes { get; set; }
        // NEW TABLES
        public DbSet<B2BProduct> B2BProdducts { get; set; }
        public DbSet<B2BParrentProducts> B2BParrentProducts { get; set; }
        //public DbSet<B2BPrintPosition2> B2BPrintPositions2 { get; set; }
        public DbSet<B2BPrintTechnique> B2BPrintTechniques { get; set; }
        public DbSet<SupplierHandles> SupplierHandles { get; set; }
        public DbSet<SupplierPrintCost> SupplierPrintCosts { get; set; }
        public DbSet<SupplierPrintPrice> SupplierPrintPrices { get; set; }
        public DbSet<SupplierPrintPriceScales> SupplierPrintPriceScales { get; set; }
        public DbSet<B2BPriceClass> B2BPriceClasses { get; set; }
        public DbSet<B2BPriceScale> B2BPriceScales { get; set; }
        public DbSet<B2BProductPrice> B2BProductPrices { get; set; }
    }
}
