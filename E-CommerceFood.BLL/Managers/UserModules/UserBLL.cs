using E_CommerceFood.BLL.Dtos.UserDtos;
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
        private readonly RoleManager<IdentityRole> _roleManager;


        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configration;

        public UserBLL(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configration, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configration = configration;
            _roleManager = roleManager;
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
        public async Task<DataDisplayUser> GetUser(string id)
        {
            var user = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "User"));
            if (user.Count> 0)
            {
                var Data = user.Where(n => n.Id == id).FirstOrDefault();
                if (Data != null)
                {
                    DataDisplayUser ReturnData = new DataDisplayUser
                    {
                        Id = Data.Id,
                        Name =Data.UserName,
                        PhoneNumber=Data.PhoneNumber,
                        Address=Data.Address,
                        Email=Data.Email
                    };
                    return ReturnData;
                }
            }
            return null;
        }
        
        public async Task<IdentityResult> update_User(UpdateDTO updateData,string id)
        {
            var data = await _userManager.FindByIdAsync(id);

            if (data != null)
            {
                // Refresh the data
                var updatedData = await _userManager.FindByIdAsync(id);

                updatedData.UserName = updateData.Name;
                updatedData.Email = updateData.Email;
                updatedData.PhoneNumber = updateData.PhoneNumber;
                updatedData.Address = updateData.Address;

                var result = await _userManager.UpdateAsync(updatedData);

                if (result.Succeeded)
                {
                    return result;
                }
                else
                {
                    // Handle errors
                    return null;
                }
            }
            else
            {
                // Handle user not found
                return null;
            }
        }
        public async Task<ICollection<DataDisplayUser>?> GetAllUser()
        {
            
            var Data = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "User"));
            var adminUserDtos = Data.Select(user => new DataDisplayUser
            {
                Id=user.Id,
                Name = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address=user.Address,

                
            }).ToList();
            if (adminUserDtos != null)
            {
                return adminUserDtos;
            }

            return null;
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
            var Signing = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
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
