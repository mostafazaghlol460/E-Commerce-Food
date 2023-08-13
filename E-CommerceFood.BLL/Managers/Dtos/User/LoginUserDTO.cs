using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Managers.Dtos.User
{
    public record LoginUserDTO(string UserName ,string Password);

}
