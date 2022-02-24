using KN.B2B.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Data.Repository
{
    public interface IRequestData
    {
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        IEnumerable<Customer> GetCustomersByName(string nameQuery);
        Task<Customer> GetCustomerByIDAsync(int id);
        Customer GetCustomerByID(int id);
        Task<Customer> AddCustomerAsync(Customer newLead);
        Customer UpdateCustomer(Customer updatedLead);
        bool DeleteCustomer(int id, out Customer deleted);
        Task<int> CommitAsync();
    }
}
