
using Main.Common;
using Main.Model;
namespace IRepository;

public interface IProductImageRepository
{
    Task<List<Product>> GetSelectProducts(EnumCompanyName company);
}
