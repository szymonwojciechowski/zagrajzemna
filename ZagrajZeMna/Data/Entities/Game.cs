using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrajZeMna.Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
