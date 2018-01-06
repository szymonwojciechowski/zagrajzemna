﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagrajZeMna.ViewModels
{
    public class TableViewModel
    {
        public int TableId { get; set; }
        public string Localization { get; set; }
        public DateTime Date { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
    }
}
