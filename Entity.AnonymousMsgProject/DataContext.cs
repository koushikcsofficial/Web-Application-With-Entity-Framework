using System.Data.Entity;

namespace Entity.AnonymousMsgProject
{
    public sealed class DataContext : DbContext
    {
        public DataContext() : base("connection") { }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
    }
}
