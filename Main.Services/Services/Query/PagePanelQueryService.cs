using BusinessModel;
using IServices;
using IRepository;
using Main.Common.Enums;

namespace Services.Query;

public class PagePanelQueryService: IQueryPagePanelService
{

    public readonly IProductImageRepository 
        _productImageRepository;

    public readonly IAdminPostImageRepository       _adminPostsImageRepository;

    public readonly IPageRepository _pageRepository;


    public PagePanelQueryService ( 
        IProductImageRepository productImageRepository,
        IAdminPostImageRepository adminPostsImageRepository,
        IPageRepository pageRepository )
    {
        _productImageRepository = productImageRepository;
        _adminPostsImageRepository = adminPostsImageRepository;
        _pageRepository = pageRepository;
    }

    public async Task<List<PanelPostDataModel>> 
        GetSelectProducts ( EnumCompanyName company )
    {

        return await _productImageRepository
            .GetSelectProducts(company);
    }

    public async Task<PageDataModel> GetPanelList ( int pageID )
    {
        return await _pageRepository.GetSinglePage ( pageID );
    }
}

