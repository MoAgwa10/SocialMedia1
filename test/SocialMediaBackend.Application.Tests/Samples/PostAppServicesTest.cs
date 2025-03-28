using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bdaya.SocialTraining.V1;
using Shouldly;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Xunit;

namespace SocialMediaBackend.Samples
{
    public abstract class PostAppServiceTest<TStartupModule> : SocialMediaBackendApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private IPostService AppService { get; }

        private readonly IIdentityUserAppService _userAppService;
        public PostAppServiceTest()
        {
            AppService = GetRequiredService<IPostService>();
            _userAppService = GetRequiredService<IIdentityUserAppService>();
        }

        [Fact]

        public async Task EnsureCreatePostAndGetPostReturnSameResult()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

            var createPostResponse = await AppService.CreatePost(new CreatePostRequest() { });
            var Createdpost = createPostResponse.Result;

            Createdpost.Content.ShouldBe("MyContent");
            Createdpost.User.Name.ShouldBe("admin");
            Createdpost.Images.ShouldContain(I => I.Name == "FirstImage");
            Createdpost.Images.ShouldContain(I => I.Name == "SecImage");
            Createdpost.Images.Count.ShouldBe(2);
            Createdpost.User.ShouldNotBeNull();
            Createdpost.User.Id.ShouldNotBeNull();
            Createdpost.User.Name.ShouldNotBeNull();


            var getPost = await AppService.GetPost(new()
            {
                Id = Createdpost.Id
            });

            var theReturnedPost = getPost.Result;
            theReturnedPost.Id.ShouldBe(Createdpost.Id);
            theReturnedPost.Content.ShouldBe(Createdpost.Content);
            theReturnedPost.Images.ShouldBe(Createdpost.Images);


        }

        [Fact]
        public async Task EnsureUpdatePostReturnPost_WithTheUpdatedValues()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

            var createPostResponse = await AppService.CreatePost(new CreatePostRequest() { });
            var Createdpost = createPostResponse.Result;

            Createdpost.Content.ShouldBe("MyContent");
            Createdpost.User.Name.ShouldBe("admin");
            Createdpost.Images.ShouldContain(I => I.Name == "FirstImage");
            Createdpost.Images.ShouldContain(I => I.Name == "SecImage");
            Createdpost.Images.Count.ShouldBe(2);

            var updatePost = await AppService.UpdatePost(new UpdatePostRequest()
            {
                Id = Createdpost.Id
            });
            var theUpdatedPost = updatePost.Result;
            theUpdatedPost.Content.ShouldBe("Updated Content");
        }

        [Fact]
        public async Task EnsureDeletePostWillDeleteIt()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

            var response = await AppService.CreatePost(new CreatePostRequest());
            var theCreatedPost = response.Result;

            await AppService.DeletePost(new DeletePostRequest
            {
                Id = theCreatedPost.Id
            });

            string? errorMessage = null;

            try
            {
                var getPost = await AppService.GetPost(new()
                {
                    Id = theCreatedPost.Id
                });
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                Console.WriteLine($"[ERROR] Post was deleted and cannot be retrieved: {errorMessage}");
            }

            errorMessage.ShouldNotBeNullOrWhiteSpace();

        }


        [Fact]
        public async Task EnsureListPostsReturnsListOfPaginated_SortedAndFilteredPosts()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

            List<Post> returnedPosts = new List<Post>();
            List<string> userIds = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                var response = await AppService.CreatePost(new CreatePostRequest() { });
                returnedPosts.Add(response.Result);
                userIds.Add(response.Result.User.Id);

                response.Result.User.ShouldNotBeNull();
                response.Result.User.Id.ShouldBe(targetUser.Id.ToString());
                response.Result.User.Name.ShouldBe(targetUser.Name);
            }
            returnedPosts.Count.ShouldBe(5);


            var postsListResponse = await AppService.ListPosts(new ListPostsRequest()
            {
                Pagination = new InfiniteScrollPaginationInfo { PageSize = 3, PageToken = "2" },
                Filter = new ListPostsFilter { UserIds = { userIds } },
                Sort = new ListPostsSorting
                {
                    CreationTime = Bdaya.SocialTraining.V1.SortDirection.Ascending
                       ,
                    LatestCommentTime = Bdaya.SocialTraining.V1.SortDirection.Unspecified
                }

            });

            postsListResponse.Posts.Count.ShouldBe(3);

        }

        [Fact]
        public async Task EnsureCreatePost_WithoutLogin_ShouldThrowException()
        {
            // i dont Know The login status because im testing the status where the user posts without Login

            
            string? errorMessage = null;

            try
            {
                await AppService.CreatePost(new CreatePostRequest());
            }
            catch (Exception ex)
            {
                
                errorMessage = ex.Message;
                Console.WriteLine($"ERROR CreatePost failed without login: {errorMessage}");
            }

           
            errorMessage.ShouldNotBeNullOrWhiteSpace();
        }


        [Fact]
        public async Task EnsureUpdatePostWithInvalidId_ShouldThrowException()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

           
            string? errorMessage = null;

            try
            {
                await AppService.UpdatePost(new UpdatePostRequest
                {
                    Id = Guid.NewGuid().ToString()  /*مش موجود ID */
                });
            }
            catch(Exception ex) 
            {
                
                errorMessage=ex.Message;
                Console.WriteLine($"ERROR This Post Is Deleted {errorMessage}");
            }

            errorMessage.ShouldNotBeNullOrWhiteSpace();
        }

       

        [Fact]
        public async Task EnsureCreatePost_SavesCorrectCreatorId()
        {
            var allUsers = await _userAppService.GetListAsync(new());
            var targetUser = allUsers.Items[0];
            using var userDisposable = LoginUser(targetUser.Id);

            var createPostResponse = await AppService.CreatePost(new CreatePostRequest());
            var post = createPostResponse.Result;

            post.ShouldNotBeNull();
            post.User.ShouldNotBeNull();
            post.User.Id.ShouldBe(targetUser.Id.ToString());
        }


        //sorry for delay ( ^_^)ノ M10


    }
}
