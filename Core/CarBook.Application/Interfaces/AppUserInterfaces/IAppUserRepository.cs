using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
    }
}
