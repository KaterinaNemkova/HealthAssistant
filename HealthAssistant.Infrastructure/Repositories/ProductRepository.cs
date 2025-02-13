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
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(HealthAssistantDbContext context) : base(context) { }

        public async Task<Product?> GetByNameAsync(string name, CancellationToken token)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name,token);
        }

        public async Task<List<Product>> SearchByNameAsync(string name,CancellationToken token)
        {
            return await _context.Products.Where(p => p.Name.Contains(name))
                              
                              .ToListAsync(token);
        }
    }
}
