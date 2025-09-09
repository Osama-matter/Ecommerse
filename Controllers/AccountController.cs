using Ecommerse.DTOs;
using Ecommerse.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        UserManager<ApplecationUser> _userManager;    // Add  user  manger  service to use  it to Make opperation

        IConfiguration _configuration;
        public AccountController(UserManager<ApplecationUser> userManager, IConfiguration configuration)
        { 

            _userManager = userManager;    // declerate  usemanger  service  ; 
            _configuration = configuration;
        }

        [HttpPost("Register")]    

        public async Task<IActionResult> Register(RegiesterDTO regiestermodel )    /// Make  Post Action to Make  Register Servies 
        {
            if(ModelState.IsValid)  // Check Validation of Reguster  data   . 
            {
                ApplecationUser user = new ApplecationUser();   // declerate  object from FormApplection to updata  data from form to save reuister 
                user.UserName = regiestermodel.UserName;    // set  data in Applection Model 
                user.PhoneNumber = regiestermodel.Phone;   // set  Phone  
                user.Email = regiestermodel.Email;  // set  Eamil ; 

                IdentityResult result = await _userManager.CreateAsync(user, regiestermodel.Password);

                if (result.Succeeded)   // Check Succeded of  Save  Reguister  data  
                {
                    return Ok("Create Succes");    // return Stuts  code  200 to show data save succed
                }

                else
                {
                    foreach (var item in result.Errors)     //   Show eroor  if  found 
                    {
                        ModelState.AddModelError("Password", item.Description);
                    }
                }

            }


            return BadRequest(ModelState); 
    
        }

        [HttpPost("Login")]

        public  async Task<IActionResult> Login(LoginDTO loginModel)   //Make  Login Action take  LoginDTO
        {
            if(ModelState.IsValid)   // Check Validation OfData 
            {
                ApplecationUser User = 
                   await _userManager.FindByNameAsync(loginModel.UserName);    // Generate Applection user  to Get user  have  same  UserName   to Use  it  to check Password 

                if (User != null)   // Check Object  Not  == Null Mene  User Found 
                {
                    bool Found = await _userManager.CheckPasswordAsync(User, loginModel.Password);    // Make  Bool Var  to Check If  password  Valid  or not  valid 
                    if (Found == true)   // if  Usee Name fpund  and  Password  Is Valid  Generate Token
                    {
                        /////    Generate Token  //////
                        

                        ///// Make Clims  ///
                        List<Claim> User_claims = new List<Claim>();
                        User_claims.Add(new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));// key 
                        User_claims.Add(new Claim(ClaimTypes.NameIdentifier, User.Id)) ; // put  ID  
                        User_claims.Add(new Claim(ClaimTypes.Name, User.UserName));
                        var UserRole = await _userManager.GetRolesAsync(User);  // Make  var to select  all role  
                        foreach(var  Role in UserRole)  // uploud role  in Claims
                        {
                            User_claims.Add(new Claim (ClaimTypes.Role, Role));    // add  role  in Claims 
                        }
                        var SignInKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"]));  // Make  sinin key  make  Cradintal Valid  

                        SigningCredentials credentials = new SigningCredentials(SignInKey, SecurityAlgorithms.HmacSha256);   // Make  Cradentials By key  and  Algorizem Hashing  


                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: _configuration["IWT:Issuer"],
                            audience: _configuration["JWT:Audience"],
                            signingCredentials: credentials,
                            claims:User_claims,
                            expires: DateTime.UtcNow.AddHours(1)
                            );



                        /// Generate  Toke  Response  ////

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),

                            expiration = DateTime.UtcNow.AddHours(1)  //OR//token Validto   

                        });  // return token from user 


                    }
                }
                ModelState.AddModelError("UserName", "UserName OR Password  UNVaild");    // retrun this  if  at  leat one  == null 


            }
            return BadRequest(ModelState);   // if  Modestate not  valid  

        }
    }
}
