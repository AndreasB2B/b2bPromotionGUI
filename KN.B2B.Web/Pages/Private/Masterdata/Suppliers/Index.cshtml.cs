using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly KN.B2B.Data.B2BDbContext _context;

        public IndexModel(KN.B2B.Data.B2BDbContext context)
        {
            _context = context;
        }

        public IList<Supplier> Suppliers { get;set; }

        public async Task OnGetAsync()
        {
            Suppliers = await _context.Suppliers.ToListAsync();
        }
    }
}
