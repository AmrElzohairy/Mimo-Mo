using Mimo_Mo.Core.Enums;

namespace Mimo_Mo.Application.Dtos.Auth;

public class RegisterDto
{
    public string Username { get; set; }
    public string Email { get; set; } 
    public string PasswordHash { get; set; } 
    public UserRole? Role { get; set; } = UserRole.User;
}