using Common;
using System.Text.Json;
namespace FineArtsWebApp
{
    public partial class BaseController
    {
        protected void SetSessionRechargeSubCategoryID(int? subCategoryID)
        {
            HttpContext.Session.SetInt32("SubCategoryID", subCategoryID.HasValue ? subCategoryID.Value : -1);
        }
        protected int GetSessionRechargeSubCategoryID()

        {
            var SubCatID = HttpContext.Session.GetInt32("SubCategoryID");
            return SubCatID.HasValue ? SubCatID.Value : -1;
        }

        protected void ClearSessionRechargeSubCategoryID()
        {
            HttpContext.Session.Remove("SubCategoryID");
        }

        protected void ClearShoppingCartSession()
        {
            HttpContext.Session.Remove("UserOrderID");
            HttpContext.Session.Remove("PackageShoppingCart");
        }

        protected void SetUserOrderID(int? id)
        {
            HttpContext.Session.SetInt32("UserOrderID", id.HasValue ? id.Value : -1);
        }

        protected int? GetUserOrderID()
        {
            var UserOrderID = HttpContext.Session.GetInt32("UserOrderID");
            return UserOrderID.HasValue ? UserOrderID.Value : -1;
        }

        protected int? GetProductUserOrderID()
        {
            var ProductUserOrderID = HttpContext.Session.GetInt32("ProductUserOrderID");
            return ProductUserOrderID.HasValue ? ProductUserOrderID.Value : -1;
        }

        protected void SetPackageShoppingCart(List<ShoppingCartViewModel> cartItems)
        {
            SessionExtensions.SetObject<List<ShoppingCartViewModel>>(HttpContext.Session, "PackageShoppingCart", cartItems);
        }

        protected List<ShoppingCartViewModel> GetPackageShoppingCart()
        {
            var objList = SessionExtensions.GetObject<List<ShoppingCartViewModel>>(HttpContext.Session, "PackageShoppingCart");
            if (objList == null)
                return new List<ShoppingCartViewModel>();
            return objList;
        }

        protected void SetProductShoppingCart(List<CartSingleItemViewModel> cartItems)
        {
            SessionExtensions.SetObject<List<CartSingleItemViewModel>>(HttpContext.Session, "ProductShoppingCart", cartItems);
        }

        protected List<CartSingleItemViewModel> GetProductShoppingCart()
        {
            var objList = SessionExtensions.GetObject<List<CartSingleItemViewModel>>(HttpContext.Session, "ProductShoppingCart");
            if (objList == null)
                return new List<CartSingleItemViewModel>();
            return objList;
        }

        protected void SetBrowserId(Int32 browserId)
        {
            HttpContext.Session.SetInt32("Browser", browserId);
        }

        protected Int32 GetBrowserId()
        {
            Int32? BroweserID = HttpContext.Session.GetInt32("Browser");
            return BroweserID.HasValue ? BroweserID.Value : -1;
        }

        #region user
        protected void SetSessionUser(UserModel userModel)
        {
            SessionExtensions.SetObject<UserModel>(HttpContext.Session, "User", userModel);
        }

        protected UserModel GetSessionUser()
        {
            var User = SessionExtensions.GetObject<UserModel>(HttpContext.Session, "User");
            if (User != null)
                return User;

            return new UserModel();
        }

        protected int GetSessionUserId()
        {
            var User = GetSessionUser();
            if (User != null)
                return User.UserID;

            return -1;
        }

        protected void ClearSessionUser()
        {
            HttpContext.Session.Remove("User");
        }
        #endregion

        #region search model
        protected void SetSessionSearchModel(SearchModel searchModel)
        {
            SessionExtensions.SetObject<SearchModel>(HttpContext.Session, "search", searchModel);
        }

        protected SearchModel GetSessionSearchModel()
        {
            var objSessionSearchModel = SessionExtensions.GetObject<SearchModel>(HttpContext.Session, "search");
            if (objSessionSearchModel != null)
                return (SearchModel)objSessionSearchModel;
            return null;
        }

