using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    public class CustomerChannel
    {
        public int Id { get; set; }
        [Required]
        public string Channel { get; set; }
    }
}
