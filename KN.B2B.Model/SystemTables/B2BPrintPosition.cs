using KN.B2B.Model.products.B2BPrintPositions;

namespace KN.B2B.Model.SystemTables
{
    public class B2BPrintPosition
    {
        [key]
        public int Id { get; set; }
        public string Position { get; set; }
        public string print_supplier { get; set; }
        public string print_product { get; set; }
        public int print_express { get; set; }
        public string print_position { get; set; }
        public float print_size { get; set; }
        public float print_height { get; set; }
        // Foreign key for fk techniqueID = B2BPrintTechnique;
        public B2BPrintTechnique fk_techniqueId { get; set; }
    }
}
