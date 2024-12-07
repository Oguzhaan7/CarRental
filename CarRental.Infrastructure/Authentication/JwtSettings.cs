using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public static string SectionName { get; } = "JwtSettings";
        public string Secret { get; set; } = null!;
        public int ExpireDay { get; set; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
