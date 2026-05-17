using Main.Common.Enums;
using Entity.Model;

namespace IRepository;

public interface IProductImageRepository
{
    Task<List<Product>> GetSelectProducts(EnumCompanyName company);
}
