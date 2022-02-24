using System;
using System.ComponentModel.DataAnnotations;

namespace KN.B2B.Model.SystemTables
{
    [Serializable]
    public class DUNSGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required, MinLength(3, ErrorMessage = "Industry cannot be less than 3 characters.")]
        public string Industry { get; set; }
    }
}
