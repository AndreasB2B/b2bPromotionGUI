using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BResponsibles
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Properties
        public IList<B2BResponsible> B2BResponsibles { get; set; }
        #endregion

        public IndexModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            B2BResponsibles = await _context.B2BResponsibles.ToListAsync();
        }
    }
}
