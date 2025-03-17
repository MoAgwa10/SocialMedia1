using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SocialMediaBackend.Permissions;
using Volo.Abp.Application.Services;

namespace SocialMediaBackend.Dto
{
    public interface IPostService:IApplicationService
    {
        [Authorize(SocialMediaBackendPermissions.List.Default)]
        Task<List<PostDto>> List();

       
    }
}
