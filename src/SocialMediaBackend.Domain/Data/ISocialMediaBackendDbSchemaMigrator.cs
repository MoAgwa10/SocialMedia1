using System.Threading.Tasks;

namespace SocialMediaBackend.Data;

public interface ISocialMediaBackendDbSchemaMigrator
{
    Task MigrateAsync();
}
