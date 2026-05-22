using BusinessModel;
using Main.Common.Enums;

namespace IServices;

public interface IQueryPageService
{
    Task<List<PageDataModel>> GetAllPages(EnumCompanyName company);
}

