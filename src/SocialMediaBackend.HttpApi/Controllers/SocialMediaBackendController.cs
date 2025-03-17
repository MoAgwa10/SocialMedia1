using SocialMediaBackend.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SocialMediaBackend.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SocialMediaBackendController : AbpControllerBase
{
    protected SocialMediaBackendController()
    {
        LocalizationResource = typeof(SocialMediaBackendResource);
    }
}
