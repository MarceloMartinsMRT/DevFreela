using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTOs
{
    public class UserDTO
    {
        public UserDTO(string name, string email)
        {
            this.name = name;
            this.email = email;
        }

        public string name {  get; set; }
        public string email { get; set; }
    }
}
