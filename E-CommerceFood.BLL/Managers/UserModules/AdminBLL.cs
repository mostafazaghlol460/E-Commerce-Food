using E_CommerceFood.BLL.Dtos.UserDtos;
using E_CommerceFood.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Managers.UserModules
{
    public class AdminBLL
    {
        private readonly UserManager<ApplicationUser> _userManager;
        

        public AdminBLL( UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }
        public async Task<IdentityResult> RegisterationAdmin(ResgisterUserDTO RegisterData)
        {
            var UserData = new User
            {
                UserName = RegisterData.Name,
                Email = RegisterData.Email,
                PhoneNumber = RegisterData.PhoneNumber,
                Address = RegisterData.Address
            };
            var result = await _userManager.CreateAsync(UserData, RegisterData.Password);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, UserData.Id),
                    new Claim(ClaimTypes.Name, UserData.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                 };
                await _userManager.AddClaimsAsync(UserData, claims);
                return result;
            }
            return result;

        }

        public async Task<IdentityResult> update_Admin(UpdateDTO updateData,string id)
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
        public async Task<ICollection<DataDisplayUser>?> GetAllAdmin()
        {

            var Data = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Admin"));
            if (Data != null)
            {
                var adminUserDtos = Data.Select(user => new DataDisplayUser
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,


                }).ToList();
                if (adminUserDtos != null)
                {
                    return adminUserDtos;
                }
            }

            return null;
        }
        public async Task<DataDisplayUser> GetAdmin(string id)
        {
            var user = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Admin"));
            if (user.Count > 0)
            {
                var Data = user.Where(n => n.Id == id).FirstOrDefault();
                if (Data != null)
                {
                    DataDisplayUser ReturnData = new DataDisplayUser
                    {
                        Id = Data.Id,
                        Name = Data.UserName,
                        PhoneNumber = Data.PhoneNumber,
                        Address = Data.Address,
                        Email = Data.Email
                    };
                    return ReturnData;
                }
            }
            return null;
        }
    }
}
