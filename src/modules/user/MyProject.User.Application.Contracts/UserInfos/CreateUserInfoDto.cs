using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.User.Application.Contracts.Users
{
    public class CreateUserInfoDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Password { get; set; }
        public int Type { get; set; }
        public string? PhoneNumber { get; set; }    // 表示字段可空
    }
}
