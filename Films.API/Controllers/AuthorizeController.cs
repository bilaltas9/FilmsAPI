using Films.Business.Abstract;
using Films.Business.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Films.API.Controllers
{
    public class AuthorizeController : BaseController
    {
        private readonly IAuthorizeService _authorizationService;
        public AuthorizeController(IAuthorizeService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost("Authorize", Name = "Authorize")]
        public IActionResult Authorize([FromBody] AuthorizeDto authorizeDto)
        {
            try
            {
                var token = _authorizationService.Authorize(authorizeDto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
