using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.StartStatuses
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public StartStatus StartStatus { get; set; }
        #endregion

        #region Properties
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                StartStatus = await _context.StartStatuses.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                StartStatus = new StartStatus();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (StartStatusExists(StartStatus.Id) == false)
            {
                _context.StartStatuses.Add(StartStatus);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(StartStatus).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartStatusExists(StartStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StartStatusExists(int id)
        {
            return _context.StartStatuses.Any(e => e.Id == id);
        }
    }
}
