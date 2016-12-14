using OnionTemplate.Domain.Interfaces.Repositories;
using OnionTemplate.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionTemplate.Infrastructure.Data.Contexts;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace OnionTemplate.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericSqlRepository<User>, IUserRepository
    {
        private readonly CloudStorageAccount _storageAccount;
        public UserRepository(ApplicationContext context, CloudStorageAccount storageAccount) : base(context)
        {
            _storageAccount = storageAccount;
        }

        public async Task UpdateUserProfileImage(int userId, Stream imageStream)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return;

            string blobName = Guid.NewGuid().ToString() + ".png";
            var blobClient = _storageAccount.CreateCloudBlobClient();
            blobClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3);
            var imagesBlobContainer = blobClient.GetContainerReference("images");
            // Retrieve reference to a blob. 
            var imageBlob = imagesBlobContainer.GetBlockBlobReference(blobName);
            // Create the blob by uploading a local file.
            await imageBlob.UploadFromStreamAsync(imageStream);

            // TODO: determine if this should be in service or not. It probably should be
        }
    }
}
