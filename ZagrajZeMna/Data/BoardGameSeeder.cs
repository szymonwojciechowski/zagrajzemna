using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.Data
{
    public class BoardGameSeeder
    {
        private readonly BoardGameContext _context;

        public BoardGameSeeder(BoardGameContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Games.Any())
            {
                var games = new List<Game>
                {
                    new Game
                    {
                        Title = "Catan",
                        Description = "description",
                        Tables = new List<Table>
                        {
                            new Table
                            {
                                Date = DateTime.Now.AddDays(2),
                                Localization = "Poznan"
                            }
                        }
                    },
                    new Game
                    {
                        Title = "7 wonders",
                        Description = "Description"
                    }
                };
                _context.Games.AddRange(games);
                _context.SaveChanges();
            }
        }
    }
}
