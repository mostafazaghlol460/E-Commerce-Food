using E_CommerceFood.BLL.Managers.Dtos.User;
using E_CommerceFood.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Managers.UserDLL
{
    public class UserBLL
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configration;

        public UserBLL(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configration = configration;
        }
        public async Task<IdentityResult> Registeration(ResgisterUserDTO RegisterData)
        {
            var UserData = new User
            {
                UserName=RegisterData.Name,
                Email=RegisterData.Email,
                PhoneNumber=RegisterData.PhoneNumber,
                Address=RegisterData.Address
            };
            var result = await _userManager.CreateAsync(UserData, RegisterData.Password);

            if(result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, UserData.Id),
                    new Claim(ClaimTypes.Name, UserData.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                 };
                await _userManager.AddClaimsAsync(UserData, claims);
                return result;
            }
            return result;

        }
        public async Task<TokenDto> login(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.FindByNameAsync(loginUserDTO.UserName);
            if (user == null)
            {
                return null;
            }
            var isAuthenticated = await _userManager.CheckPasswordAsync(user, loginUserDTO.Password);
            if (!isAuthenticated)
            {
                return null;
            }
            //get claimfor user
            var claimsUser = await _userManager.GetClaimsAsync(user);

            // create object for jwt 
            //generate secretkey 
            var SecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configration.GetValue<string>("SecretKey")));
            //generate signing crdentials
            var Signing=new SigningCredentials(SecretKey,SecurityAlgorithms.HmacSha256);
            //create expiration 
            var expiryDate = DateTime.Now.AddHours(1);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                claims: claimsUser,
                expires: expiryDate,
                signingCredentials: Signing

                );
            //for converting to token handler to get data 
            var tokenHndler = new JwtSecurityTokenHandler();
            var tokenString = tokenHndler.WriteToken(jwtSecurityToken);



            return new TokenDto(tokenString, expiryDate);

        }
    }
}
