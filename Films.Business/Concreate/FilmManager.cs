using Films.Business.Abstract;
using Films.Business.DataAccess.Abstract;
using Films.Business.Dto;
using Films.Entities.Concreate;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Films.Business.Concreate
{
    public class FilmManager : IFilmService
    {
        private IFilmDal _filmDal;
        public FilmManager(IFilmDal filmDal)
        {
            _filmDal = filmDal;
        }
        public void AddDetailsToFilm(AddDetailsToFilmDto addDetailsToFilmDto)
        {
            var film = GetFilmById(addDetailsToFilmDto.Id);
            film.Note = addDetailsToFilmDto.Note;
            film.Point = addDetailsToFilmDto.Point;
            _filmDal.Update(film);
        }

        public void AddFilm(AddFilmDto addFilmDto)
        {
            addFilmDto?.Films?.ForEach(film =>
            {
                _filmDal.Add(film);
            });
        }

        public void FilmAdvice(FilmAdviceDto filmAdviceDto)
        {
            var film = GetFilmById(filmAdviceDto.FilmId);
            SendEmail(film.OriginalTitle ?? throw new Exception("OriginalTitle Is Null") , filmAdviceDto.EMail ?? throw new Exception("EMail Is Null"));
        }

        public Film GetFilmById(int Id)
        {
            var film = _filmDal.Get(film => film.Id == Id);
            if (film == null)
            {
                throw new Exception("Film Does Not Found.!");
            }
            return film;
        }

        public List<Film> GetFilms(int Size, int PageCount)
        {
            var films = _filmDal.GetFilmByParam(Size, PageCount);
            return films;
        }

        public bool SendEmail(string content, string toAdress)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("bilaltas9@gmail.com"));
                email.To.Add(MailboxAddress.Parse(toAdress));
                email.Subject = "Test Email Subject";
                email.Body = new TextPart(TextFormat.Plain) { Text = content };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("bilaltas9@gmail.com", "Bursa1299**");
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
