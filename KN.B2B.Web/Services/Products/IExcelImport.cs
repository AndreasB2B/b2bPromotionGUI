using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Web.Models;
using System.Collections.Generic;
using System.IO;

namespace KN.B2B.Web.Services.Products
{
    public interface IExcelImport
    {
        List<CustomProduct> readXLS(string FilePath, B2BDbContext _context);
        void readXLS2(Stream stream, int countryId, int siteId, string database);
    }
}
