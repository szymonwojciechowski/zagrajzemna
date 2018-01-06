using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrajZeMna.Data.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string Localization { get; set; }
        public DateTime Date { get; set; }
        public Game Game { get; set; }
    }
}
