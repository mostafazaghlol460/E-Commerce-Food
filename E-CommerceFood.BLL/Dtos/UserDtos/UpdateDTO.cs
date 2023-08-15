using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Dtos.UserDtos
{
    public class UpdateDTO
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //you should regular expression for that phone 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
