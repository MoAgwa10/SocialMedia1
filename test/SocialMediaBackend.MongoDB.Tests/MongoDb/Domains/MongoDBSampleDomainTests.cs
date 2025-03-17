using SocialMediaBackend.Samples;
using Xunit;

namespace SocialMediaBackend.MongoDB.Domains;

[Collection(SocialMediaBackendTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<SocialMediaBackendMongoDbTestModule>
{

}
