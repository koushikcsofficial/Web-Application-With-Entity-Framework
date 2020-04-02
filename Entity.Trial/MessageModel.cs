using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Anonymous
{
    [Table("Messages")]
    public sealed class MessageModel
    {
        [Key]
        public int Message_Id { get; set; }
        public string To_User { get; set; }
        public string From_User { get; set; }
        [Required]
        public string Message_Body { get; set; }
        public DateTime Message_Time { get; set; }
    }
}
