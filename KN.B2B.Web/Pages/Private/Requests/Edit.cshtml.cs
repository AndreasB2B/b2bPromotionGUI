using KN.B2B.Data;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Requests
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Channels { get; set; }
        public IEnumerable<SelectListItem> StartStatuses { get; set; }
        public IEnumerable<SelectListItem> EndStatuses { get; set; }
        public IEnumerable<SelectListItem> CurrentStatuses { get; set; }
        public IEnumerable<SelectListItem> CancellationReasons { get; set; }
        public IEnumerable<RequestCommunication> Communications { get; set; }
        public IEnumerable<RequestProduct> Products { get; set; }
        public IEnumerable<SelectListItem> ZipCodes { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty]
        public Request B2BRequest { get; set; }
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                B2BRequest = await _context.Requests.Include(x => x.Customer)
                                                    .Include(x => x.StartStatus)
                                                    .Include(x => x.EndStatus)
                                                    .Include(x => x.CurrentStatus)
                                                    .Include(x => x.CancellationReason)
                                                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                B2BRequest = SetDefaultDates(new Request());
                B2BRequest.EndStatus = _context.EndStatuses.AsNoTracking().First(x => x.Status == "Open");
                B2BRequest.CurrentStatus = _context.CurrentStatuses.AsNoTracking().First(x => x.Name == "Pending B2B");
            }

            if (B2BRequest == null)
                return NotFound();

            await LoadModelCollections();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var selectedCustomer = Request.Form["CustomerSelect"];
            if (string.IsNullOrEmpty(selectedCustomer) == false)
            {
                if (Int32.TryParse(selectedCustomer, out var id))
                {
                    var customer = await _context.Customers.SingleAsync(x => x.Id == id);
                    B2BRequest.Customer = customer;
                }
            }

            var selectedStartStatus = Request.Form["StartStatusSelect"];
            if (string.IsNullOrEmpty(selectedStartStatus) == false)
            {
                if (Int32.TryParse(selectedStartStatus, out var id))
                {
                    var status = await _context.StartStatuses.SingleAsync(x => x.Id == id);
                    B2BRequest.StartStatus = status;
                }
            }

            var selectedEndStatus = Request.Form["EndStatusSelect"];
            if (string.IsNullOrEmpty(selectedEndStatus) == false)
            {
                if (Int32.TryParse(selectedEndStatus, out var id))
                {
                    var status = await _context.EndStatuses.SingleAsync(x => x.Id == id);
                    B2BRequest.EndStatus = status;
                }
            }

            var selectedCurrentStatus = Request.Form["CurrentStatusSelect"];
            if (string.IsNullOrEmpty(selectedCurrentStatus) == false)
            {
                if (Int32.TryParse(selectedCurrentStatus, out var id))
                {
                    var status = await _context.CurrentStatuses.SingleAsync(x => x.Id == id);
                    B2BRequest.CurrentStatus = status;
                }
            }

            var selectedCancellationReason = Request.Form["CancellationReasonSelect"];
            if (string.IsNullOrEmpty(selectedCancellationReason) == false)
            {
                if (Int32.TryParse(selectedCancellationReason, out var id))
                {
                    var reason = await _context.CancellationReasons.SingleAsync(x => x.Id == id);
                    B2BRequest.CancellationReason = reason;
                }
            }

            var selectedZip = Request.Form["ZipCodeSelect"];
            if (string.IsNullOrEmpty(selectedZip) == false)
            {
                var zip = await Converter.ReduxZipToFullZip(_context, selectedZip);
                if (zip != null)
                    B2BRequest.DeliveryZip = zip;
            }

            //clean-up cancellation reason if not cancelled
            if (B2BRequest.EndStatus != null && B2BRequest.EndStatus.Status != "Cancelled")
                B2BRequest.CancellationReason = null;

            //clean-up sample dates if not a sample
            if (B2BRequest.StartStatus != null && B2BRequest.StartStatus.Status != "Sample")
            {
                B2BRequest.SampleRequested = null;
                B2BRequest.SampleSent = null;
                B2BRequest.SampleApproved = null;
            }

            //clean-up trust pilot date if no trust pilot
            if (B2BRequest.TrustPilot == false)
                B2BRequest.TrustPilotDate = null;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (RequestExists(B2BRequest.Id) == false)
            {
                _context.Requests.Add(B2BRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(B2BRequest).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(B2BRequest.Id))
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

        private async Task LoadModelCollections()
        {
            CancellationReasons = await LoadCollections.LoadCancellationReasons(_context, true);
            StartStatuses = await LoadCollections.LoadStartStatuses(_context, B2BRequest.StartStatus == null); //show empty row only on null, we handle it from the HTML otherwise
            EndStatuses = await LoadCollections.LoadEndStatuses(_context, B2BRequest.EndStatus == null); //show empty row only on null, we handle it from the HTML otherwise
            CurrentStatuses = await LoadCollections.LoadCurrentStatuses(_context, true);
            Communications = await LoadCollections.LoadCommunications(_context, B2BRequest.Id);
            Products = await LoadCollections.LoadProducts(_context, B2BRequest.Id);
            Customers = await LoadCollections.LoadCustomers(_context);
            ZipCodes = await LoadCollections.LoadZipCodesRedux(_context, true);
        }

        private Request SetDefaultDates(Request newRequest)
        {
            newRequest.RequestDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone); //default to today's date (in danish tmz)
            newRequest.RequestDeadline = GetNextWorkingDay(DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone).AddDays(1)); //default to tomorrow's date (in danish tmz)
            return newRequest;
        }

        private bool RequestExists(int id) 
            => _context.Requests.Any(e => e.Id == id);

        private DateTime GetNextWorkingDay(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    date = date.AddDays(3);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    break;
                default:
                    break;
            }
            return date;
        }
    }
}
