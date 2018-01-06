using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.Data
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly BoardGameContext _ctx;
        private readonly ILogger<BoardGameRepository> _logger;

        public BoardGameRepository(BoardGameContext ctx, ILogger<BoardGameRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Game> GetAllGames(bool includeTables)
        {
            try
            {
                if (includeTables)
                {
                    return _ctx.Games.Include(g => g.Tables)
                        .OrderBy(g => g.Title)
                        .ToList();
                }
                else
                {
                    return _ctx.Games
                        .OrderBy(g => g.Title)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all games: {e}");
                return null;
            }
        }

        public Game GetGameById(int id)
        {
            try
            {
                return _ctx.Games.Include(g => g.Tables)
                    .FirstOrDefault(g => g.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get game: {e}");
                return null;
            }
        }

        public IEnumerable<Table> GetAllTables()
        {
            try
            {
                return _ctx.Tables.Include(t => t.Game).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all tables: {e}");
                return null;
            }
        }

        public Table GetTableById(int id)
        {
            try
            {
                return _ctx.Tables
                    .Include(t => t.Game)
                    .FirstOrDefault(t => t.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get table: {e}");
                return null;
            }
        }

        public void AddEntity(object model)
        {

            try
            {
                _ctx.Add(model);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to add entity");
                _logger.LogError("Failed to add entity");
            }
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
