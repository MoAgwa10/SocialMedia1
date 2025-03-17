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
    public IMongoCollection<Post>Posts =>Collection<Post>();
    public IMongoCollection<PostComment> PostComments => Collection<PostComment>();
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});

        modelBuilder.Entity<Post>(b =>
        {
            b.CollectionName = SocialMediaBackendConsts.DbSchema + "Posts";
        });
        modelBuilder.Entity<PostComment>(b =>
        {
            b.CollectionName = SocialMediaBackendConsts.DbSchema + "Comments";
            
        });

    }
}
