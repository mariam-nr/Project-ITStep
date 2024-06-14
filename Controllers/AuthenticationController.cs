using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeect_ITStep.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Projeect_ITStep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        public static Admin admin = new Admin();
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("register")]
        public IActionResult Register(AdminDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            admin.Username = request.Username;
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            return Ok(admin);
        }

        [HttpPost("login")]
        public IActionResult Login(AdminDto request)
        {
            if (admin.Username != request.Username)
                return BadRequest("User not found");
            if (!VerifyPasswordHash(request.Password, admin.PasswordHash, admin.PasswordSalt))
                return BadRequest("Wrong password");

            string token = CreateToken(admin);

            return Ok(token);
        }

        private string CreateToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,admin.Username),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPost("refreshToken")]
        public IActionResult RefreshToken()
        {
            var refershToken = Request.Cookies["refreshToken"];

            string token = CreateToken(admin);

            var generatedRefreshToken = GenerateRefreshToken();
            SetUserRefreshToken(generatedRefreshToken);

            return Ok(token);
        }
        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expire = DateTime.Now.AddSeconds(10)
            };

            return refreshToken;
        }

        private void SetUserRefreshToken(RefreshToken refreshToken)
        {
            var cookies = new CookieOptions
            {
                Expires = refreshToken.Expire,
                HttpOnly = true
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookies);

            admin.RefreshToken = refreshToken.Token;
            admin.TokenExpires = refreshToken.Expire;
            admin.TokenCreated = refreshToken.Created;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }
    }
}
