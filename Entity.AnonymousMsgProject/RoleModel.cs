using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.AnonymousMsgProject
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
