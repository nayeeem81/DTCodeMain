using Common;
using FineArtsWebApp.Areas.Admin.Models.ContentPanelSettings;

namespace FineArtsWebApp
{
    public interface IGroupPanelConfigService
    {
        Task<List<PostTemplateViewModel>>
           GetAllPageGroupPanelConfigurations(
                   EnumPublicPage pageName,
                   string viewMoreUrl,
                   string viewPostDetailsUrl,
                   EnumCountry country,
                   int dayTimeSlot,
                   EnumCurrency currency);

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
                    decimal? price,
                    EnumCurrency currency
                    );

        Task<bool> PublishAllGroupPanelConfig(EnumDeviceType device, EnumPublicPage page, int currentUserID, EnumCountry country);

        Task<GroupPanelConfigurationViewModel> GetSingleGroupPanelConfig(int panelConfigID, EnumCountry country);

        Task<bool> AddGroupPanelConfig(GroupPanelConfigurationViewModel objGroupPanelVM, int currentUserID, EnumCountry country);

        Task<bool> AddSelectedPost(int postID, int groupConfigID, long fileId, EnumCountry country, int currentUserID);

        Task<bool> UpdateGroupPanelConfig(GroupPanelConfigurationViewModel objGroupPanelVM, EnumCountry country, int currentUserID);

        Task<bool> RemoveSelectedPost(int groupPostID, int currentUserID, EnumCountry country);

        Task<bool> DeleteGroupPanelConfig(int id, int currentUserID, EnumCountry country);

        Task<bool> UpdateDisplayOrder(PanelDisplayOrderViewModel objNewDisplayOrder, EnumCountry country, int currentUserID);

        Task<bool> UpdatePostDisplayOrder(List<int> listGroupPosts, int currentUserID, EnumCountry country);

        Task<GroupPanelConfigurationViewModel> GetSingleGroupConfigPosts(int panelConfigID, EnumCountry country, EnumCurrency currency);
    }
}
