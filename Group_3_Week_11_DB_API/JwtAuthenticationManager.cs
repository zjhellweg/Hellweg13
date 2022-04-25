using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Group_3_Week_11_DB_API
{
    public class JwtAuthenticationManager
    {
        private readonly string Key;

        private readonly IDictionary<String,String> Users = new Dictionary<string, String>()
        {
            {"test", "Password" },{"Drickikcha", "Jimmy2.0"} 
        };

        public JwtAuthenticationManager(String Key)
        {
            this.Key = Key;
        }

        public String Authenticate(String Username, String Password)
        {
            if(!Users.Any(u => u.Key == Username && u.Value == Password))
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(Key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Username)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}
