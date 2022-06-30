using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Web.Models;
using OfficeOpenXml;
using System;
using System.Threading.Tasks;

namespace KN.B2B.Web.Services.Products
{
    public interface IMasterProductImport
    {
        public void ImportProducts(CustomProduct customProducts, B2BDbContext _context);
        public string ReturnData(ExcelWorksheet workSheet, int row, int col);
        public Double ReturnDataDouble(ExcelWorksheet workSheet, int row, int col);
    }
}
