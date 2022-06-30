using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using System.Collections.Generic;

namespace KN.B2B.Web.Services
{
    public class CategoryManagement
    {
        private readonly B2BDbContext _db;


        public CategoryManagement(B2BDbContext db)
        {
            _db = db;
        }

        public void insertCategories()
        {
            // TODO ===> BUG -> inserts FI on DK's place

            List<B2BCategory> categories = new List<B2BCategory>();

            B2BCategory category2 = new B2BCategory
            {
                Category = "Office & work",
                CategoryDK = "Toimisto",
                CategoryFI = "Kontor & Arbejde",
            };

            B2BCategory category3 = new B2BCategory
            {
                Category = "Leisure & Outdoor life",
                CategoryDK = "Vapaa-aika & Ulkoilu",
                CategoryFI = "Fritid & Udeliv",
            };

            B2BCategory category4 = new B2BCategory
            {
                Category = "Keychains & Lanyards",
                CategoryDK = "Avaimenperät & Avainnauhat",
                CategoryFI = "Nøgleringe & Nøglesnore",
            };

            B2BCategory category6 = new B2BCategory
            {
                Category = "Notebooks & Notepads",
                CategoryFI = "Muistikirjat & Muistivihkot",
                CategoryDK = "Muistikirjat & Muistivihkot",
            };

            B2BCategory category5 = new B2BCategory
            {
                Category = "Drinking bottles and Thermos",
                CategoryFI = "Juomapullot & Termokset",
                CategoryDK = "Drikkedunke & Termoflasker",
            };
            B2BCategory category7 = new B2BCategory
            {
                Category = "Kitchen",
                CategoryFI = "Keittiö",
                CategoryDK = "Køkken",
            };
            B2BCategory category8 = new B2BCategory
            {
                Category = "Umbrellas & Raincoats",
                CategoryFI = "Sateenvarjot & Sadeasut",
                CategoryDK = "Paraplyer & Regnslag",
            };

            B2BCategory category9 = new B2BCategory
            {
                Category = "Antistress",
                CategoryFI = "Stressilelut",
                CategoryDK = "Antistress",
            };

            B2BCategory category11 = new B2BCategory
            {
                Category = "Tote Bags & Shopping Bags",
                CategoryFI = "Ostos- & Kangaskassit",
                CategoryDK = "Muleposer & Indkøbstasker",
            };

            B2BCategory category12 = new B2BCategory
            {
                Category = "Suitcase & Travel Products",
                CategoryFI = "Matkustaminen",
                CategoryDK = "Kuffert- & Rejseprodukter",
            };

            B2BCategory category13 = new B2BCategory
            {
                Category = "Bags & backpacks",
                CategoryFI = "Laukut & Reput",
                CategoryDK = "Tasker & rygsække",
            };

            B2BCategory category14 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            B2BCategory category15 = new B2BCategory
            {
                Category = "Food & Wine accessories",
                CategoryFI = "Ruoka- & Viinitarvikkeet",
                CategoryDK = "Mad- & Vintilbehør",
            };

            B2BCategory category16 = new B2BCategory
            {
                Category = "At home",
                CategoryFI = "Koti",
                CategoryDK = "Hjemme",
            };

            B2BCategory category17 = new B2BCategory
            {
                Category = "Flashlights & Tools",
                CategoryFI = "Taskulamput & Työkalut",
                CategoryDK = "Lommelygter & Værktøj",
            };

            B2BCategory category18 = new B2BCategory
            {
                Category = "Pens & Pencils",
                CategoryFI = "Kynät & Kirjoitusvälineet",
                CategoryDK = "Kuglepenne & Blyanter",
            };



            B2BCategory category19 = new B2BCategory
            {
                Category = "Document & Portfolio",
                CategoryFI = "Dokumenttikansiot & Portfoliot",
                CategoryDK = "Dokument & Portfolio",
            };

            B2BCategory category20 = new B2BCategory
            {
                Category = "Toys & Games",
                CategoryFI = "Lelut & Pelit",
                CategoryDK = "Legetøj & Spil",
            };

            B2BCategory category21 = new B2BCategory
            {
                Category = "Hats",
                CategoryFI = "Päähineet",
                CategoryDK = "Huer",
            };

            B2BCategory category22 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            B2BCategory category23 = new B2BCategory
            {
                Category = "USB & Accessories",
                CategoryFI = "USB & Tarvikkeet",
                CategoryDK = "USB & Tilbehør",
            };


            B2BCategory category24 = new B2BCategory
            {
                Category = "Belts & Accessories",
                CategoryFI = "Vyöt & Asusteet",
                CategoryDK = "Bælter & Accessories",
            };

            B2BCategory category25 = new B2BCategory
            {
                Category = "Electronics & Gadgets",
                CategoryFI = "Elektroniikka & Laitteet",
                CategoryDK = "Elektronik & Gadgets",
            };

            B2BCategory category26 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);
            categories.Add(category6);
            categories.Add(category7);
            categories.Add(category8);
            categories.Add(category9);
            categories.Add(category11);
            categories.Add(category12);
            categories.Add(category13);
            categories.Add(category14);
            categories.Add(category15);
            categories.Add(category16);
            categories.Add(category17);
            categories.Add(category18);
            categories.Add(category19);
            categories.Add(category20);
            categories.Add(category21);
            categories.Add(category22);
            categories.Add(category23);
            categories.Add(category24);
            categories.Add(category25);
            categories.Add(category26);

            for (int i = 0; categories.Count > i; i++)
            {
                _db.B2BCategories.Add(categories[i]);
                _db.SaveChanges();
            }


        }
    }
}
