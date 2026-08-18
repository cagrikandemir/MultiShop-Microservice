using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Images.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class GoogleDriveImageUploadController : ControllerBase
    {
    }
}
