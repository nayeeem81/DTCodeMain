using BusinessModel;

namespace IServices;

public interface IQueryProductService
{
    Task<List<ProductDataModel>> GetAllProducts();

    Task<ProductDataModel> GetProductForEditProductID(int productID);
}