        protected void ClearSessionSearchModel()
        {
            HttpContext.Session.Remove("search");
        }

        #endregion

        #region New Post Image Session
        protected void SetSessionNewPostImage(FileViewModel file)
        {
            var list = SessionExtensions.GetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList");
            if (list != null)
            {
                file.IsNewItem = true;
                list.Add(file);
                SessionExtensions.SetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList", list);
            }
            else
            {
                List<FileViewModel> objListFiles = new List<FileViewModel>();
                file.IsNewItem = true;
                objListFiles.Add(file);
                SessionExtensions.SetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList", objListFiles);
            }
        }

        protected List<FileViewModel> GetSessionNewPostImage()
        {
            var list = SessionExtensions.GetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList");
            if (list != null)
            {
                return list.ToList();
            }
            else
            {
                return new List<FileViewModel>();
            }
        }

        protected bool RemoveSessionNewPostImage(long id)
        {
            var list = SessionExtensions.GetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList");
            if (list != null)
            {
                var obj = list.Where(a => a.FileID == id).FirstOrDefault();
                if (obj != null)
                {
                    list.Remove(obj);
                    SessionExtensions.SetObject<List<FileViewModel>>(HttpContext.Session, "NewPostImageList", list);
                    return true;
                }
            }
            return false;
        }

        protected void ClearNewPostImageSessions()
        {
            HttpContext.Session.Remove("NewPostImageList");
        }

        protected void SetSessionNewPostImage1(FileViewModel file)
        {
            SessionExtensions.SetObject<FileViewModel>(HttpContext.Session, "ImgByte1", file);
        }

        protected FileViewModel GetSessionNewPostImage1()
        {
            var ImgByte1 = SessionExtensions.GetObject<FileViewModel>(HttpContext.Session, "ImgByte1");
            if (ImgByte1 != null)
                return (FileViewModel)ImgByte1;
            return null;
        }

        protected void SetSessionNewPostImage2(FileViewModel file)
        {
            SessionExtensions.SetObject<FileViewModel>(HttpContext.Session, "ImgByte2", file);
        }

        protected FileViewModel GetSessionNewPostImage2()
        {
            var ImgByte2 = SessionExtensions.GetObject<FileViewModel>(HttpContext.Session, "ImgByte2");
            if (ImgByte2 != null)
                return (FileViewModel)ImgByte2;
            return null;
        }

        protected void SetSessionNewPostImage3(FileViewModel file)
        {
            SessionExtensions.SetObject<FileViewModel>(HttpContext.Session, "ImgByte3", file);
        }

        protected FileViewModel GetSessionNewPostImage3()
        {
            var ImgByte3 = SessionExtensions.GetObject<FileViewModel>(HttpContext.Session, "ImgByte3");
            if (ImgByte3 != null)
                return (FileViewModel)ImgByte3;
            return null;
        }

        protected void SetSessionNewPostImage4(FileViewModel file)
        {
            SessionExtensions.SetObject<FileViewModel>(HttpContext.Session, "ImgByte4", file);
        }

        protected FileViewModel GetSessionNewPostImage4()
        {
            var ImgByte4 = SessionExtensions.GetObject<FileViewModel>(HttpContext.Session, "ImgByte4");
            if (ImgByte4 != null)
                return (FileViewModel)ImgByte4;
            return null;
        }

        #endregion

        #region manage post images
        protected void SetManagePostImageSession(long postId, long serialNo, FileViewModel file)
        {
            SessionExtensions.SetObject<FileViewModel>(HttpContext.Session, postId + "Img" + serialNo, file);
        }

        protected FileViewModel GetManagePostImageSession(long postId, long serialNo)
        {
            var ImgPostIDSerialNO = SessionExtensions.GetObject<FileViewModel>(HttpContext.Session, postId + "Img" + serialNo);
            if (ImgPostIDSerialNO != null)
                return (FileViewModel)ImgPostIDSerialNO;
            else
                return null;
        }

