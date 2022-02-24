using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.Industries
{
    public class IndexModel : PageModel
    {
        private readonly KN.B2B.Data.B2BDbContext _context;

        public IndexModel(KN.B2B.Data.B2BDbContext context)
        {
            _context = context;
        }

        public IList<DUNSGroup> Industries { get;set; }

        public async Task OnGetAsync()
        {
            Industries = await _context.Industries.ToListAsync();
        }
    }
}
