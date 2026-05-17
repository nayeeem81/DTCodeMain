using Microsoft.Extensions.Localization;

namespace ResourceLibrary;
                              
public static class GlobalResources
{
    public static IStringLocalizer<SharedResource> Localizer 
    { 
        get; set; 
    }
}
