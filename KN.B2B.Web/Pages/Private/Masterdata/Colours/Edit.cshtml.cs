using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.Colours
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public Colour Colour { get; set; }
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
                Colour = await _context.Colours.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                Colour = new Colour();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (ColorExists(Colour.Id) == false)
            {
                //validate when saving new
                if (await InvalidColor(Colour.Name))
                    return Page();

                _context.Colours.Add(Colour);
                await _context.SaveChangesAsync();
            }
            else
            {

                _context.Attach(Colour).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(Colour.Id))
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

        private async Task<bool> InvalidColor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return true;

            if (await _context.Colours.AnyAsync(e => e.Name.ToLower() == name.ToLower()))
            {
                TempData["Message"] = $"A colour with name '{Colour.Name}' already exists!";
                return true;
            }

            return false;
        }

        private bool ColorExists(int id) 
            => _context.Colours.Any(e => e.Id == id);
    }
}
