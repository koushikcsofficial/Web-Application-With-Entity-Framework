using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.AnonymousMsgProject
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
