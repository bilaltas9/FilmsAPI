using Films.Business.Dto;
using Films.Entities.Concreate;

namespace Films.Business.Abstract
{
    public interface IFilmService
    {
        List<Film> GetFilms(int Size, int PageCount);
        void AddFilm(AddFilmDto addFilmDto);
        Film GetFilmById(int Id);
        void AddDetailsToFilm(AddDetailsToFilmDto addDetailsToFilmDto);
        void FilmAdvice(FilmAdviceDto filmAdviceDto);
        public bool SendEmail(string content, string toAdress);
    }
}
