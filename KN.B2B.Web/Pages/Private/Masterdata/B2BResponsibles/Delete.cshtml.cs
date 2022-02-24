using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BResponsibles
{
    public class DeleteModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public B2BResponsible B2BResponsible { get; set; }
        #endregion

        #region Properties
        #endregion

        public DeleteModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BResponsible = await _context.B2BResponsibles.FirstOrDefaultAsync(m => m.Id == id);

            if (B2BResponsible == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BResponsible = await _context.B2BResponsibles.FindAsync(id);

            if (B2BResponsible != null)
            {
                _context.B2BResponsibles.Remove(B2BResponsible);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
