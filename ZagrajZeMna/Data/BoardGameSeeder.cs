using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public BoardGameSeeder(BoardGameContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("szymciu@gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Szymon",
                    LastName = "Wojciechowski",
                    Email = "szymciu@gmail.com",
                    UserName = "szymciu@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

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
                                Localization = "Poznan",
                                Owner = user
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
