using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ZagrajZeMna.Data;
using ZagrajZeMna.Data.Entities;
using ZagrajZeMna.ViewModels;

namespace ZagrajZeMna.Controllers
{
    [Route("api/[Controller]")]
    public class GamesController : Controller
    {
        private readonly IBoardGameRepository _repository;
        private readonly ILogger<GamesController> _logger;
        private readonly IMapper _mapper;

        public GamesController(IBoardGameRepository repository, ILogger<GamesController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeTables = false)
        {
            try
            {
                var results = _repository.GetAllGames(includeTables);
                return Ok(_mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(results));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get games: {e}");
                return BadRequest("Failed to get all games");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var game = _repository.GetGameById(id);
                if (game != null)
                    return Ok(_mapper.Map<Game, GameViewModel>(game));
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get games: {e}");
                return BadRequest("Failed to get all games");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] GameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newGame = _mapper.Map<GameViewModel, Game>(model);
                    _repository.AddEntity(newGame);

                    if (_repository.SaveChanges())
                    {
                        return Created($"/api/games/{newGame.Id}", _mapper.Map<Game, GameViewModel>(newGame));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to save new game: {e}");
            }

            return BadRequest("Failed to save new game");
        }

    }
}
