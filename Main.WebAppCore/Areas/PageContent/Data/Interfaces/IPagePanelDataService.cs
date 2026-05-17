using Common;
using Model;

namespace FineArtsWebApp
{
    public interface IPagePanelDataService
    {
        Task<List<PanelPostViewModel>> GetSelectProducts(EnumCompanyName company);

        Task<List<PanelPostViewModel>> GetSelectAdminPosts(EnumCompanyName company);

        Task<int> CreateNewPanels (
            LocalModel model,

             EnumCompanyName enumCompany,

             List<PanelPostViewModel> listUserSelectedPosts,

             ModelBase modelBase

        );

        Task<PagePanelViewModel> GetPreviewPanel ( int panelId );

        Task<List<PagePanelViewModel>> GetPanelList ( int pageID );
    }
}
