using E_CommerceFood.BLL.Dtos.UserDtos;
using E_CommerceFood.BLL.Managers.UserDLL;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBLL _userBLL;

        public UserController(UserBLL registerUser)
        {
            _userBLL = registerUser;
        }
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult> GetAllUsers()
        {
            var Data = await _userBLL.GetAllUser();
            if (Data!=null)
            {
                return Ok(Data);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Register")]
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
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<UpdateDTO>> UpdateUser(string id, UpdateDTO UserData)
        {
            var result = await _userBLL.update_User(UserData,id);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            var result = await _userBLL.GetUser(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return NotFound();
        }


    }
}
