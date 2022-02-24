using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    public class Municipality
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
