using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace YouLearn.Api.Security
{
    public class SigningConfigurations
    {
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";
        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256); ;
        }
    }
}
