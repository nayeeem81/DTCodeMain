using Main.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FineArtsWebApp;

[Area("AdminContent")]
[Authorize(Roles = "Admin")]
public class ManageAdminPostController : BaseController
{
    private readonly IAdminPostDataService _AdminPostDataService;

    private readonly IMemoryCache _cache;

    private readonly ILogger<ManageAdminPostController> _Logger;

    public ManageAdminPostController(IAdminPostDataService adminPostDataService,
        IMemoryCache cache, 
        ILogger<ManageAdminPostController> logger)
    {
        _AdminPostDataService = adminPostDataService;

        _cache = cache;

        _Logger = logger;
    }


    private void SetImageInViewModel(AdminPostViewModel objPostVm)
    {
        List<AdminImageFileViewModel> objFileList = new List<AdminImageFileViewModel>();

        objFileList = GetSessionNewAdminPostImage();

        objPostVm.ListAdminPostFileImages = objFileList;

        ClearNewAdminPostImageSessions();
    }


    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Index()
    {
        try
        {
            var listAdminPosts = await _AdminPostDataService.GetAllAdminPosts();

            var objManageAdminPostViewModel = new ManageAdminPostViewModel();

            objManageAdminPostViewModel.ListAdminPost = listAdminPosts;

            return View(objManageAdminPostViewModel);
        }
        catch
        {
            return View(new ManageAdminPostViewModel());
        }
    }


    [Authorize(Roles = "Admin")]
    public ViewResult NewAdminContent()
    {
        try
        {
            ClearNewAdminPostImageSessions();

            var objPostViewModel = new AdminPostViewModel();

            objPostViewModel.AV_PostType = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value != ((int)EnumPostType.Post).ToString() &&
                                                                                          pt.Value != ((int)EnumPostType.Product).ToString()).ToList();
            
            //objPostViewModel.PostTypeID = (int)EnumPostType.AdSpace;
            
            //objPostViewModel.EnumAdminPostTypeDescription = objPostViewModel.EnumAdminPostTypeDescription = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value == objPostViewModel.PostTypeID.ToString()).Select(pt => pt.Text).FirstOrDefault();
            
            objPostViewModel.PageName = "Add Admin Post";
            
            objPostViewModel.SetModelBase(GetModelBaseSession(EnumModelBase.Create));

            return View("~/Areas/AdminContent/Views/ManageAdminPost/NewAdmiinContent.cshtml", objPostViewModel);
        }
        catch
        {
            return View("~/Areas/AdminContent/Views/ManageAdminPost/NewAdmiinContent.cshtml", new AdminPostViewModel());
        }
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SaveNewAdminContent(AdminPostViewModel collection)
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

            var result = await _AdminPostDataService.SaveNewAdminPost(collection);

            string? urlGo = Url.Action("Index", "ManageAdminPost", new { Area = "AdminContent" });

            return Ok(new { success = result, urlGo = urlGo });
        } 
        catch (Exception ex)
        {
            throw ex;
            //return BadRequest(new { success = false, message = ex.InnerException.Source });
        }
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Edit(int id)
    {
        try
        {
            ClearNewAdminPostImageSessions();

            var objAdminPostViewModel = new AdminPostViewModel();

            objAdminPostViewModel = await _AdminPostDataService.GetAdminPostForEditPostID(id);

            objAdminPostViewModel.AV_PostType = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value != ((int)EnumPostType.Post).ToString() &&
                                                                                         pt.Value != ((int)EnumPostType.Product).ToString()).ToList();


            objAdminPostViewModel.EnumAdminPostTypeDescription = objAdminPostViewModel.EnumAdminPostTypeDescription = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value == objAdminPostViewModel.PostTypeID.ToString()).Select(pt => pt.Text).FirstOrDefault();
            
            objAdminPostViewModel.PageName = "Edit Admin Post";
            
            objAdminPostViewModel.SetModelBase(GetModelBaseSession(EnumModelBase.Create));

            return View(objAdminPostViewModel);
        }
        catch
        {
            return View(new AdminPostViewModel());
        }
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AdminPostViewModel collection)
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

            bool result = await _AdminPostDataService.UpdateAdminPost(collection);

            string? urlGo = Url.Action("Index", "ManageAdminPost", new { Area = "AdminContent" });

            return Ok(new { success = result, urlGo = urlGo });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }


    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Details(int id)
    {
        try
        {
            var objAdminPostViewModel = await _AdminPostDataService.GetAdminPostForEditPostID(id);

            objAdminPostViewModel.EnumAdminPostTypeDescription = DropDownSelectListItem.GetPostTypeList().Where(pt => pt.Value == objAdminPostViewModel.PostTypeID.ToString()).Select(pt => pt.Text).FirstOrDefault();

            objAdminPostViewModel.PageName = "Admin Post Details";

            return View(objAdminPostViewModel);
        }
        catch
        {
            return View(new AdminPostViewModel());
        }
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ImageUpload(IFormFile file)
    {
        try
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

                            var resut = stream.ReadAsync(imgByte);

                            AdminImageFileViewModel objFile = new AdminImageFileViewModel { ImageFileContent = imgByte };
                            
                            SetSessionNewAdminPostImage(objFile);
                        }
                    }
                }
            }

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { message = ex.Message });
        }
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public PartialViewResult ImageLoad()
    {
        try
        {
            var objImageList = GetSessionNewAdminPostImage();

            var objImage = objImageList.Last();

            return PartialView("~/Areas/AdminContent/Views/ManageAdminPost/_Image.cshtml", objImage);
        }
        catch
        {
            return PartialView("~/Areas/AdminContent/Views/ManageAdminPost/_Image.cshtml", new AdminImageFileViewModel());
        }
    }


    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<JsonResult> ImageRemove(int id, int postId)
    {
        try
        {
            bool result = await _AdminPostDataService.DeleteAdminPostImage(id, postId);

            if (!result)
            {
                RemoveSessionNewAdminPostImage(id);
            }

            return Json(new { success = true });
        }
        catch
        {
            return Json(new { errors = false });
        }
    }


    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var objAdminPostViewModel = await _AdminPostDataService.GetAdminPostForEditPostID(id);

            return View(objAdminPostViewModel);
        }
        catch
        {
            return View(new AdminPostViewModel());
        }
    }


    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteAdminPost(int id, int fakeId)
    {
        AdminPostViewModel objAdminPostViewModel;

        try
        {
            var result = await _AdminPostDataService.DeleteAdminPost(id);

            if (result)
            {
                return RedirectToAction("Index");
            }  
            else
            {
                objAdminPostViewModel = await _AdminPostDataService.GetAdminPostForEditPostID(id);

                return View(objAdminPostViewModel);
            }
        }
        catch
        {
            return View(new AdminPostViewModel());
        }
    }
}

