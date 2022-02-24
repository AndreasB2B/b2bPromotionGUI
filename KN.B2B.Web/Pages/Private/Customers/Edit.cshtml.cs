using KN.B2B.Data;
using KN.B2B.Data.Repository;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Customers
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        private readonly IRequestData _requestData;
        #endregion

        #region Bound Properties
        [BindProperty]
        public Customer B2BCustomer { get; set; }
        [BindProperty]
        public bool IsInvoicingDifferent { get; set; }
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> JobTitles { get; set; }
        public IEnumerable<SelectListItem> Channels { get; set; }
        public IEnumerable<SelectListItem> Resellers { get; set; }
        public IEnumerable<SelectListItem> ZipCodes { get; set; }
        public IEnumerable<SelectListItem> Industries { get; set; }
        public IEnumerable<SelectListItem> B2BResponsibles { get; set; }
        #endregion

        public EditModel(B2BDbContext context, IRequestData requestData)
        {
            _context = context;
            _requestData = requestData;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                B2BCustomer = await _context.Customers.Include(x => x.JobTitle)
                                                      .Include(x => x.ZipCode)
                                                      .Include(x => x.InvoicingZip)
                                                      .Include(x => x.Industry)
                                                      .Include(x => x.Reseller)
                                                      .Include(x => x.B2BResponsible)
                                                      .Include(x => x.Channel)
                                                      .FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                B2BCustomer = new Customer();
                B2BCustomer.CreationDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone); //default to today's date (in danish time)
            }

            await LoadModelCollections();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Set the job title
            var selectedTitle = Request.Form["JobTitleSelect"];
            if (string.IsNullOrEmpty(selectedTitle) == false)
            {
                if (Int32.TryParse(selectedTitle, out var id))
                {
                    var jobTitle = await _context.JobTitles.SingleAsync(x => x.Id == id);
                    B2BCustomer.JobTitle = jobTitle;
                }
            }

            //Set the reseller
            var selectedReseller = Request.Form["ResellerSelect"];
            if (string.IsNullOrEmpty(selectedReseller) == false)
            {
                if (Int32.TryParse(selectedReseller, out var id))
                {
                    var reseller = await _context.Resellers.SingleAsync(x => x.Id == id);
                    B2BCustomer.Reseller = reseller;
                }
            }

            //Set the B2BResponsible
            var selectedOwner = Request.Form["B2BReposnsibleSelect"];
            if (string.IsNullOrEmpty(selectedOwner) == false)
            {
                if (Int32.TryParse(selectedOwner, out var id))
                {
                    var owner = await _context.B2BResponsibles.SingleAsync(x => x.Id == id);
                    B2BCustomer.B2BResponsible = owner;
                }
            }

            //Set the zip code
            var selectedZip = Request.Form["ZipCodeSelect"];
            if (string.IsNullOrEmpty(selectedZip) == false)
            {
                var zip = await Converter.ReduxZipToFullZip(_context, selectedZip);
                if (zip != null)
                    B2BCustomer.ZipCode = zip;

                //if (Int32.TryParse(selectedZip, out var id))
                //{
                //    var zipCode = await _context.ZipCodes.SingleAsync(x => x.Id == id);
                //    B2BCustomer.ZipCode = zipCode;
                //}
            }

            //set invoicing parameters
            if (IsInvoicingDifferent)
            {
                //Set the invoice zip code
                var selectedInvoiceZip = Request.Form["InvoiceZipCodeSelect"];
                if (string.IsNullOrEmpty(selectedInvoiceZip) == false)
                {
                    var zip = await Converter.ReduxZipToFullZip(_context, selectedInvoiceZip);
                    if (zip != null)
                        B2BCustomer.InvoicingZip = zip;
                }
            }
            else //reset them otherwise
            {
                B2BCustomer.InvoicingAddress = null;
                //TODO: This (object nullification) doesn't work, needs https://stackoverflow.com/a/38805404/5744616
                B2BCustomer.InvoicingZip = null;
                B2BCustomer.InvoicingEmail = null;
            }

            //Set the industry
            var selectedIndustry = Request.Form["IndustrySelect"];
            if (string.IsNullOrEmpty(selectedIndustry) == false)
            {
                if (Int32.TryParse(selectedIndustry, out var id))
                {
                    var industry = await _context.Industries.SingleAsync(x => x.Id == id);
                    B2BCustomer.Industry = industry;
                }
            }

            //Set the channel
            var selectedChannel = Request.Form["ChannelSelect"];
            if (string.IsNullOrEmpty(selectedChannel) == false)
            {
                if (Int32.TryParse(selectedChannel, out var id))
                {
                    var channel = await _context.CustomerChannels.SingleAsync(x => x.Id == id);
                    B2BCustomer.Channel = channel;
                }
            }

            if (!ModelState.IsValid)
            {
                await LoadModelCollections();
                return Page();
            }

            if (B2BCustomer.Id == 0) //will be 0 if coming from an 'Add' command
            {
                if (await InvalidCustomer(B2BCustomer))
                    return Page();

                await _requestData.AddCustomerAsync(B2BCustomer);
            }
            else
                _requestData.UpdateCustomer(B2BCustomer);

            var saveResult = await _requestData.CommitAsync();
            if (saveResult == 0)
            {
                //TODO: Log the exception
                //Check if a lead is saved nonetheless and consider deleting it if its in a faulty state
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadModelCollections()
        {
            Channels = await LoadCollections.LoadCustomerChannels(_context, true);
            Resellers = await LoadCollections.LoadResellers(_context, B2BCustomer.Reseller == null); //show empty row only on null, we handle it from the HTML otherwise
            JobTitles = await LoadCollections.LoadJobTitles(_context);
            ZipCodes = await LoadCollections.LoadZipCodesRedux(_context, true);
            Industries = await LoadCollections.LoadIndustries(_context, true);
            B2BResponsibles = await LoadCollections.LoadB2BResponsibles(_context, true);
        }

        private async Task<bool> InvalidCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                return true;

            if (await _context.Customers.AnyAsync(x => x.Name.ToLower() == customer.Name.ToLower()))
            {
                TempData["Message"] = $"A customer with name '{customer.Name}' already exists!";
                return true;
            }

            return false;
        }
    }
}
