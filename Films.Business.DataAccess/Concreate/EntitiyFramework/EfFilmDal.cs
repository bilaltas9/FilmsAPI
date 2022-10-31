using Films.Business.DataAccess.Abstract;
using Films.Business.DataAccess.Context;
using Films.Core.DataAccess.EntityFramework;
using Films.Entities.Concreate;

namespace Films.Business.DataAccess.Concreate.EntitiyFramework
{
    public class EfFilmDal : EfEntityRepositoryBase<Film, FilmContext>, IFilmDal
    {
        public List<Film> GetFilmByParam(int Size, int PageCount)
        {
            using (var context = new FilmContext())
            {
                return context.Films.Skip(Size * PageCount).Take(PageCount).ToList();
            }
        }
    }
}
