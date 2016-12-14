using System;
using OnionTemplate.Domain.Models;
using OnionTemplate.Domain.Models.Data;
using System.IO;
using System.Threading.Tasks;

namespace OnionTemplate.Domain.Interfaces.Repositories
{
	/// <summary>
	/// Definition of a user repository
	/// </summary>
	public interface IUserRepository : IGenericRepository<User>
	{
        // TODO: add methods that are non-generic user-specific

        Task UpdateUserProfileImage(int userId, Stream imageStream);
	}
}
