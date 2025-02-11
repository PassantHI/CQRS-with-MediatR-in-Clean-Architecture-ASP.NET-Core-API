using App.Application.DTOs;
using App.Infrastructure.Identity;
using App.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailService emailService;
        public AccountController(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {

            this.userManager = userManager;
            this.emailService = emailService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerdto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = registerdto.Email;
                userModel.UserName = registerdto.UserName;
                userModel.EmailConfirmed = false;
                userModel.Password = registerdto.Password;
                userModel.Active = true;

                var result = await userManager.CreateAsync(userModel, registerdto.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "User");

                    var token = await userManager.CreateSecurityTokenAsync(userModel);
                    return Ok(new
                    {
                        token = token,
                    });
                }
                else return Ok(result);
            }
            return BadRequest(ModelState);
        }





        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO logindto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = await userManager.FindByEmailAsync(logindto.Email);

                if (userModel != null && await userManager.CheckPasswordAsync(userModel, logindto.Password)) 
                {

                    List<Claim> MyClaim = new List<Claim>();
                    MyClaim.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
                    MyClaim.Add(new Claim(ClaimTypes.Name, userModel.UserName));
                    MyClaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles = await userManager.GetRolesAsync(userModel);

                    if (roles != null)
                    {
                        foreach (var role in roles)
                        {
                            MyClaim.Add(new Claim(ClaimTypes.Role, role));

                        }
                    }

                    var MyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("*****************************"));

                    SigningCredentials credential = new SigningCredentials(MyKey, SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken MyToken = new JwtSecurityToken(
                        issuer: "http://localhost:58353",
                        audience: "http://localhost:4200",
                        expires: DateTime.Now.AddDays(1),
                        claims: MyClaim,
                        signingCredentials: credential

                        );

                    return Ok(

                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(MyToken),

                            Exception = MyToken.ValidTo.ToLocalTime()

                        });
                }
                else
                    return BadRequest("invalid data");
            }

            return Ok(ModelState);
        }

        [HttpPost("SendConfirmationEmail")]
        public async Task<IActionResult> SendConfirmationEmail(ApplicationUser userModel)
        {

            var token = await userManager.GenerateEmailConfirmationTokenAsync(userModel);

            var conLink = Url.Action(nameof(ConfirmEmail), "Account",
                new { userId = userModel.Id, token = token },
                Request.Scheme
                );

            await emailService.SendEmailAsync(userModel.Email, "Please Confirm Your Email", conLink);

            return Ok("Confirmation Email send");
        }



        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest("Invalid user ID");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully!");
            }

            return BadRequest("Email confirmation failed");
        }

    }
}
