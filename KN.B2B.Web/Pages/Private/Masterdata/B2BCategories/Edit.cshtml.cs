using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BCategories
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public B2BCategory B2BCategory { get; set; }
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> B2BCategoryGroups { get; set; }
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                B2BCategory = await _context.B2BCategories.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                B2BCategory = new B2BCategory();
            }

            B2BCategoryGroups = await LoadB2BCategoryGroups();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var selectedGroup = Request.Form["B2BGroupSelect"];
            if (string.IsNullOrEmpty(selectedGroup) == false)
            {
                if (Int32.TryParse(selectedGroup, out var id))
                {
                    var group = await _context.B2BCategoryGroups.SingleAsync(x => x.Id == id);
                    B2BCategory.CategoryGroup = group;
                }
                else
                {
                    //Else the user hasn't changed the group - do nothing
                }
            }
            else
            {
                //TODO: Get validation for customer
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (B2BCategoryExists(B2BCategory.Id) == false)
            {
                _context.B2BCategories.Add(B2BCategory);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(B2BCategory).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!B2BCategoryExists(B2BCategory.Id))
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

        private async Task<IEnumerable<SelectListItem>> LoadB2BCategoryGroups()
        {
            var selectList = new List<SelectListItem>();
            var groups = await _context.B2BCategoryGroups.Select(x => x).ToListAsync();
            foreach (var group in groups)
            {
                selectList.Add(new SelectListItem(group.CategoryGroup, group.Id.ToString()));
            }
            return selectList;
        }

        private bool B2BCategoryExists(int id)
        {
            return _context.B2BCategories.Any(e => e.Id == id);
        }
    }
}
