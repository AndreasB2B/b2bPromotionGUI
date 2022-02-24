using KN.B2B.Data;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Requests
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
        public IEnumerable<Request> Requests { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion

        //TODO: Repository pattern => IReuqestData over B2BDbContext
        public IndexModel(B2BDbContext context, ILogger<IndexModel> logger, IConfiguration config/*, IRequestData requestData*/)
        {
            _logger = logger;
            _config = config;
            _context = context;
            //_requestData = requestData;
        }

        public async Task OnGetAsync()
        {
            //var query = HttpContext.Request.Query["searchQuery"]; => Another way to get the data from the querry that led to this page
            Message = _config["Message"];

            if (string.IsNullOrEmpty(SearchQuery) == false)
                Requests = await _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.StartStatus)
                    .Include(x => x.EndStatus)
                    .Where(x => x.Customer.Name.ToLower().Contains(SearchQuery.ToLower()))
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            else
                Requests = await _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.StartStatus)
                    .Include(x => x.EndStatus)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
        }
    }
}
