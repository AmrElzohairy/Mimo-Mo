using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Core.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}