using KN.B2B.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KN.B2B.Model
{
    public class ZipCode
    {
        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Country? Country { get; set; }
        public int Amts { get; set; }
        public string Region { get; set; }
        public int MunicipalityNumber { get; set; }
        public string Municipality { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            if (Country.HasValue)
                return $"[{Country.Value}] - [{Zip}] - {Municipality} - {City}";
            else
                return $"[{Zip}] - {Municipality} - {City}";
        }
    }
}
