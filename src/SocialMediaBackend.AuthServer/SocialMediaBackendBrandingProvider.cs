using Microsoft.Extensions.Localization;
using SocialMediaBackend.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SocialMediaBackend;

[Dependency(ReplaceServices = true)]
public class SocialMediaBackendBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SocialMediaBackendResource> _localizer;

    public SocialMediaBackendBrandingProvider(IStringLocalizer<SocialMediaBackendResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
