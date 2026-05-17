using BusinessModel;
using Main.Common;

namespace IService;

public interface IProductDataService
{
    Task<List<ProductDataModel>> GetAllProducts();

    Task<bool> SaveNewProduct(ProductDataModel objPostVm);

    Task<ProductDataModel> GetProductForEditProductID(int productID);

    Task<bool> UpdateProduct(ProductDataModel objPostVm);

    Task<bool> DeleteProductImage(int id, int productId);

    Task<bool> DeleteProduct(int productId);
}

