using CarBook.Application.Interfaces.AppRoleInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppRoleRepositories
{
    public class AppRoleRepository : IAppRoleRepository
    {
        private readonly CarBookContext _context;
        public AppRoleRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            var values = await _context.AppRoles
                .Where(filter)
                .FirstOrDefaultAsync();
            return values;
        }
    }
}