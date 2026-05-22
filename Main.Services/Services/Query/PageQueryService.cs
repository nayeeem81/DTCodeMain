using BusinessModel;
using IServices;
using IRepository;
using Main.Common.Enums;

namespace Services.Query;

public class PageQueryService: IQueryPageService
{

    public readonly IPageRepository _pageRepository;

    public PageQueryService ( IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<List<PageDataModel>> GetAllPages ( EnumCompanyName company ) => 
                await _pageRepository
                        .GetAllPages ( company );
                   
}

