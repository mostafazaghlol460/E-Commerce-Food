﻿using E_CommerceFood.BLL.Managers.Dtos.User;
using E_CommerceFood.BLL.Managers.UserDLL;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBLL _userBLL;

        public UserController(UserBLL registerUser)
        {
            _userBLL = registerUser;
        }

        [HttpPost]
        [Route("User/Register")]
        public async Task<ActionResult> RegisterUser(ResgisterUserDTO UserData)
        {
            var result = await _userBLL.Registeration(UserData);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> LoginUser(LoginUserDTO UserData)
        {
            var result = await _userBLL.login(UserData);
            if (result!=null)
            {
                return result;
            }

            return Unauthorized();
        }
    }
}