namespace KN.B2B.Model.SystemTables
{
    public class B2BCategory
    {
        public int Id { get; set; }
        public B2BCategoryGroup CategoryGroup { get; set; }
        public string Category { get; set; }
        public string CategoryDK { get; set; }
    }
}
