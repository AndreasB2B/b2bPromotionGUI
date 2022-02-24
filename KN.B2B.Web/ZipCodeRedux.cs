using KN.B2B.Model.Enums;

namespace KN.B2B.Web
{
    public class ZipCodeRedux
    {
        public Country? Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public ZipCodeRedux(Country country, string zip, string city)
        {
            Country = country;
            Zip = zip;
            City = city;
        }

        public override string ToString()
        {
            if (Country.HasValue)
                return $"[{Country.Value}] - [{Zip}] - {City}";
            else
                return $"[{Zip}] - {City}";
        }
    }
}
