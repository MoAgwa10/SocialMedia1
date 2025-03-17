using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SocialMediaBackend.Data;

/* This is used if database provider does't define
 * ISocialMediaBackendDbSchemaMigrator implementation.
 */
public class NullSocialMediaBackendDbSchemaMigrator : ISocialMediaBackendDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
