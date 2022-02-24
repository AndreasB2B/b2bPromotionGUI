using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BPrintPositions
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Properties
        public IList<B2BPrintPosition> B2BPrintPositions { get; set; }
        #endregion

        public IndexModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            B2BPrintPositions = await _context.B2BPrintPositions.ToListAsync();
        }
    }
}
