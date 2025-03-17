using Volo.Abp.Modularity;

namespace SocialMediaBackend;

public abstract class SocialMediaBackendApplicationTestBase<TStartupModule> : SocialMediaBackendTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
