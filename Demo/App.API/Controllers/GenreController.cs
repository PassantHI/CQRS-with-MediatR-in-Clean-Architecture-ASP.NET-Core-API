using App.Application.DTOs;
using App.Application.Features.Genres.Commands;
using App.Application.Features.Genres.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllGenresQuery());
            return result.IsNullOrEmpty() ? NoContent() : Ok(result);
        }

        [HttpGet("Genre/{Id:int}")]
        public async Task<ActionResult<GenreDTO>> GetById(int Id)
        {
            var result = await _mediator.Send(new GetGenreQuery(Id));
            return result is not null ? Ok(result) : NotFound();

        }

        [HttpPost]
        public async Task<ActionResult<GenreDTO>> AddGenre(GenreDTO genreDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(new AddGenreCommand(genreDTO));
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<GenreDTO>> EditGenre(GenreDTO genreDTO) 
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(new UpdateGenreCommand(genreDTO));
            return Ok(result);

        }

        [HttpDelete("/{Id:int}")]
        public async Task<ActionResult> Delete(int Id) 
        {
            var result = await _mediator.Send(new DeleteGenreCommand(Id));
            return result ? Ok() : BadRequest();

        }



    }
}
