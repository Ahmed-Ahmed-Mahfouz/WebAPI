using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult login(string username, string password)
        {
            if(username == "admin" && password == "admin")
            {
                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim("username", "admin"));
                userdata.Add(new Claim("role", "admin"));

                string key = "welcome to my secret key Ahmed Ahmed Mahfouz";
                var secretkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

                var signincer = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: userdata,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signincer
                    );

                var finalToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(finalToken);
            }
            else
            {
                return Unauthorized("Login Failed");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult add()
        {
            return Ok();
        }
    }
}
