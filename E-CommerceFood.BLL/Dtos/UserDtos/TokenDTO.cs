using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Dtos.UserDtos
{

    public record TokenDto(string Token, DateTime Expiry);
}
