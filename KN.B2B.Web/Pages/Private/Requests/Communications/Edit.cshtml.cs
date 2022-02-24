using KN.B2B.Data;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Requests.Communications
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public RequestCommunication Communication { get; set; }
        [BindProperty]
        public Request ParentRequest { get; set; }
        #endregion

        #region Properties
        //private Request ParentRequest { get; set; }
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id, int reqId)
        {
            if (id.HasValue)
            {
                Communication = await _context.RequestCommunications.FirstOrDefaultAsync(x => x.Id == id.Value);
            }
            else
            {
                Communication = new RequestCommunication();
                Communication.Date = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone); //default to today's date
            }
            ParentRequest = _context.Requests.FirstOrDefault(x => x.Id == reqId);
            return Page();
        }

        //Multiple handlers: https://www.learnrazorpages.com/razor-pages/handler-methods#handling-multiple-actions-for-the-same-form
        public async Task<IActionResult> OnPostCommAsync()
        {
            if (!ModelState.IsValid)
                return NotFound(); //TODO: Return error page

            //get the request this communication belongs to;
            var fetchedRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == ParentRequest.Id);
            if (fetchedRequest == null)
                return NotFound(); //TODO: this would mean that the request has been deleted in the mean time - notify the user

            Communication.Request = fetchedRequest;

            if (CommunicationExists(Communication.Id) == false)
            {
                _context.RequestCommunications.Add(Communication);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(Communication).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunicationExists(Communication.Id))
                        return NotFound(); //TODO: this would mean that the request has been deleted in the mean time - notify the user
                    else
                        throw;
                }
            }
            return RedirectToPage("../Edit", new { id = ParentRequest.Id});
        }

        public async Task<IActionResult> OnPostDeleteCommAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Communication = await _context.RequestCommunications.FindAsync(id);

            if (Communication != null)
            {
                _context.RequestCommunications.Remove(Communication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Edit", new { id = ParentRequest.Id });
        }

        private bool CommunicationExists(int id)
        {
            return _context.RequestCommunications.Any(e => e.Id == id);
        }
    }
}
