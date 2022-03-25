using KN.B2B.Model;
using KN.B2B.Model.SystemTables;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<> B2BProdducts { get; set; }
        public DbSet<print>
    }
}
