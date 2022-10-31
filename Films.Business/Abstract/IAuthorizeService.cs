using Films.Business.Dto;

namespace Films.Business.Abstract
{
    public interface IAuthorizeService
    {
        string Authorize(AuthorizeDto authorizeDto);
    }
}
