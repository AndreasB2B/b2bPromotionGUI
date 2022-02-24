using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    public class CancellationReason
    {
        public int Id { get; set; }
        [Required]
        public string Reason { get; set; }
    }
}
