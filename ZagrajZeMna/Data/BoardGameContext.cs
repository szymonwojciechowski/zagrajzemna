using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.Data
{
    public class BoardGameContext : IdentityDbContext<User>
    {
        public BoardGameContext(DbContextOptions<BoardGameContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}