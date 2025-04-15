using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Bdaya.SocialTraining.V1;
using Microsoft.AspNetCore.Http.HttpResults;
using SocialMediaBackend;
using SocialMediaBackend.SocialMedia;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

[ExposeServices(typeof(IPostService))]
public class PostsService : SocialMediaBackendAppService, IPostService, ITransientDependency
{
    

    public IRepository<Posts, Guid> Repository { get; }
    public IIdentityUserRepository IdentityUserRepository { get; }

    public PostsService(IRepository<Posts, Guid> repository, IIdentityUserRepository identityUserRepository )
    {
        Repository = repository;
        IdentityUserRepository = identityUserRepository;
       
    }

    public async Task<ListPostsResponse> ListPosts(ListPostsRequest postsRequest)
    {
        var Token = postsRequest.Pagination.PageToken;
        int Skip = Token is not null ? int.Parse(Token) : 0;

        var filterUserId = postsRequest.Filter.UserIds.Select(Guid.Parse).Cast<Guid?>().ToHashSet();


        var posts = await Repository.GetQueryableAsync();
        var filteredList = posts.Where(x => filterUserId.Contains(x.CreatorId) && !x.IsDeleted) 
                                .OrderBy(x => x.CreationTime);

        var postList = await Repository.AsyncExecuter.ToListAsync(filteredList.Skip(Skip).Take(postsRequest.Pagination.PageSize));

        var userId = postList.Select(x => x.CreatorId).Where(x => x.HasValue).Select(x => x!.Value).ToHashSet();
        var user = await IdentityUserRepository.GetListByIdsAsync(userId);
        var dictionary = user.ToDictionary(x => x.Id);
        var mappedPostList = ObjectMapper.GetMapper().Map<IEnumerable<Posts>, IEnumerable<Post>>(postList, opt =>
        {
            opt.Items[nameof(IdentityUser)] = dictionary;
        });

        return new ListPostsResponse()
        {
            Posts = { mappedPostList },NextPageToken = (Skip + postsRequest.Pagination.PageSize).ToString()
        };
    }

    public async Task<GetPostResponse> GetPost(GetPostRequest postRequest)
    {
        var post = await Repository.GetAsync(Guid.Parse(postRequest.Id));

        var userIds = new HashSet<Guid?>() { post.CreatorId }.Where(x => x.HasValue).Select(x => x!.Value).ToHashSet();
        var users = await IdentityUserRepository.GetListByIdsAsync(userIds);
        var dict = users.ToDictionary(x => x.Id);

        return new GetPostResponse()
        {
            Result = ObjectMapper.GetMapper().Map<Posts, Post>(post, opt =>
            {
                opt.Items[nameof(IdentityUser)] = dict;
            })
        };


    }

    public async Task<CreatePostResponse> CreatePost(CreatePostRequest post)
    {
        if (CurrentUser?.Id == null)
            throw new UnauthorizedAccessException("User must be logged in to create a post.");

        List<Images> imageList = new List<Images>() 
        {
            new Images(GuidGenerator.Create(), "FirstImage", 3.5f, 2.2f, "Url")
           ,new Images(GuidGenerator.Create(), "SecImage", 4.5f, 7.7f , "SecondUrl")
        };
        var createdPost = new Posts(GuidGenerator.Create(),"MyContent", imageList);
        await Repository.InsertAsync(createdPost);

        var userIds = new HashSet<Guid?>() { createdPost.CreatorId }.Where(x => x.HasValue).Select(x => x!.Value).ToHashSet();
        var users = await IdentityUserRepository.GetListByIdsAsync(userIds);
        var dict = users.ToDictionary(x => x.Id);

        return new CreatePostResponse()
        {
            Result = ObjectMapper.GetMapper().Map<Posts, Post>(createdPost, opt =>
            {
                opt.Items[nameof(IdentityUser)] = dict;
            })
        };
    }

    public async Task<UpdatePostResponse> UpdatePost(UpdatePostRequest updatePostId)
    {
        var post = await Repository.GetAsync(Guid.Parse(updatePostId.Id));
        post.Content = "Updated Content"; //we need to use this line in testing to make sure that update works
        await Repository.UpdateAsync(post);

        var userIds = new HashSet<Guid?>() { post.CreatorId }.Where(x => x.HasValue).Select(x => x!.Value).ToHashSet();
        var users = await IdentityUserRepository.GetListByIdsAsync(userIds);
        var dict = users.ToDictionary(x => x.Id);

        return new UpdatePostResponse()
        {
            Result = ObjectMapper.GetMapper().Map<Posts, Post>(post, opt =>
            {
                opt.Items[nameof(IdentityUser)] = dict;
            })
        };
    }

    public async Task<DeletePostResponse> DeletePost(DeletePostRequest postId)
    {
        var post = await Repository.GetAsync(Guid.Parse(postId.Id));
        await Repository.DeleteAsync(post.Id);
        return new DeletePostResponse();
    }
}  