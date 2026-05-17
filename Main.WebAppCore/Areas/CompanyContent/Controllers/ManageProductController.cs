using Common;
using dotless.Core.Parser.Tree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace FineArtsWebApp
{
    [Area("CompanyContent")]
    [Authorize(Roles = "Company")]
    public class ManageProductController : BaseController
    {

        private readonly IProductDataService _ProductDataService;
        private readonly IMemoryCache _MemoryCache;
        private readonly ILogger<ManageProductController> _Logger;  

        public ManageProductController(IProductDataService productDataService, IMemoryCache memoryCache, ILogger<ManageProductController> logger)
        {
            _ProductDataService = productDataService;

            _MemoryCache = memoryCache;

            _Logger = logger;
        }


        [Authorize(Roles = "Company")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var listProducts = await _ProductDataService.GetAllProducts();

                var objManageProductViewModel = new ManageProductViewModel();

                objManageProductViewModel.ListProduct = listProducts;

                return View(objManageProductViewModel);
            }
            catch
            {
                return View(new ManageProductViewModel());
            }
        }


        private void SetImageInViewModel(ProductViewModel objProductVM)
        {
            List<ProductFileViewModel> objFileList = new List<ProductFileViewModel>();

            objFileList = GetSessionNewProductImage();

            objProductVM.ImageFiles = objFileList;

            ClearNewProductImageSessions();
        }


        [Authorize(Roles = "Company")]
        public ViewResult NewProduct()
        {
            try
            {
                ClearNewProductImageSessions();

                ProductViewModel objProductViewModel = new ProductViewModel();

                objProductViewModel.PageName = "New Product";

                objProductViewModel.AV_PostType = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value != ((int)EnumPostType.Post).ToString() &&
                                                                                              pt.Value != ((int)EnumPostType.Product).ToString()).ToList();
                
                objProductViewModel.PostType = EnumPostType.AdSpace;
                
                objProductViewModel.SetModelBase(GetModelBaseSession(EnumModelBase.Create));
                
                return View("~/Areas/CompanyContent/Views/ManageProduct/NewProduct.cshtml", objProductViewModel);
            }
            catch
            {
                return View("~/Areas/CompanyContent/Views/ManageProduct/NewProduct.cshtml", new ProductViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> SaveProduct(ProductViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                SetImageInViewModel(collection);

                collection.SetModelBase(GetModelBaseSession(EnumModelBase.Create));

                collection.UserID = GetSessionUserId();

                collection.PostType = EnumPostType.Product;

                bool result = await _ProductDataService.SaveNewProduct(collection);

                string? urlGo = Url.Action("Index", "ManageProduct", new { Area = "CompanyContent" });

                return Ok( new { success = result, urlGo = urlGo } );
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult> Edit(int id)
        {
            try 
            {
                ClearNewAdminPostImageSessions();

                var objProductViewModel = new ProductViewModel();

                objProductViewModel = await _ProductDataService.GetProductForEditProductID(id);

                objProductViewModel.PageName = "Edit Product Content";
                
                objProductViewModel.SetModelBase(GetModelBaseSession(EnumModelBase.Create));

                return View(objProductViewModel);
            }
            catch 
            {
                return View(new ProductViewModel());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Edit(ProductViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try 
            {
                SetImageInViewModel(collection);

                collection.SetModelBase(GetModelBaseSession(EnumModelBase.Update));

                collection.UserID = GetSessionUserId();

                collection.PostType = EnumPostType.Product;

                var result = await _ProductDataService.UpdateProduct(collection);

                string? urlGo = Url.Action("Index", "ManageProduct", new { Area = "CompanyContent" });

                return Ok(new { success = true, urlGo = urlGo });

                
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [Authorize(Roles = "Company")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var objProductViewModel = await _ProductDataService.GetProductForEditProductID(id);

                objProductViewModel.PageName = "Product Content Details";

                return View(objProductViewModel);
            }
            catch
            {
                return View(new ProductViewModel());
            }
        }


        [HttpPost]
        [Authorize(Roles = "Company")]
        public JsonResult UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (file.Length > StaticAppSettings.POST_IMAGE_SIZE)
                {
                    return Json(new { success = false });
                }
                else
                {
                    if (!string.IsNullOrEmpty(file.ContentType) && file.FileName != null)
                    {
                        string extension = Path.GetExtension(file.FileName).ToLower();

                        if (extension.Equals(".jpg") || extension.Equals(".jpeg")

                            || extension.Equals(".png") || extension.Equals(".gif"))
                        {
                            var imgByte = new Byte[file.Length];

                            var stream = file.OpenReadStream();

                            var result = stream.Read(imgByte);

                            ProductFileViewModel objFile = new ProductFileViewModel
                            {
                                ImageFileContent = imgByte
                            };

                            SetSessionNewProductImage(objFile);
                        }
                    }

                    return Json(new { success = true });
                }
            }

            return Json(new { success = true });
        }
       

        [HttpGet]
        [Authorize(Roles = "Company")]
        public PartialViewResult LoadImage()
        {
            try
            {
                var objImageList = GetSessionNewProductImage();

                var objImage = objImageList.Last();

                return PartialView("~/Areas/CompanyContent/Views/ManageProduct/_Image.cshtml", objImage);
            }
            catch
            {
                return PartialView("~/Areas/CompanyContent/Views/ManageProduct/_Image.cshtml", new ProductFileViewModel());
            }
        }

   
        [HttpDelete]
        [Authorize(Roles = "Company")]
        public async Task<JsonResult> ImageRemove(int id, int postId)
        {
            try
            {
                bool result = await _ProductDataService.DeleteProductImage(id, postId);

                if (!result)
                {
                    RemoveSessionNewProductImage(id);
                }

                return Json(new { success = true });
            }
            catch
            {
                return Json(new { errors = false });
            }
        }

    
        [HttpGet]
        [Authorize(Roles = "Company")]
        public JsonResult GetSubCategories(long id)
        {
            try
            {
                var listSubCategories = DropDownSelectListItem.GetSubCategoryList(id, StaticAppSettings.CategoryFor);
                
                return Json(listSubCategories);
            }
            catch
            {
                return Json(new List<SelectListItem>());
            }
        }


        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var objProductViewModel = await _ProductDataService.GetProductForEditProductID(id);

                return View(objProductViewModel);
            }
            catch
            {
                return View(new ProductViewModel());
            }
        }


        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult> DeleteProduct(int id, int fakeId)
        {
            try
            {
                var result = await _ProductDataService.DeleteProduct(id);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var objProductViewModel = await _ProductDataService.GetProductForEditProductID(id);
                    
                    return View(objProductViewModel);
                }
            }
            catch
            {
                return View(new ProductViewModel());
            }
        }
    }
}