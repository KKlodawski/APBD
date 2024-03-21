using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zadanie9.DTO;
using Zadanie9.Migrations;
using Zadanie9.models;

namespace Zadanie9.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
   private readonly S24777Context _context;



   public AccountsController(S24777Context context)
   {
      _context = context;
   }

   [HttpPost("login")]
   [AllowAnonymous]
   public IActionResult Login(string login, string password)
   {
      var hasher = new PasswordHasher<Users>();
      var usr = _context.Users.FirstOrDefault(e => e.Login == login);
      string refreshToken;

      if (hasher.VerifyHashedPassword(usr,usr.Password,password) == PasswordVerificationResult.Success)
      {
         if (usr.RefreshToken == null ||  DateTime.Compare((DateTime)(usr.RefreshTokenExpireTime == null ? DateTime.Now.AddHours(-1):usr.RefreshTokenExpireTime),DateTime.Now) < 0 )
         {
            refreshToken = GenerateRefreshToken();
            usr.RefreshToken = refreshToken;
            usr.RefreshTokenExpireTime = DateTime.Now.AddHours(1);
            _context.SaveChanges();
         }
         else
         {
            refreshToken = usr.RefreshToken;
         }
         return Ok(new
         {
            token = new JwtSecurityTokenHandler().WriteToken(GenerateToken(usr)),
            rToken = refreshToken
         });
      }
      else
      {
         return BadRequest("Invalid password!");
      }
      
      
   }

   [HttpPost("register")]
   [AllowAnonymous]
   public IActionResult Register(string login, string password)
   {
      var hasher = new PasswordHasher<Users>();
      Users usr = new Users();
      usr= new Users{Login = login, Password = hasher.HashPassword(usr,password)};
      _context.Users.Add(usr);
      _context.SaveChanges();
      return Ok($"User {login} has been created!");
   }

   [HttpPost]
   [AllowAnonymous]
   public IActionResult AccesToken(string refreshToken)
   {
      var usr = _context.Users.FirstOrDefault(e => e.RefreshToken == refreshToken);

      if (usr == null)
      {
         return BadRequest("Unknown refreshToken");
      }
      else
      {
         if (DateTime.Compare((DateTime)(usr.RefreshTokenExpireTime == null ? DateTime.Now.AddHours(-1) : usr.RefreshTokenExpireTime), DateTime.Now) < 0) 
            return BadRequest("Token expired!");
         else
         {
            return Ok(new JwtSecurityTokenHandler().WriteToken(GenerateToken(usr)));
         }
      }
   }
   
   private JwtSecurityToken GenerateToken(Users user)
   {
      var claims = new List<Claim>
      {
         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
         new Claim(ClaimTypes.Name, user.Login),
         new Claim(ClaimTypes.Role, "doctor")
      };
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretSecretABCD") );
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
         "Zadanie9",
         "Users",
         claims,
         expires: DateTime.Now.AddMinutes(2),
         signingCredentials: credentials);

      return token;
   }

   private string GenerateRefreshToken()
   {
      var rand = new byte[32];
      using (var r = RandomNumberGenerator.Create())
      {
         r.GetBytes(rand);
         return Convert.ToBase64String(rand);
      }
   }
   

   [HttpGet("error")]
   public IActionResult ThrowError()
   {
      throw new Exception("This is a simulated error.");
   }
   
}