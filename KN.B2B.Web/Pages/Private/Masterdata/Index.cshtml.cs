using KN.B2B.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        private readonly B2BDbContext _context;
        //private readonly IRequestData _requestData;
        #endregion

        #region Properties
        public string Message { get; set; }
        public int Suppliers { get; set; }
        public int B2BCategories { get; set; }
        public int B2BCategoryGroups { get; set; }
        public int B2BPrintTypes { get; set; }
        public int B2BPrintPositions { get; set; }
        public int JobTitles { get; set; }
        public int Industries { get; set; }
        public int Complaints { get; set; }
        public int EndStatuses { get; set; }
        public int StartStatuses { get; set; }
        public int Resellers { get; set; }
        public int B2BResponsibles { get; set; }
        public int Colours { get; set; }
        public int CustomerChannels { get; set; }
        public int CancellationReasons { get; set; }
        public int CurrentStatuses { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion

        //TODO: Repository pattern => IRequestData over B2BDbContext
        public IndexModel(B2BDbContext context, ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _context = context;
            //_requestData = requestData;
        }

        public async Task OnGetAsync()
        {
            Message = _config["Message"];
            Suppliers = await _context.Suppliers.CountAsync();
            B2BCategories = await _context.B2BCategories.CountAsync();
            B2BCategoryGroups = await _context.B2BCategoryGroups.CountAsync();
            JobTitles = await _context.JobTitles.CountAsync();
            Industries = await _context.Industries.CountAsync();
            Complaints = await _context.Complaints.CountAsync();
            StartStatuses = await _context.StartStatuses.CountAsync();
            EndStatuses = await _context.EndStatuses.CountAsync();
            Resellers = await _context.Resellers.CountAsync();
            B2BResponsibles = await _context.B2BResponsibles.CountAsync();
            Colours = await _context.Colours.CountAsync();
            CustomerChannels = await _context.CustomerChannels.CountAsync();
            CancellationReasons = await _context.CancellationReasons.CountAsync();
            CurrentStatuses = await _context.CurrentStatuses.CountAsync();
            B2BPrintTypes = await _context.B2BPrintTypes.CountAsync();
            B2BPrintPositions = await _context.B2BPrintPositions.CountAsync();
        }
    }
}
