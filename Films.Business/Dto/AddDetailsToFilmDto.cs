
using System.ComponentModel.DataAnnotations;

namespace Films.Business.Dto
{
    public class AddDetailsToFilmDto
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        [Range(1, 10)]
        public int Point { get; set; }
    }
}
