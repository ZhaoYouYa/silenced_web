using Microsoft.AspNetCore.Mvc;

namespace DesktopTool
{
    public class DesktopToolController : ControllerBase
    {
        [Route("Test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Yesdf");
        }
    }
}
