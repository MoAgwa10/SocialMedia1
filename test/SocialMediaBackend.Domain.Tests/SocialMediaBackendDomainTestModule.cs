using Volo.Abp.Modularity;

namespace SocialMediaBackend;

[DependsOn(
    typeof(SocialMediaBackendDomainModule),
    typeof(SocialMediaBackendTestBaseModule)
)]
public class SocialMediaBackendDomainTestModule : AbpModule
{

}
