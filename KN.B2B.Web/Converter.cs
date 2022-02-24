using KN.B2B.Data;
using KN.B2B.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web
{
    public static class Converter
    {
        public static IEnumerable<ZipCodeRedux> CrunchZipCodes(IEnumerable<ZipCode> zipCodes)
        {
            var reduxDict = new Dictionary<string, ZipCodeRedux>();
            foreach (var zip in zipCodes)
            {
                if (reduxDict.ContainsKey(zip.Zip) == false)
                    reduxDict.Add(zip.Zip, new ZipCodeRedux(zip.Country.GetValueOrDefault(), zip.Zip, zip.City));
            }
            return reduxDict.Values.ToList();
        }

        public static async Task<ZipCode> ReduxZipToFullZip(B2BDbContext context, string reduxZip) 
            => await context.ZipCodes.FirstOrDefaultAsync(x => x.Zip == reduxZip);

        public static string ZipToZipRedux(this ZipCode original) 
            => new ZipCodeRedux(original.Country.GetValueOrDefault(), original.Zip, original.City).ToString();
    }
}
