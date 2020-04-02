using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Anonymous
{
    [Table("Roles")]
    public sealed class RoleModel
    {
        [Key]
        public int Role_Id { get; set; }
        [Required]
        public string Role_Name { get; set; }
    }
}
