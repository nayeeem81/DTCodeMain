using BusinessModel;
using Main.Common.Enums;

namespace IServices;

public interface IQueryPagePanelService
{
    Task<List<PanelPostDataModel>>
        GetSelectProducts ( EnumCompanyName company );

    Task<PageDataModel> GetPanelList ( int pageID );

}

