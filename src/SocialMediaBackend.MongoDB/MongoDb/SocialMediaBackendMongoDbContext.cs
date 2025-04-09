using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace SocialMediaBackend.MongoDB;

[ConnectionStringName("Default")]
public class SocialMediaBackendMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Posts>Posts =>Collection<Posts>();
  
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});

        modelBuilder.Entity<Posts>(b =>
        {
            b.CollectionName = SocialMediaBackendConsts.DbSchema + "Posts";
            b.BsonMap.ConfigureAbpConventions();
        });
       
    }
}
