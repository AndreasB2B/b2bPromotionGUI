using KN.B2B.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Data.Repository.SqlServer
{
    public class MsSqlRequestData : IRequestData
    {
        private readonly B2BDbContext _db;
        public MsSqlRequestData(B2BDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        => await _db.Requests.ToListAsync();

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() 
            => await _db.Customers.OrderBy(x => x.Name).Include(x => x.B2BResponsible).ToListAsync();

        public IEnumerable<Customer> GetCustomersByName(string nameQuery) 
            => _db.Customers.Where(x => x.Name.ToLower().Contains(nameQuery.ToLower()) || string.IsNullOrEmpty(nameQuery)).OrderBy(x => x.Name);

        public async Task<Customer> GetCustomerByIDAsync(int id) 
            => await _db.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Customer GetCustomerByID(int id)
            => _db.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public async Task<Customer> AddCustomerAsync(Customer newCustomer)
        {
            await _db.Customers.AddAsync(newCustomer);
            return newCustomer;
        }

        public Customer UpdateCustomer(Customer updatedLead)
        {
            var entity = _db.Attach(updatedLead);
            entity.State = EntityState.Modified;
            return updatedLead;
        }

        public bool DeleteCustomer(int id, out Customer deletedLead)
        {
            var leadToDel = GetCustomerByID(id);
            if (leadToDel != null)
            {
                _db.Customers.Remove(leadToDel);
                deletedLead = leadToDel;
                return true;
            }
            deletedLead = null;
            return false;
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: Logging
                return 0;
            }
        }
    }
}
