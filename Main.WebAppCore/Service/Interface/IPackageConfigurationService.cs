using Model;

namespace FineArtsWebApp
{
    public interface IPackageConfigurationService
    {
        Task<PackageConfig> GetDefaultStartupPackage();

        Task<List<PackageConfig>> GetAllActivePackages();

        Task<PackageConfig> GetSinglePackage(int packageId);
    }
}
