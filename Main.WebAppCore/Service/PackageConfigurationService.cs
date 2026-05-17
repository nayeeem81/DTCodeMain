using Data;
using Model;

namespace FineArtsWebApp
{
    public class PackageConfigurationService : IPackageConfigurationService
    {
        private readonly IPackageConfigRepository _PackageConfigRepository;
        private readonly IPostRepository _PostRepository;
        private readonly IAccountBillRepository _AccountBillRepository;
        private readonly IRepoDropDownDataList _DropDownDataList;

        public PackageConfigurationService(
            IPackageConfigRepository packageConfigRepository,
            IPostRepository postRepository,
            IAccountBillRepository accountBillRepository,
            IRepoDropDownDataList dropDownDataList)
        {
            _PackageConfigRepository = packageConfigRepository;
            _PostRepository = postRepository;
            _AccountBillRepository = accountBillRepository;
            _DropDownDataList = dropDownDataList;
        }

        public async Task<PackageConfig> GetDefaultStartupPackage()
        {
            return await _PackageConfigRepository.GetDefaultPackage();
        }

        public async Task<List<PackageConfig>> GetAllActivePackages()
        {
            var listPackages = await _PackageConfigRepository.GetAllActivePackages();
            return listPackages;
        }

        public async Task<PackageConfig> GetSinglePackage(int packageId)
        {
            return await _PackageConfigRepository.GetSinglePackage(packageId);
        }
    }
}
