using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Anonymous
{
    [Table("Users")]
    public sealed class UserModel
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        [Required]
        public string User_Email { get; set; }
        [Required]
        public string User_Password { get; set; }
        public int User_Role { get; set; }
    }
}
