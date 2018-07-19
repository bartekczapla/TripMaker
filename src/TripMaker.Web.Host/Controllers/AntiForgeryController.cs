using Microsoft.AspNetCore.Antiforgery;
using TripMaker.Controllers;

namespace TripMaker.Web.Host.Controllers
{
    public class AntiForgeryController : TripMakerControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
