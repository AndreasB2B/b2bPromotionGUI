using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Web.Models;
using KN.B2B.Web.Services.Products;
using KN.B2B.Web.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class ImportProductsModel : PageModel
    {
        private readonly IExcelImport _excelImport;
        private readonly B2BDbContext _context;
        public readonly IMasterProductImport _masterProductImport;

        public ImportProductsModel(IExcelImport excelImport, B2BDbContext context, IMasterProductImport masterProductImport)
        {
            _excelImport = excelImport;
            _masterProductImport = masterProductImport;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(FileModel image, IFormFile uploadFile)
        {

            List<B2BParrentProducts> parrentProduct = await LoadCollections.LoadAllParrentProducts(_context);
            List<B2BProduct> childProduct = await LoadCollections.LoadAllProducts(_context);

            Console.WriteLine(parrentProduct);
            Console.WriteLine(childProduct);

            string fileName = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "-" + "products" + ".csv";

            if (uploadFile != null && uploadFile.Length > 0)
            {
                //var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "assets/excelUploads/", fileName);
                image.Path = filePath;

                //_context.Images.Add(image);
                //_context.SaveChanges();

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    //_excelImport.readXLS(fileSrteam, 1, 1, "");
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }

            List<CustomProduct> customProducts = _excelImport.readXLS(Path.Combine(Directory.GetCurrentDirectory(), "assets/excelUploads/", fileName), _context);
            var allParrentProducts = await LoadCollections.LoadAllParrentProducts(_context);
            bool productExists = true;




            foreach (var product in customProducts)
            {
                bool exists = allParrentProducts.Any(p => p.parrentProduct_parrentSku == product.ParentSKU);
                if (!exists)
                {
                    _masterProductImport.ImportProducts(product, _context);

                    Console.WriteLine(product);
                    // element exists, do what you need
                }
                else
                {

                }

                //for (int i = 0; i < allParrentProducts.Count(); i++)
                //{
                //    customProducts.Contains(allParrentProducts[i].parrentProduct_parrentSku);
                //    if(product.SKU == allParrentProducts[i].parrentProduct_parrentSku)
                //    {
                //        productExists = true;
                //    }
                //    else
                //    {
                //        productExists = false;
                //    }
                //}
                if (productExists == false)
                {
                    _masterProductImport.ImportProducts(product, _context);
                }

            }

            //_masterProductImport.ImportProducts(customProduct, _context);
            return RedirectToAction("viewAll");
            
        }

        public FileModel UploadSingle(IFormFile file)
        {
            FileModel fileDetails;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = reader.ReadToEnd();
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                fileDetails = new FileModel
                {
                    Filename = parsedContentDisposition.FileName,
                    Content = fileContent
                };
            }

            return fileDetails;
        }

    }
}
