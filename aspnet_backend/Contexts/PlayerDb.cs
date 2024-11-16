using aspnet_backend.Contexts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace aspnet_backend.Contexts
{
    public class PlayerDb : DbContext
    {
        public PlayerDb(DbContextOptions<PlayerDb> options) : base(options) { }

        public DbSet<Player> Players => Set<Player>();
    }
}
