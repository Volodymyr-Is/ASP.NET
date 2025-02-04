using Dz_04._02.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dz_04._02.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private List<Person> people = new List<Person>
        {
        new Person { Login = "admin@gmail.com", Password = "123", Role = "admin" },
        new Person { Login = "user@gmail.com", Password = "456", Role = "user" }
    };

        [HttpPost("token")]
        public IActionResult Token([FromBody] Person person)
        {
            var identity = GetIdentity(person.Login, person.Password);
            if (identity == null)
            {
                return BadRequest("Invalid username or password");
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddMinutes(AuthOptions.LIFETIME),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(new { access_token = encodedJwt, name = identity.Name });
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
            };
                return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            }
            return null;
        }
    }

}
