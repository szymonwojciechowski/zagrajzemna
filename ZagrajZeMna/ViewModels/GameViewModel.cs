using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZagrajZeMna.Data.Entities;

namespace ZagrajZeMna.ViewModels
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<TableViewModel> Tables { get; set; }
    }
}
