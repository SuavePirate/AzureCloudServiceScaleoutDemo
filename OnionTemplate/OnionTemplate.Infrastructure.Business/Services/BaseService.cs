using OnionTemplate.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTemplate.Infrastructure.Business.Services
{
    public class BaseService : IBaseService
    {
        public BaseService()
        {
        }

        public IEnumerable<string> Validate(object model)
        {
            // TODO: do some validation against data annotations
            return null;
        }
    }
}
