using TODOLIST_API.DTO;
using TODOLIST_API.Models;

namespace TODOLIST_API.Repository
{
    public interface IUserRepository
    {
        // Devuelve todos los usuarios en ICollection del tipo User
        ICollection<User> GetUsers();

        // Recibe un id y devuelve un solo objeto User o Null si no se encuentra
        User? GetUser(int id);

        // Recibe un nombre de usuario y devuelve un bool indicando si el nombre de usuario es único
        bool IsUniqueUser(string username);

        // Recibe un objeto UserLoginDto y devuelve un UserLoginResponseDto de forma asíncrona
        Task<UserLoginResponseDto> Login(UserLoginDto login);

        // Recibe un objeto UserCreateDto y devuelve un objeto User de forma asíncrona
        Task<User> Register(UserCreateDto userCreateDto);
    }
}
