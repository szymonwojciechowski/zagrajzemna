using System.Collections.Generic;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.Data
{
    public interface IBoardGameRepository
    {
        IEnumerable<Game> GetAllGames(bool includeTables);
        Game GetGameById(int id);

        IEnumerable<Table> GetAllTables();
        Table GetTableById(int id);

        void AddEntity(object model);

        bool SaveChanges();
    }
}