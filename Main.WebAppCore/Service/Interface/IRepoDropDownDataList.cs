using Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FineArtsWebApp
{
    public interface IRepoDropDownDataList
    {
        Task<string> GetPackageNameText(int packageId);

        Task<IEnumerable<SelectListItem>> GetPackageList();

        Task<List<AValueModel>> GetAllPackages();

        Task<IEnumerable<SelectListItem>> GetUsersList();

        Task<List<AValueModel>> GetAllUsers();

        Task<IEnumerable<SelectListItem>> GetFabiaServiceCategoryList();
    }
}