using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dz_04._02.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "PV211";
        public const string AUDIENCE = "PV211";
        const string KEY = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
        public const int LIFETIME = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }

    }
}
