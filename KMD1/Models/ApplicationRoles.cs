using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace KMD1.Models
{
    [CollectionName("Roles")]
    public class ApplicationRoles : MongoIdentityRole<Guid>
    {

    }
}
