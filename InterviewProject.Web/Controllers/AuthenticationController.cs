using interviewproject.api.domain.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InterviewProject.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JWTConfig _jwtConfig;

        public AuthenticationController(IOptions<JWTConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        [HttpPost("/auth/token")]
        public ActionResult Login()
        {
            var token = JwtGenerator();
            return Ok(new { access_token = token });
        }

        private string JwtGenerator()
        {
            var claims = new List<Claim>();

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var encodedToken = TokenCoded(identityClaims);
            return encodedToken;
        }

        private string TokenCoded(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
    }
}