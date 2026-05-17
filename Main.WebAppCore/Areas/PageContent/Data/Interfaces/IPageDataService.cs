using Common;

namespace FineArtsWebApp
{
    public interface IPageDataService
    {
        Task<List<PageViewModel>> GetAllPages(EnumCompanyName company);
    }
}
