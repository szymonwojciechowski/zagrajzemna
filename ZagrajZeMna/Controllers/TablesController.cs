using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ZagrajZeMna.Data;
using ZagrajZeMna.Data.Entities;
using ZagrajZeMna.ViewModels;

namespace ZagrajZeMna.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class TablesController : Controller
    {
        private readonly IBoardGameRepository _repository;
        private readonly ILogger<TablesController> _logger;
        private readonly IMapper _mapper;

        public TablesController(IBoardGameRepository repository, ILogger<TablesController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Table>, IEnumerable<TableViewModel>>(_repository.GetAllTables()));
            }
            catch (Exception e)
            {
                _logger.LogError($"Faild to get all tables: {e}");
                return BadRequest("Failed to get all tables");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var table = _repository.GetTableById(id);
                if (table != null)
                    return Ok(_mapper.Map<Table, TableViewModel>(table));
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get table: {e}");
                return BadRequest("Failed to get table");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TableViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTable = _mapper.Map<TableViewModel, Table>(model);

                    if (newTable.Date == DateTime.MinValue)
                        newTable.Date = DateTime.Now.AddDays(7);

                    _repository.AddEntity(newTable);
                    if (_repository.SaveChanges())
                    {
                        return Created($"/api/games/{newTable.Id}", _mapper.Map<Table, TableViewModel>(newTable));
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
