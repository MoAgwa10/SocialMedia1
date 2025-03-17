using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace SocialMediaBackend.MongoDB;

[DependsOn(
    typeof(SocialMediaBackendApplicationTestModule),
    typeof(SocialMediaBackendMongoDbModule)
)]
public class SocialMediaBackendMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = SocialMediaBackendMongoDbFixture.GetRandomConnectionString();
        });
    }
}
