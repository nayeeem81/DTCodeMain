using Common;
using FineArtsWebApp.Areas.Admin.Models.ContentPanelSettings;

namespace FineArtsWebApp
{
    public interface IContentManagementDataService
    {
        Task<List<PostTemplateViewModel>>
           GetAllPageGroupPanelConfigurations(
                   EnumPublicPage pageName,
                   string viewMoreUrl,
                   string viewPostDetailsUrl,
                   EnumCountry country,
                   int dayTimeSlot);

        Task<List<PostTemplateViewModel>>
            GetAllPageGroupPanelConfigurations(
                    EnumPublicPage pageName,
                    string viewMoreUrl,
                    string viewPostDetailsUrl,
                    EnumCountry country,
                    int dayTimeSlot,
                    EnumMarketType? typeMarket,
                    long typeMarketCategoryID,
                    int? pageNumber,
                    int pageSize,
                    decimal? price
                    );

        Task<GroupPanelConfigurationViewModel> GetSingleGroupPanelConfig(int panelConfigID, EnumCountry country);

        Task<GroupPanelConfigurationViewModel> GetSingleGroupConfigPosts(int panelConfigID, EnumCountry country);
    }
}
