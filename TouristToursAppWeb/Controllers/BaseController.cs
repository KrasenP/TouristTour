using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TouristToursAppWeb.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
