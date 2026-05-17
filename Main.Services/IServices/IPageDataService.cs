using BusinessModel;
using Main.Common;
using Main.Common.Enum;

namespace IService;

public interface IPageDataService
{
    Task<List<PageDataModel>> GetAllPages(EnumCompanyName company);
}

