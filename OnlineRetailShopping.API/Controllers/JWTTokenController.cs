using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineRetailShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {
        public IConfiguration _config;
        public readonly CombineContext _context;

        public JWTTokenController(IConfiguration configuration, CombineContext context)
        {
            _config = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user != null && user.UserName != null && user.Password != null)
            {
                var userData = GetUser(user.UserName, user.Password);
                if (userData == null) { return BadRequest("Invalid credentials"); }

                if (user.UserName == userData.UserName && user.Password == userData.Password)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim("Id",user.UserId.ToString()),
        new Claim("PassWord",user.Password),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                        _config["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
            }
            return BadRequest("Invalid Credentials");


        }
        [HttpGet]

        public User GetUser(String UserName, String Password)
        {
            User user = null;
            user = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if (user.Password != Password) return null;
            return user;
        }
    }
}
