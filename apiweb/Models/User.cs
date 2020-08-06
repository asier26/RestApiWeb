using System;
using System.ComponentModel.DataAnnotations;

namespace ApiWeb.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
        public bool UserValid { get; set; }
        public bool? State { get; set; }
    }
}
