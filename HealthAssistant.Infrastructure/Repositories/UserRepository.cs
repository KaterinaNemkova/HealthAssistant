using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAssistant.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(HealthAssistantDbContext context) : base(context) { }

        public async Task Create(User user)
        {
           user.CalculateDailyCalories();
            var userEntity = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Sex = user.Sex,
                DateOnly = user.DateOnly,
                Email = user.Email,
                Weight = user.Weight,
                Height = user.Height,
                Allergies = user.Allergies,
                Intolerances = user.Intolerances,
                ActivityLevel = user.ActivityLevel,
                HashedPassword = user.HashedPassword,
                DailyCalories = user.DailyCalories,
                
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
