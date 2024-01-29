using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace XinYiAPI.Common
{
    public class JwtService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audient;
        public JwtService(string secretKey, string issuer,string audient)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audient = audient;
        }
        public string GenerateToken(string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, _issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _audient),
                new Claim(ClaimTypes.Role, role)
            };
            var jwt = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audient,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwt);
        }
        public static JwtUserInfo SerializeJwtStr(string jwtStr)
        {
            JwtUserInfo jwtUserInfo = new JwtUserInfo();
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            jwtUserInfo.UserId = jwtToken.Id;
            jwtUserInfo.UserName = jwtToken.Subject;
           
            return jwtUserInfo;
        }
        public class JwtUserInfo
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Role { get; set; }
        }
    }
}
