using System;
namespace CrmApiLogic.Models
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryDays { get; set; }
    }
}
