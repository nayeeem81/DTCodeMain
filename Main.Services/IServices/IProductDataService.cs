using BusinessModel;

namespace IService;

public interface IProductDataService
{
    Task<List<ProductDataModel>> GetAllProducts();

    Task<bool> SaveNewProduct(ProductDataModel objPostDm );

    Task<ProductDataModel> GetProductForEditProductID(int productID);

    Task<bool> UpdateProduct(ProductDataModel objPostDm );

    Task<bool> DeleteProductImage(int id, int productId);

    Task<bool> DeleteProduct(int productId);
}

