using System.Collections.Generic;

namespace KN.B2B.Web.Models
{
    public class MNCategoies
    {
        public List<string> mnCategoryDK { get; set; }
        public List<MNCategoryFI> mnCategoryFI { get; set; }
        public List<MNCategoryEN> mnCategoryEN { get; set; }

    }

    public class MNCategoryDK
    {
        public string category_level1 { get; set; }
        public string category_level2 { get; set; }
        public string category_level3 { get; set; }
    }
    public class MNCategoryFI
    {
        public string category_level1 { get; set; }
        public string category_level2 { get; set; }
        public string category_level3 { get; set; }
    }
    public class MNCategoryEN
    {
        public string category_level1 { get; set; }
        public string category_level2 { get; set; }
        public string category_level3 { get; set; }
    }
}
