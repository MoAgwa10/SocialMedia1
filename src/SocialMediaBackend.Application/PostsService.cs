using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaBackend;
using SocialMediaBackend.Dto;
using Volo.Abp.Domain.Repositories;

public class PostsService : SocialMediaBackendAppService, IPostService
{
   public IRepository<Post,Guid> Repository { get; set; }

    public PostsService(IRepository<Post,Guid> repository)
    {
        Repository = repository;
    }
    
    public async Task<List<PostDto>> List()
    {
       var Post= await Repository.GetListAsync();
       return ObjectMapper.Map<List<Post>,List<PostDto>>(Post);
    }
    
   
}