        protected void ClearManagePostImageSession(long postId)
        {
            HttpContext.Session.Remove(postId + "Img1");
            HttpContext.Session.Remove(postId + "Img2");
            HttpContext.Session.Remove(postId + "Img3");
            HttpContext.Session.Remove(postId + "Img4");
        }
        #endregion

        #region Image Session for Fabia Images
        protected void SetProcessImageSession(byte[] file)
        {
            HttpContext.Session.Set("ProcessImage", file);
        }

        protected void SetServiceImageSession(byte[] file)
        {
            HttpContext.Session.Set("ServiceImage", file);
        }

        protected byte[] GetProcessImageSession()
        {
            var objSession = HttpContext.Session.Get("ProcessImage");

            if (objSession != null)
                return (byte[])objSession;
            return null;
        }

        protected byte[] GetServiceImageSession()
        {
            var objSession = HttpContext.Session.Get("ServiceImage");
            if (objSession != null)
                return (byte[])objSession;
            return null;
        }

        protected void ClearProcessImageSession()
        {
            HttpContext.Session.Remove("ProcessImage");
        }

        protected void ClearServiceImageSession()
        {
            HttpContext.Session.Remove("ServiceImage");
        }
        #endregion

        #region Sarcch Image Session
        protected void SetSearchResultListPostVM(List<PostViewModel> listPostVM)
        {
            SessionExtensions.SetObject<List<PostViewModel>>(HttpContext.Session, "SearchResultListPostVM", listPostVM);
        }

        protected List<PostViewModel> GetSearchResultListPostVM()
        {
            var result = SessionExtensions.GetObject<List<PostViewModel>>(HttpContext.Session, "SearchResultListPostVM");

            if (result != null)
            {
                return (List<PostViewModel>)result;
            }
            return new List<PostViewModel>();
        }

        protected void ClearSearchResultListPostVM()
        {
            HttpContext.Session.Remove("SearchResultListPostVM");
        }

        protected void SetSearchPostViewModel(PostViewModel searchModel)
        {
            SessionExtensions.SetObject<PostViewModel>(HttpContext.Session, "searchpostvm", searchModel);
        }

        protected PostViewModel GetSearchPostViewModel()
        {
            var objSearchPostViewModel = SessionExtensions.GetObject<PostViewModel>(HttpContext.Session, "searchpostvm");

            if (objSearchPostViewModel != null)
                return (PostViewModel)objSearchPostViewModel;
            return null;
        }

        protected void ClearSearchPostViewModel()
        {
            HttpContext.Session.Remove("searchpostvm");
        }
        #endregion

        #region Fabia Provider Service Image Session 
        protected void ClearProviderProfileImageSession()
        {
            HttpContext.Session.Remove("providerprofileimage");
        }

        protected void SetProviderProfileImageSession(byte[] image)
        {
            HttpContext.Session.Set("providerprofileimage", image);
        }

        protected byte[] GetProviderProfileImageSession()
        {
            var image = HttpContext.Session.Get("providerprofileimage");

            if (image != null)
                return (byte[])image;
            return null;
        }

        protected void ClearProviderServiceImageSession()
        {
            HttpContext.Session.Remove("providerserviceimage");
        }

        protected void SetProviderServiceImageSession(byte[] image)
        {
            HttpContext.Session.Set("providerserviceimage", image);
        }

        protected byte[] GetProviderServiceImageSession()
        {
            var image = HttpContext.Session.Get("providerserviceimage");
            if (image != null)
                return (byte[])image;
            return null;
        }

        protected FabiaProviderViewModel GetNewProviderSession()
        {
            var obj = SessionExtensions.GetObject<FabiaProviderViewModel>(HttpContext.Session, "newprovider");
            if (obj != null)
                return (FabiaProviderViewModel)obj;
            return null;
        }

        protected void SetNewProviderSession(FabiaProviderViewModel objProviderVM)
        {
            SessionExtensions.SetObject<FabiaProviderViewModel>(HttpContext.Session, "newprovider", objProviderVM);
        }
        #endregion

