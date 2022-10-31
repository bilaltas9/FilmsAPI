using Films.Core.DataAccess;
using Films.Entities.Concreate;

namespace Films.Business.DataAccess.Abstract
{
    public interface IFilmDal : IEntityRepository<Film>
    {
        List<Film> GetFilmByParam(int Size, int PageCount);
    }
}
