using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BCategories
{
    public class IndexModel : PageModel
    {
        private readonly KN.B2B.Data.B2BDbContext _context;

        public IndexModel(KN.B2B.Data.B2BDbContext context)
        {
            _context = context;
        }

        public IList<B2BCategory> B2BCategories { get;set; }

        public async Task OnGetAsync()
        {
            B2BCategories = await _context.B2BCategories.Include(x => x.CategoryGroup).ToListAsync();
        }
    }
}
