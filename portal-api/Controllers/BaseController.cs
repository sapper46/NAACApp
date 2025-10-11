using Microsoft.AspNetCore.Mvc;

namespace PortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<T> HandleResult<T>(T result)
        {
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        protected ActionResult HandleException(Exception ex)
        {
            // Log exception here in production
            return StatusCode(500, new { message = "An error occurred while processing your request." });
        }

        protected string GetUserId()
        {
            return User?.FindFirst("userId")?.Value ?? string.Empty;
        }
    }
}