using FluentValidation;

namespace Mimo_Mo.Application.Features.Users.Commands.Login;

public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(x => x.loginDto.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.loginDto.Password).NotEmpty().WithMessage("Password is required");
    }
}