using Common;
using Model;

namespace FineArtsWebApp
{
    public interface IProductMappingService
    {
        Product MapProductViweModelToProductEntity(ProductViewModel productVM);

        void MapProductEntityToProductViewModelListModel(Product postEntity, ProductViewModel productViewModel);

        List<ProductImageFile> MapProductViweModelToProductFileEntity(ProductViewModel productFileVM);
    }
}
