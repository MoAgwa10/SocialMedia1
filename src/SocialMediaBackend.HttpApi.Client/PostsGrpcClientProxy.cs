using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bdaya.SocialTraining.V1;
using static Bdaya.SocialTraining.V1.PostService;

namespace SocialMediaBackend
{
    public class PostsGrpcClientProxy : IPostService
    {

        protected PostServiceClient Client { get; }
        public PostsGrpcClientProxy(PostServiceClient client)
        {
            Client = client;
        }



        public async Task<CreatePostResponse> CreatePost(CreatePostRequest post)
        {
            return await Client.CreatePostAsync(post);
        }

        public async Task<DeletePostResponse> DeletePost(DeletePostRequest postId)
        {
            return await Client.DeletePostAsync(postId);
        }

        public async Task<GetPostResponse> GetPost(GetPostRequest postRequest)
        {
            return await Client.GetPostAsync(postRequest);
        }

        public async Task<ListPostsResponse> ListPosts(ListPostsRequest postsRequest)
        {
            return await Client.ListPostsAsync(postsRequest);
        }

        public async Task<UpdatePostResponse> UpdatePost(UpdatePostRequest updatePostId)
        {
            return await Client.UpdatePostAsync(updatePostId);
        }
    }
}
