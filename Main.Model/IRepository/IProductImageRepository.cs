using Main.Common.Enum;
using Entity.Model;

namespace IRepository;

public interface IProductImageRepository
{
    Task<List<Product>> GetSelectProducts(EnumCompanyName company);
}
