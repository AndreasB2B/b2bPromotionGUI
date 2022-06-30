using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Web.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Threading.Tasks;

namespace KN.B2B.Web.Services.Products
{
    public class MasterProductsImport : IMasterProductImport
    {
        private readonly B2BDbContext _context2;

        public B2BParrentProducts parrentProduct { get; set; }
        public B2BProduct childProduct { get; set; }


        public MasterProductsImport(B2BDbContext context)
        {
            _context2 = context;
        }

        public string ReturnData(ExcelWorksheet workSheet, int row, int col)
        {
            if (workSheet.Cells[row, col].Value != null)
            {
                return workSheet.Cells[row, col].Value.ToString().Trim();
            }
            return "";
        }

        public Double ReturnDataDouble(ExcelWorksheet workSheet, int row, int col)
        {
            //var data = workSheet.Cells[row, col].Value.ToString().Trim();
            if (workSheet.Cells[row, col].Value != null)
            {
                //if(workSheet.Cells[row, col].Value.ToString().Trim() == " ")
                //{
                //    return 0;
                //}
                return Convert.ToDouble(workSheet.Cells[row, col].Value.ToString().Trim());
            }
            return 0;
        }

        public async void ImportProducts(CustomProduct customProduct, B2BDbContext _context)
        {

            //await LoadCollections.DoesParrentProductExist(_context, customProduct);


            //parrentProduct = await _context.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_masterId == customProduct.ParentSKU);
            //childProduct = await _context.B2BProdducts.FirstOrDefaultAsync(x => x.product_sku == customProduct.SKU);


            //Console.WriteLine(parrentProduct);
            //Console.WriteLine(childProduct);
            //if (parrentProduct == null)
            //{
            try
            {


                    // ==== INSERT PARRENT PRODUCTS ===

                    // EXCELSHEET MISSING:
                    // - MASTERSKU
                    // - PRINT POSITIONS NUMBERS (1-6)
                    // - DIMENSIONS
                    // - ALSO - LENGTH, HEIGHT AND WIDTH
                    // - SHORT DESCRIPTION
                    // - PRINTABLE
                    // - SUBCATEGORY
                    B2BParrentProducts masterParrentProduct = new B2BParrentProducts
                    {
                        parrentProduct_productName = customProduct.InternetName,
                        parrentProduct_parrentSku = customProduct.ParentSKU,
                        parrentProduct_longDescription = customProduct.InternetTxt,
                        parrentProduct_material = customProduct.Material,
                        parrentProduct_mainCategory = customProduct.MainGroup,
                    };

                    Console.WriteLine(masterParrentProduct);
                    _context2.B2BParrentProducts.Add(masterParrentProduct);
                    _context2.SaveChanges();

                    if (childProduct == null)
                    {

                        // ==== INSERT CHILD PRODUCTS ===

                        // EXCEL SHEET MISSING:
                        // - 
                        B2BProduct masterChildProduct = new B2BProduct
                        {
                            product_sku = customProduct.SKU,
                            fk_ParentSKU = masterParrentProduct,
                            product_ColorName = customProduct.ColorName,
                            product_brandNames = customProduct.Brandnames,
                            product_shortDescriptionDK = customProduct.InternetName,
                            product_longDescriptionDK = customProduct.InternetTxt
                        };
                        Console.WriteLine(masterChildProduct);

                        _context2.B2BProdducts.Add(masterChildProduct);
                        _context2.SaveChanges();


                        // ==== INSERT IMAGES ===
                        B2BProductImages imageObj = new B2BProductImages();

                        string[] images = customProduct.ProductImageURL.Split(',');
                        foreach (var image in images)
                        {
                            imageObj.imagePath = image;
                            imageObj.fk_childProduct = masterChildProduct;

                            Console.WriteLine(imageObj);

                            _context2.B2BProductImages.Add(imageObj);
                            _context2.SaveChanges();
                        }


                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            //}

        }
    }
}