        #region Product Image Session
        protected void SetSessionNewProductImage(ProductFileViewModel file)
        {
            var list = SessionExtensions.GetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList");
            if (list != null)
            {
                int count = list.Count;
                count = count + 1;
                file.ProductImageFileID = count;

                list.Add(file);
                SessionExtensions.SetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList", list);
            }
            else
            {
                file.ProductImageFileID = 1;
                List<ProductFileViewModel> objListFiles = new List<ProductFileViewModel>();
                objListFiles.Add(file);
                SessionExtensions.SetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList", objListFiles);
            }
        }

        protected List<ProductFileViewModel> GetSessionNewProductImage()
        {
            var list = SessionExtensions.GetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList");
            if (list != null)
            {
                return list.ToList();
            }
            else
            {
                return new List<ProductFileViewModel>();
            }
        }

        protected bool RemoveSessionNewProductImage(int id)
        {
            var list = SessionExtensions.GetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList");
            if (list != null)
            {
                var obj = list.Where(a => a.ProductImageFileID == id).FirstOrDefault();
                if (obj != null)
                {
                    list.Remove(obj);
                    SessionExtensions.SetObject<List<ProductFileViewModel>>(HttpContext.Session, "NewProductImageList", list);
                    return true;
                }
            }
            return false;
        }

        protected void ClearNewProductImageSessions()
        {
            HttpContext.Session.Remove("NewProductImageList");
        }

        #endregion

        #region Admin Post Image Session
        protected void SetSessionNewAdminPostImage(AdminImageFileViewModel file)
        {
            var list = SessionExtensions.GetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList");
            if (list != null)
            {
                int count = list.Count;
                count = count + 1;
                file.AdminImageFileID = count;
                list.Add(file);
                SessionExtensions.SetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList", list);
            }
            else
            {
                file.AdminImageFileID = 1;
                List<AdminImageFileViewModel> objListFiles = new List<AdminImageFileViewModel>();
                objListFiles.Add(file);
                SessionExtensions.SetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList", objListFiles);
            }
        }

        protected List<AdminImageFileViewModel> GetSessionNewAdminPostImage()
        {
            var list = SessionExtensions.GetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList");
            if (list != null)
            {
                return list.ToList();
            }
            else
            {
                return new List<AdminImageFileViewModel>();
            }
        }

        protected bool RemoveSessionNewAdminPostImage(long id)
        {
            var list = SessionExtensions.GetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList");
            if (list != null)
            {
                var obj = list.Where(a => a.AdminImageFileID == id).FirstOrDefault();
                if (obj != null)
                {
                    list.Remove(obj);
                    SessionExtensions.SetObject<List<AdminImageFileViewModel>>(HttpContext.Session, "NewAdminPostImageList", list);
                    return true;
                }
            }
            return false;
        }

        protected void ClearNewAdminPostImageSessions()
        {
            HttpContext.Session.Remove("NewAdminPostImageList");
        }
        #endregion

        #region Base Model Session
        protected void SetModelBaseSession(ModelBase modelBaseCreate, ModelBase modelBaseUpdate)
        {
            SessionExtensions.SetObject<ModelBase>(HttpContext.Session, "CreateModelBase", modelBaseCreate);
            SessionExtensions.SetObject<ModelBase>(HttpContext.Session, "UpdateModelBase", modelBaseUpdate);
        }

        protected ModelBase GetModelBaseSession(EnumModelBase baseFor)
        {
            ModelBase modelBase = new ModelBase();

            if(baseFor == EnumModelBase.Create) 
            {
                modelBase = SessionExtensions.GetObject<ModelBase>(HttpContext.Session, "CreateModelBase");
            }
            else if(baseFor == EnumModelBase.Update)
            {
                modelBase = SessionExtensions.GetObject<ModelBase>(HttpContext.Session, "UpdateModelBase");
            }
            
            return modelBase;
        }

        protected void ClearModelBaseSession()
        {
            HttpContext.Session.Remove("CreateModelBase");
            HttpContext.Session.Remove("UpdateModelBase");
        }

        #endregion

    }


    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

}
