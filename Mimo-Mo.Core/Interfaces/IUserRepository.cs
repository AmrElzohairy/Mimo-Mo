using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Core.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User> CreateUserAsync(User user);
    Task<User?> DeleteUserAsync(int id);
    Task<bool> EmailExistsAsync(string email);
}