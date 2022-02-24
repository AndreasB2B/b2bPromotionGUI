using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    public class CurrentStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
