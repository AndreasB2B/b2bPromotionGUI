using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.CurrentStatuses
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Properties
        public IList<CurrentStatus> CurrentStatuses { get; set; }
        #endregion

        public IndexModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            CurrentStatuses = await _context.CurrentStatuses.ToListAsync();
        }
    }
}
