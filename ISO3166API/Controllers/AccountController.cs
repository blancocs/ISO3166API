using ISO3166API.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ISO3166API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<authenticationDTO>> Register(userCredentials credentials)
        {
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await userManager.CreateAsync(user, credentials.Password);

            if (result.Succeeded)
            {
                return BuildToken(credentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }


        //create token por user credentials.
        private authenticationDTO BuildToken(userCredentials credentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credentials.Email)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyJWT"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

            return new authenticationDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration

            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<authenticationDTO>> Login(userCredentials credentials)
        {
            var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent:false, lockoutOnFailure:false);

            if (result.Succeeded)
                return BuildToken(credentials);
            else
                return BadRequest("Login Failure");


        }
    }
}
