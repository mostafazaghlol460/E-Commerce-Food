using E_CommerceFood.BLL.Dtos.UserDtos;
using E_CommerceFood.BLL.Managers.UserDLL;
using E_CommerceFood.BLL.Managers.UserModules;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminBLL _adminBLL;

        public AdminController(AdminBLL adminBLL)
        {
            _adminBLL = adminBLL;
        }

        [HttpGet]
        [Route("GetAllAdmin")]
        public async Task<ActionResult> GetAllAmin()
        {
            var Data = await _adminBLL.GetAllAdmin();
            if (Data != null)
            {
                return Ok(Data);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterUser(ResgisterUserDTO UserData)
        {
            var result = await _adminBLL.RegisterationAdmin(UserData);
            if (result.Succeeded)
            {
                return Ok();
            }


            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAdmin(UpdateDTO UserData, string id)
        {
            var result = await _adminBLL.update_Admin(UserData,id);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAdmin(string id)
        {
            var result = await _adminBLL.GetAdmin(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
