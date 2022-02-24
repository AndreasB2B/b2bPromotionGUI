using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.JobTitles
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public JobTitle JobTitle { get; set; }
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
                JobTitle = await _context.JobTitles.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                JobTitle = new JobTitle();
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

            if (JobTitleExists(JobTitle.Id) == false)
            {
                _context.JobTitles.Add(JobTitle);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(JobTitle).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTitleExists(JobTitle.Id))
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

        private bool JobTitleExists(int id)
        {
            return _context.JobTitles.Any(e => e.Id == id);
        }
    }
}
