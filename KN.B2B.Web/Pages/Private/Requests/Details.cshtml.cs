using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KN.B2B.Data;
using KN.B2B.Model;

namespace KN.B2B.Web.Pages.Private.Requests
{
    public class DetailsModel : PageModel
    {
        private readonly KN.B2B.Data.B2BDbContext _context;

        public DetailsModel(KN.B2B.Data.B2BDbContext context)
        {
            _context = context;
        }

        public Request B2BRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BRequest = await _context.Requests.FirstOrDefaultAsync(m => m.Id == id);

            if (B2BRequest == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
