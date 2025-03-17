using Volo.Abp.Modularity;

namespace SocialMediaBackend;

/* Inherit from this class for your domain layer tests. */
public abstract class SocialMediaBackendDomainTestBase<TStartupModule> : SocialMediaBackendTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
