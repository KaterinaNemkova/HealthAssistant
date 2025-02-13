using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using System.Security;

namespace HealthAssistant.Domain.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task Create(User user);
        Task<User?> GetByEmail(string email);
    }
}