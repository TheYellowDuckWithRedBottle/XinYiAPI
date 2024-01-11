using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace XinYiAPI.Common
{
    public class JwtService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        public JwtService(string secretKey, string issuer)
        {
            _secretKey = secretKey;
            _issuer = issuer;
        }
        public string GenerateToken(string userId)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,userId),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(30).ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer),
                new Claim(JwtRegisteredClaimNames.Aud, "gtmapuser"),
            };
            var jwt = new JwtSecurityToken(
                issuer: _issuer,
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
   
            return tokenHandler.WriteToken(jwt);
        }
    }
}
