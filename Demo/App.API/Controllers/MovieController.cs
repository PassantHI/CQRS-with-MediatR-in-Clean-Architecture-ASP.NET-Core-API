using App.Application.DTOs;
using App.Application.Features.Movies.Commands;
using App.Application.Features.Movies.Queries;
using App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpGet("/{Id:int}")]
        public async Task<ActionResult<MovieDTO>> GetById(int Id)
        {
            var result = await _mediator.Send(new GetMovieQuery(Id));
            return result is not null ? Ok(result) : NotFound();


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAll()
        {
            var query = new GetAllMoviesQuery();
            var result = await _mediator.Send(query);
            return result.IsNullOrEmpty() ? NotFound() : Ok(result);
        }

        [HttpGet("/{keyword}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Search(string keyword)
        {
            var result = await _mediator.Send(new SearchMovieQuery(keyword));
            return result.IsNullOrEmpty() ? NotFound() : Ok(result);


        }


        [HttpGet("{genre}")]

        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetByGenre(string genre) 
        {
            var result = await _mediator.Send(new GetMoviesByGenreQuery(genre));
            return result.IsNullOrEmpty() ? NotFound() : Ok(result);


        }
        [HttpGet("Rate/")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetByRate(int NTop)
        {
            var result = await _mediator.Send(new GetTopRatedMoviesQuery(NTop));
            return result.IsNullOrEmpty()?NotFound() :Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result =await _mediator.Send(new AddMovieCommand(movieDTO));
            return Ok(result);

           

        }
        [HttpPut]
        public async Task<ActionResult<MovieDTO>> EditMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(new UpdateMovieCommand(movieDTO));
            return Ok(result);


        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand(id));
            return result ? Ok():BadRequest();
        }







    }
}
