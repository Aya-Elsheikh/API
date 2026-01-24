using Domain.Entities;

namespace Application.Comman.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Guid? userId, string email, string? name, string provider);
    }
}
