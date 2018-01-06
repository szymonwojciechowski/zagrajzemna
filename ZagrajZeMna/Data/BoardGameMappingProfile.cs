using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZagrajZeMna.Data.Entities;
using ZagrajZeMna.ViewModels;

namespace ZagrajZeMna.Data
{
    public class BoardGameMappingProfile : Profile
    {
        public BoardGameMappingProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(g => g.GameId, ex => ex.MapFrom(g => g.Id))
                .ReverseMap();

            CreateMap<Table, TableViewModel>()
                .ForMember(t => t.TableId, ex => ex.MapFrom(t => t.Id))
                .ReverseMap();
        }       
    }
}
