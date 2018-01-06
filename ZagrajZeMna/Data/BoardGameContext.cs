using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.Data
{
    public class BoardGameContext : DbContext
    {
        public BoardGameContext(DbContextOptions<BoardGameContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
