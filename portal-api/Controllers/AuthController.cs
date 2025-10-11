using Microsoft.AspNetCore.Mvc;
using PortalApi.Models;
using PortalApi.Services;

namespace PortalApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new LoginResponse 
                    { 
                        Success = false, 
                        Message = "Invalid request data" 
                    });
                }

                var result = await _authService.LoginAsync(request);
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            // Token-based logout - client removes token
            return Ok(new { message = "Logged out successfully" });
        }
    }
}