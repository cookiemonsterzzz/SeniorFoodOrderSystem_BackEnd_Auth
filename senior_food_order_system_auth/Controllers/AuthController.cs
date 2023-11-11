
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senior_food_order_system_auth.Dto;

namespace senior_food_order_system_auth.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly SeniorFoodOrderSystemDatabaseContext _dbContext;

        public AuthController(
            IConfiguration configuration,
            SeniorFoodOrderSystemDatabaseContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("loginwithphone")]
        public async Task<ActionResult> LoginWithPhoneNo([FromBody] string phoneNo)
        {
            try
            {
                var existUser = _dbContext.Users.FirstOrDefault(x => x.PhoneNo == phoneNo);

                if (existUser is null)
                {
                    user.Id = Guid.NewGuid();
                    user.UserName = "";
                    user.PhoneNo = phoneNo;
                    user.RoleType = "Customer";
                    user.DateTimeCreated = DateTimeOffset.Now;

                    existUser = user;

                    await _dbContext.AddAsync(user);
                    await _dbContext.SaveChangesAsync();
                }

                string token = CreateToken(existUser);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                using var transaction = _dbContext.Database.BeginTransaction();

                string passswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

                user.PhoneNo = registerDto.PhoneNo;
                user.Passcode = passswordHash;
                user.RoleType = registerDto.Role;

                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {
            try
            {
                string token = CreateToken(user);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim("PhoneNo", user.PhoneNo),
                new Claim("Role", user.RoleType)
            };

            var tokenValue = _configuration["AppSettings:Token"] ?? "senior food order system nus iss assignment team 38 secret key 20230827";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        tokenValue
                        ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

