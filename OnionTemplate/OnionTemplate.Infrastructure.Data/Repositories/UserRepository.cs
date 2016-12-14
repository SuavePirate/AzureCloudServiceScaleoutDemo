using OnionTemplate.Domain.Interfaces.Repositories;
using OnionTemplate.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionTemplate.Infrastructure.Data.Contexts;

namespace OnionTemplate.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericSqlRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
