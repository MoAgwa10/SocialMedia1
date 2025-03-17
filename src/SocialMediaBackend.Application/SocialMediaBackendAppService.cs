using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaBackend.Localization;
using Volo.Abp.Application.Services;

namespace SocialMediaBackend;

/* Inherit your application services from this class.
 */
public abstract class SocialMediaBackendAppService : ApplicationService
{
    protected SocialMediaBackendAppService()
    {
        LocalizationResource = typeof(SocialMediaBackendResource);
    }
}
