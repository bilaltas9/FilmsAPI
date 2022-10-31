using Films.API.Controllers;
using Films.API.UnitTest.Data;
using Films.Business.Abstract;
using Films.Business.Concreate;
using Films.Business.DataAccess.Abstract;
using Films.Business.Dto;
using Films.Entities.Concreate;
using MediaBrowser.Model.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.API.UnitTest
{
    public class FilmsManagerUnitTest
    {
        private readonly Mock<IFilmDal> _filmService;
        public FilmsManagerUnitTest()
        {
            _filmService = new Mock<IFilmDal>();
        }

        [Fact]
        public void GetFilmsTest()
        {
            int size = 2;
            int pageCount = 0;
            var films = new FilmsData().GetFilmsData();
            _filmService.Setup(x => x.GetFilmByParam(size, pageCount))
                .Returns(films);
            var filmObject = _filmService.Object;

            var filmManager = new FilmManager(filmObject);

            var filmList = filmManager.GetFilms(size, pageCount);

            Assert.NotNull(filmObject);
            Assert.Equal(size, filmList.Count());
        }

        [Fact]
        public void GetFilmByIdTest()
        {
            int filmId = 2;
            var film = new FilmsData().GetFilmsData().Where(x => x.Id == filmId).SingleOrDefault()!;
            _filmService.Setup(x => x.Get(film => film.Id == filmId))
                .Returns(film);
            var filmObject = _filmService.Object;

            var filmManager = new FilmManager(filmObject);

            var filmResponse = filmManager.GetFilmById(filmId);

            Assert.NotNull(filmObject);
            Assert.Equal(film, filmResponse);
        }

        [Fact]
        public void AddDetailsToFilmTest()
        {
            int filmId = 2;
            var film = new FilmsData().GetFilmsData().Where(x => x.Id == filmId).SingleOrDefault()!;
            _filmService.Setup(x => x.Get(film => film.Id == filmId))
                .Returns(film);
            var filmObject = _filmService.Object;

            var filmManager = new FilmManager(filmObject);

            var request = new AddDetailsToFilmDto() 
            { 
                Id = filmId,
                Note = "Update Note",
                Point = 9
            };

            filmManager.AddDetailsToFilm(request);

            Assert.NotNull(filmObject);
        }

        [Fact]
        public void FilmAdviceTest()
        {
            int filmId = 2;
            var film = new FilmsData().GetFilmsData().Where(x => x.Id == filmId).SingleOrDefault()!;
            _filmService.Setup(x => x.Get(film => film.Id == filmId))
                .Returns(film);
            var filmObject = _filmService.Object;

            var filmManager = new FilmManager(filmObject);

            var daoMock = new Mock<IFilmService>();

            daoMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);


            var request = new FilmAdviceDto() { EMail = "", FilmId = filmId };
            //var request = new FilmAdviceDto() { EMail = "", FilmId = 1 };

            var filmCont = new FilmController(daoMock.Object);

            filmCont.FilmAdvice(request);

            Assert.NotNull(filmObject);
        }
    }
}
