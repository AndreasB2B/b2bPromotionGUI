using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BResponsibles
{
    public class EditModel : PageModel
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

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                B2BResponsible = await _context.B2BResponsibles.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                B2BResponsible = new B2BResponsible();
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

            if (B2BResponsibleExists(B2BResponsible.Id) == false)
            {
                _context.B2BResponsibles.Add(B2BResponsible);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(B2BResponsible).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!B2BResponsibleExists(B2BResponsible.Id))
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

        private bool B2BResponsibleExists(int id)
        {
            return _context.B2BResponsibles.Any(e => e.Id == id);
        }
    }
}
