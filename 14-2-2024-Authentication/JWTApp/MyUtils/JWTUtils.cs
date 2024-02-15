using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWTApp {
    public class JWTUtils {
        public static string secretKey = null;

        public static string GetToken(Dictionary<string, string> payload) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(secretKey);
            var claims = new List<Claim> ();
            foreach (var item in payload) claims.Add(new Claim(item.Key, item.Value));
            var identity = new ClaimsIdentity(claims);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool VerifyToken(string token, out Dictionary<string, string> payload) {
            payload = null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(secretKey);
            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                payload = new Dictionary<string, string>();
                foreach (Claim claim in jwtToken.Claims) {
                    payload.Add(claim.Type, claim.Value);
                }
                return true;
            } catch {
                return false;
            }
        }
    }
}