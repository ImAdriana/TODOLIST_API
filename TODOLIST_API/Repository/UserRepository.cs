using TODOLIST_API.Context;
using TODOLIST_API.DTO;
using TODOLIST_API.Models;

namespace TODOLIST_API.Repository
{
    public class UserRepository : IUserRepository
    {
        public AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Username).ToList();

        }

        public bool IsUniqueUser(string username)
        {
            return !_context.Users.Any(u => u.Username.ToLower().Trim() == username.ToLower().Trim());
        }

        public Task<UserLoginResponseDto> Login(UserLoginDto login)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(UserCreateDto userCreateDto)
        {
            var encriptedPassword = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);
            var user = new User()
            {
                Username = userCreateDto.Username ?? "No Username",
                Name = userCreateDto.Name,
                Password = encriptedPassword,
                Role = userCreateDto.Role,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
