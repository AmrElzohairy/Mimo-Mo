using FluentValidation;

namespace Mimo_Mo.Application.Features.Users.Commands.Register;

public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        RuleFor(u => u.registerDto.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(u => u.registerDto.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(u => u.registerDto.PasswordHash).NotEmpty().WithMessage("Password is required");
        RuleFor(u => u.registerDto.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(u => u.registerDto.Role).IsInEnum().WithMessage("Role must be In range [1 => 2]");
    }
}