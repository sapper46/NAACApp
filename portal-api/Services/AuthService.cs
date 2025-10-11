using Microsoft.IdentityModel.Tokens;
using PortalApi.Data;
using PortalApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PortalApi.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<UserDto?> GetUserByIdAsync(int userId);
    }

    public class AuthService : BaseService, IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                ValidateStringNotEmpty(request.Username, nameof(request.Username));
                ValidateStringNotEmpty(request.Password, nameof(request.Password));

                var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
                
                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return new LoginResponse
                    {
                        Success = false,
                        Message = "Invalid username or password"
                    };
                }

                // Update last login
                user.LastLogin = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                var token = GenerateJwtToken(user);
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    CreatedDate = user.CreatedDate,
                    LastLogin = user.LastLogin
                };

                return new LoginResponse
                {
                    Success = true,
                    Token = token,
                    User = userDto
                };
            }
            catch (Exception ex)
            {
                HandleException(ex, "Login");
                return new LoginResponse
                {
                    Success = false,
                    Message = "An error occurred during login"
                };
            }
        }

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                CreatedDate = user.CreatedDate,
                LastLogin = user.LastLogin
            };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
            var key = Encoding.ASCII.GetBytes(jwtKey);

            var claims = new[]
            {
                new Claim("userId", user.UserId.ToString()),
                new Claim("username", user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}