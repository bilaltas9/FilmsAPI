using Films.Entities.Concreate;

namespace Films.API.UnitTest.Data
{
    internal class FilmsData
    {
        internal List<Film> GetFilmsData()
        {
            List<Film> productsData = new List<Film>
            {
                new Film
                {
                   Id = 1,
                   Adult = false,
                   Note = "Nice Film",
                   OriginalLanguage = "en",
                   OriginalTitle = "Martinian",
                   Overview = "Good",
                   Point = 7,
                   PosterPath ="/test/movies/12121.png",
                   ReleaseDate = DateTime.Now,
                   Title = "Movie",
                   VoteAverage = 5,
                   VoteCount = 53432
                },
                new Film
                {
                   Id = 2,
                   Adult = true,
                   Note = "Bad Film",
                   OriginalLanguage = "tr",
                   OriginalTitle = "Test",
                   Overview = "Bad",
                   Point = 1,
                   PosterPath ="/test/movies/55-00.png",
                   ReleaseDate = DateTime.Now,
                   Title = "Movie in 3D",
                   VoteAverage = 2,
                   VoteCount = 12121
                }
            };
            return productsData;
        }

    }
}
