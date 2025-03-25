using SocialMediaBackend.MongoDB;
using SocialMediaBackend.Samples;
using Xunit;

namespace SocialMediaBackend.MongoDb.Applications;

[Collection(SocialMediaBackendTestConsts.CollectionDefinitionName)]
public class MongoDbPostAppServiceTest : PostAppServiceTest<SocialMediaBackendMongoDbTestModule>
{

}
