using Volo.Abp.Modularity;

namespace SocialMediaBackend;

[DependsOn(
    typeof(SocialMediaBackendApplicationModule),
    typeof(SocialMediaBackendDomainTestModule)
)]
public class SocialMediaBackendApplicationTestModule : AbpModule
{

}
