using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Trial
{
    public sealed class DataContext:DbContext
    {
        public DataContext() : base("connection") { }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
    }
}
