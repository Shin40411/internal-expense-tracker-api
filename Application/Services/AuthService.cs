using Expense_tracker_api.Application.DTOs.Auth;
using Expense_tracker_api.Application.Interfaces;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
        {
            var existingUser = (await _unitOfWork.Users
                .FindAsync(u => u.Email == dto.Email))
                .FirstOrDefault();

            if (existingUser != null)
                throw new BadHttpRequestException("Email already exists");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = _passwordHasher.Hash(dto.Password),
                FullName = dto.FullName,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user);

            return new AuthResponse
            {
                AccessToken = token
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginDto dto)
        {
            var user = (await _unitOfWork.Users
               .FindAsync(u => u.Email == dto.Email))
               .FirstOrDefault() ?? throw new UnauthorizedAccessException("Invalid credentials");

            if (!_passwordHasher.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return new AuthResponse
            {
                AccessToken = token
            };
        }
    }
}
