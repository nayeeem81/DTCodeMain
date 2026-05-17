using Common;
using Data;
using Model;

namespace FineArtsWebApp
{
    public class ProductDataService : IProductDataService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductMappingService _ProductMappingService;

        public ProductDataService(IProductRepository productRepository, IProductMappingService productMappingService)
        {
            _ProductRepository = productRepository;
            _ProductMappingService = productMappingService;
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var listProducts = await _ProductRepository.GetAllProducts();
            List<ProductViewModel> objListPostVM = new List<ProductViewModel>();
            ProductViewModel objModel;
            foreach (Product item in listProducts.ToList())
            {
                objModel = new ProductViewModel();
                
                _ProductMappingService.MapProductEntityToProductViewModelListModel(item, objModel);

                objModel.CategoryText = objModel.GetTextCategory();
                objModel.SubCategoryText = objModel.GetTextSubCategory();

                objListPostVM.Add(objModel);
            }
            return objListPostVM;
        }

        public async Task<bool> SaveNewProduct(ProductViewModel objPostVm)
        {
            Product objProductEntity = _ProductMappingService.MapProductViweModelToProductEntity(objPostVm);

            objProductEntity.CreateBaseData(objPostVm.ModelBase);

            objProductEntity.UserID = objPostVm.UserID.Value;
            objProductEntity.User = null;

            List <ProductImageFile> objListFileEntity = _ProductMappingService.MapProductViweModelToProductFileEntity(objPostVm);

            var result = await _ProductRepository.SaveNewProduct(objProductEntity, objListFileEntity);

            return result;
        }


        public async Task<ProductViewModel> GetProductForEditProductID(int productID)
        {
            var productEntity = await _ProductRepository.GetProductByProductID(productID);

            List<ProductFileViewModel> objListFiles = new List<ProductFileViewModel>();

            if (productEntity.ListImageFiles != null && productEntity.ListImageFiles.Count > 0)
            {
                productEntity.ListImageFiles.ToList().ForEach(fileEntity =>
                {
                    ProductFileViewModel objFileVM = new ProductFileViewModel()
                    {
                        ProductImageFileID = fileEntity.ProductImageFileID,
                        ImageFileContent = fileEntity.ImageFileContent,
                        ProductID = fileEntity.ProductID
                    };
                    objListFiles.Add(objFileVM);
                });
            }


            List<ProductCommentViewModel> objListComments = new List<ProductCommentViewModel>();

            if (productEntity.ListComments != null && productEntity.ListComments.Count > 0)
            {
                productEntity.ListComments.ToList().ForEach(commentEntity =>
                {
                    ProductCommentViewModel objCommentVM = new ProductCommentViewModel()
                    {
                        ProductCommentID = commentEntity.ProductCommentID,
                        Comment = commentEntity.Comment,
                        ProductID = commentEntity.ProductID 
                    };
                    objListComments.Add(objCommentVM);
                });
            }

            ProductViewModel objModel = new ProductViewModel()
            {
                ProductID = productEntity.ProductID,
                ProductName = productEntity.ProductName,
                Discount = productEntity.Discount,
                SaleCommission = productEntity.SaleCommission,
                SearchTag = productEntity.SearchTag,
                PostType = (EnumPostType)productEntity.PostType,
                Description = productEntity.Description,
                CategoryID = productEntity.CategoryID,
                SubCategoryID = productEntity.SubCategoryID,
                UnitPrice = productEntity.Price,
                UserID = productEntity.UserID,
                ListComments = objListComments,
                ImageFiles = objListFiles
            };

            objModel.CategoryText = objModel.GetTextCategory();
            objModel.SubCategoryText = objModel.GetTextSubCategory();

            return objModel;
        }

        public async Task<bool> UpdateProduct(ProductViewModel objPostVm)
        {
            var product = await _ProductRepository.GetProductByProductID(objPostVm.ProductID);

            product.ModifyBaseData(objPostVm.ModelBase);

            product.UserID = objPostVm.UserID.Value;
            product.User = null;

            
            List<ProductImageFile> images = new List<ProductImageFile>();

            images.AddRange(product.ListImageFiles);    
            
            objPostVm.ImageFiles.ForEach(fileVM =>
            {
                var objFile = new ProductImageFile(fileVM.ImageFileContent);
                objFile.ProductID = product.ProductID;
                images.Add(objFile);
            });


            
            List<ProductComment> comments = new List<ProductComment>();

            comments.AddRange(product.ListComments);

            objPostVm.ListComments.ForEach(commentVM =>
            {
                var objComment = new ProductComment();
                objComment.ProductID = product.ProductID;
                objComment.Comment = commentVM.Comment;
                comments.Add(objComment);
            });

            product.ProductName = objPostVm.ProductName;
            product.Discount = objPostVm.Discount;
            product.SaleCommission = objPostVm.SaleCommission;
            product.SearchTag = objPostVm.SearchTag;
            product.PostType = EnumPostType.Product;
            product.Description = objPostVm.Description;
            product.CategoryID = objPostVm.CategoryID;
            product.SubCategoryID = objPostVm.SubCategoryID;
            product.Price = objPostVm.UnitPrice; 
            product.ListComments = comments;
            product.ListImageFiles = images;

            var result = await _ProductRepository.SaveChanges();
            return result;
        }

        public async Task<bool> DeleteProductImage(int id, int postId)
        {
            return await _ProductRepository.DeleteProductImage(id, postId);
        }

        public async Task<bool> DeleteProduct(int postId)
        {
            var resultDelete = await _ProductRepository.DeleteProduct(postId);
            return resultDelete;
        }
    }
}
