using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using KN.B2B.Model.SystemTables;

namespace KN.B2B.Web.Services.Products.Categories
{
    public class SortMNCategories
    {
        public B2BCategory asignCategories(Variant product, string country)
        {
            B2BCategory category;

            if (country == "fi")
            {

                switch (product.category_level2)
                {
                    case "Office accessories":
                        category = new B2BCategory
                        {
                            Category = "Office & work",
                            CategoryDK = "Toimisto",
                            CategoryFI = "Kontor & Arbejde",
                        };
                        return category;
                    case "Outdoor":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Key rings":
                        category = new B2BCategory
                        {
                            Category = "Keychains & Lanyards",
                            CategoryDK = "Avaimenperät & Avainnauhat",
                            CategoryFI = "Nøgleringe & Nøglesnore",
                        };
                        return category;
                    case "Notebooks":
                        category = new B2BCategory
                        {
                            Category = "Notebooks & Notepads",
                            CategoryFI = "Muistikirjat & Muistivihkot",
                            CategoryDK = "Muistikirjat & Muistivihkot",
                        };
                        return category;
                    case "Drinkware":
                        category = new B2BCategory
                        {
                            Category = "Drinking bottles and Thermos",
                            CategoryFI = "Juomapullot & Termokset",
                            CategoryDK = "Drikkedunke & Termoflasker",
                        };
                        return category;
                    case "Stuffed animals":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Kitchenware":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Rain gear":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Anti stress/Candies":
                        category = new B2BCategory
                        {
                            Category = "Antistress",
                            CategoryFI = "Stressilelut",
                            CategoryDK = "Antistress",
                        };
                        return category;
                    case "Shopping bags":
                        category = new B2BCategory
                        {
                            Category = "Tote Bags & Shopping Bags",
                            CategoryFI = "Ostos- & Kangaskassit",
                            CategoryDK = "Muleposer & Indkøbstasker",
                        };
                        return category;
                    case "Travel accessories":
                        category = new B2BCategory
                        {
                            Category = "Suitcase & Travel Products",
                            CategoryFI = "Matkustaminen",
                            CategoryDK = "Kuffert- & Rejseprodukter",
                        };
                        return category;
                    case "Backpacks & Business bags":
                        category = new B2BCategory
                        {
                            Category = "Bags & backpacks",
                            CategoryFI = "Laukut & Reput",
                            CategoryDK = "Tasker & rygsække",
                        };
                        return category;
                    case "Personal care":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "Barware":
                        category = new B2BCategory
                        {
                            Category = "Food & Wine accessories",
                            CategoryFI = "Ruoka- & Viinitarvikkeet",
                            CategoryDK = "Mad- & Vintilbehør",
                        };
                        return category;
                    case "Home & Living":
                        category = new B2BCategory
                        {
                            Category = "At home",
                            CategoryFI = "Koti",
                            CategoryDK = "Hjemme",
                        };
                        return category;
                    case "Tools & Torches":
                        category = new B2BCategory
                        {
                            Category = "Flashlights & Tools",
                            CategoryFI = "Taskulamput & Työkalut",
                            CategoryDK = "Lommelygter & Værktøj",
                        };
                        return category;
                    case "Writing":
                        category = new B2BCategory
                        {
                            Category = "pens & pencils",
                            CategoryFI = "kynät & kirjoitusvälineet",
                            CategoryDK = "kuglepenne & blyanter",
                        };
                        return category;
                    case "Portfolios":
                        category = new B2BCategory
                        {
                            Category = "Document & Portfolio",
                            CategoryFI = "Dokumenttikansiot & Portfoliot",
                            CategoryDK = "Dokument & Portfolio",
                        };
                        return category;
                    case "Head gear":
                        category = new B2BCategory
                        {
                            Category = "Hats",
                            CategoryFI = "Päähineet",
                            CategoryDK = "Huer",
                        };
                        return category;
                    case "Games":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Car accessories":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Umbrellas":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Sport & Health":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "First aid":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "USBs":
                        category = new B2BCategory
                        {
                            Category = "USB & Accessories",
                            CategoryFI = "USB & Tarvikkeet",
                            CategoryDK = "USB & Tilbehør",
                        };
                        return category;
                    case "Chargers":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Phone accessories":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Eye wear":
                        category = new B2BCategory
                        {
                            Category = "Belts & Accessories",
                            CategoryFI = "Vyöt & Asusteet",
                            CategoryDK = "Bælter & Accessories",
                        };
                        return category;
                    case "Lunchware":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Audio & Sound":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Wireless Chargers":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Power banks":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Windproof Umbrellas":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Care essentials":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    default:
                        return null;
                }
            }
            if (country == "da")
            {
                switch (product.category_level2)
                {
                    case "Kontorstilbehør":
                        category = new B2BCategory
                        {
                            Category = "Office & work",
                            CategoryDK = "Toimisto",
                            CategoryFI = "Kontor & Arbejde",
                        };
                        return category;
                    case "Udendørs":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Nøgleringe":
                        category = new B2BCategory
                        {
                            Category = "Keychains & Lanyards",
                            CategoryDK = "Avaimenperät & Avainnauhat",
                            CategoryFI = "Nøgleringe & Nøglesnore",
                        };
                        return category;
                    case "Notesbøger":
                        category = new B2BCategory
                        {
                            Category = "Notebooks & Notepads",
                            CategoryFI = "Muistikirjat & Muistivihkot",
                            CategoryDK = "Muistikirjat & Muistivihkot",
                        };
                        return category;
                    case "Drikkevarer":
                        category = new B2BCategory
                        {
                            Category = "Drinking bottles and Thermos",
                            CategoryFI = "Juomapullot & Termokset",
                            CategoryDK = "Drikkedunke & Termoflasker",
                        };
                        return category;
                    case "Bamser":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Køkkenprodukter":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Regntøj":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Anti stress/slik":
                        category = new B2BCategory
                        {
                            Category = "Antistress",
                            CategoryFI = "Stressilelut",
                            CategoryDK = "Antistress",
                        };
                        return category;
                    case "Indkøbsposer":
                        category = new B2BCategory
                        {
                            Category = "Tote Bags & Shopping Bags",
                            CategoryFI = "Ostos- & Kangaskassit",
                            CategoryDK = "Muleposer & Indkøbstasker",
                        };
                        return category;
                    case "Rejsetilbehør":
                        category = new B2BCategory
                        {
                            Category = "Suitcase & Travel Products",
                            CategoryFI = "Matkustaminen",
                            CategoryDK = "Kuffert- & Rejseprodukter",
                        };
                        return category;
                    case "Rygsæk & Portofølger":
                        category = new B2BCategory
                        {
                            Category = "Bags & backpacks",
                            CategoryFI = "Laukut & Reput",
                            CategoryDK = "Tasker & rygsække",
                        };
                        return category;
                    case "Personlig pleje":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "Barprodukter":
                        category = new B2BCategory
                        {
                            Category = "Food & Wine accessories",
                            CategoryFI = "Ruoka- & Viinitarvikkeet",
                            CategoryDK = "Mad- & Vintilbehør",
                        };
                        return category;
                    case "Hjem & Livsstil":
                        category = new B2BCategory
                        {
                            Category = "At home",
                            CategoryFI = "Koti",
                            CategoryDK = "Hjemme",
                        };
                        return category;
                    case "Værktøj og Lommelygter":
                        category = new B2BCategory
                        {
                            Category = "Flashlights & Tools",
                            CategoryFI = "Taskulamput & Työkalut",
                            CategoryDK = "Lommelygter & Værktøj",
                        };
                        return category;
                    case "Skriveredskaber":
                        category = new B2BCategory
                        {
                            Category = "pens & pencils",
                            CategoryFI = "kynät & kirjoitusvälineet",
                            CategoryDK = "kuglepenne & blyanter",
                        };
                        return category;
                    case "Portofølger":
                        category = new B2BCategory
                        {
                            Category = "Document & Portfolio",
                            CategoryFI = "Dokumenttikansiot & Portfoliot",
                            CategoryDK = "Dokument & Portfolio",
                        };
                        return category;
                    case "Kasketter & Huer":
                        category = new B2BCategory
                        {
                            Category = "Hats",
                            CategoryFI = "Päähineet",
                            CategoryDK = "Huer",
                        };
                        return category;
                    case "Spil":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Biltilbehør":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Paraplyer":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Sport & Sundhed":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Førstehjælp":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "USB":
                        category = new B2BCategory
                        {
                            Category = "USB & Accessories",
                            CategoryFI = "USB & Tarvikkeet",
                            CategoryDK = "USB & Tilbehør",
                        };
                        return category;
                    case "Opladere":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Mobiltilbehør":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Solbriller":
                        category = new B2BCategory
                        {
                            Category = "Belts & Accessories",
                            CategoryFI = "Vyöt & Asusteet",
                            CategoryDK = "Bælter & Accessories",
                        };
                        return category;
                    case "Madkasse":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Audio & lyd":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Trådløse opladere":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Powerbanks":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Stormsikker paraply":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    default:
                        return null;
                }
            }
            return null;

        }
    }
}
