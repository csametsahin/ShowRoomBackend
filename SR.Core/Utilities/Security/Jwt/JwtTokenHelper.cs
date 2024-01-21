using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.Utilities.Security.Jwt
{
    public class JwtTokenHelper : IJwtTokenHelper
    {
        readonly IConfiguration configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<TokenResponse> CreateToken(User request)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: configuration["AppSettings:ValidIssuer"],
                    audience: configuration["AppSettings:ValidAudience"],
                    claims: new List<Claim> {
                    new Claim("userName", request.Name)
                    },
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return Task.FromResult(new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                Expiration = dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}
