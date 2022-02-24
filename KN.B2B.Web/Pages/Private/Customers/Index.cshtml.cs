using KN.B2B.Data.Repository;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Customers
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly IRequestData _requestData;
        #endregion

        #region Properties
        public IList<Customer> Customers { get;set; }
        #endregion

        #region Bound Properties
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion

        public IndexModel(IRequestData requestData)
        {
            _requestData = requestData;
        }

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(SearchQuery) == false)
                Customers = _requestData.GetCustomersByName(SearchQuery).ToList();
            else
            { 
                var customers = await _requestData.GetAllCustomersAsync();
                Customers = customers.ToList();
            }
        }
    }
}
