using Films.Business.Abstract;
using Films.Business.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Films.API.Controllers
{
    public class FilmController : BaseController
    {
        private IFilmService _filmService;
        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [Authorize]
        [HttpGet("GetFilms", Name = "GetFilms")]
        public IActionResult GetFilms(int Size, int PageCount)
        {
            try
            {
                var films = _filmService.GetFilms(Size, PageCount);
                return Ok(films);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("AddFilm", Name = "AddFilm")]
        public IActionResult AddFilm([FromBody] AddFilmDto addFilmDto)
        {
            try
            {
                _filmService.AddFilm(addFilmDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetFilmById", Name = "GetFilmById")]
        public IActionResult GetFilmById(int Id)
        {
            try
            {
                var film = _filmService.GetFilmById(Id);
                return Ok(film);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("AddDetailsToFilm", Name = "AddDetailsToFilm")]
        public IActionResult AddDetailsToFilm([FromBody] AddDetailsToFilmDto addDetailsToFilmDto)
        {
            try
            {
                _filmService.AddDetailsToFilm(addDetailsToFilmDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("FilmAdvice", Name = "FilmAdvice")]
        public IActionResult FilmAdvice([FromBody] FilmAdviceDto filmAdviceDto)
        {
            try
            {
                _filmService.FilmAdvice(filmAdviceDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
