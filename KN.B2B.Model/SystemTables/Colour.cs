using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    public class Colour
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
