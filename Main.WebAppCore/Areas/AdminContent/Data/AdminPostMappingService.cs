using BusinessModel;
using Main.Common.Enums;

namespace FineArtsWebApp
{
    public class AdminPostMappingService : IAdminPostMappingService
    {
        public AdminPostMappingService() { }

        public AdminPostDataModel MapAdminPostViewModelToAdminPostEntity (AdminPostViewModel objAdminPostVM)
        {
            return new AdminPostDataModel()
            {
                PosterName = objAdminPostVM.PosterName,
                PostTitle = objAdminPostVM.PostTitle,
                PostTypeID = objAdminPostVM.PostTypeID,
                WebsiteUrl = objAdminPostVM.WebsiteUrl,
                SearchTag = objAdminPostVM.SearchTag,
                ShortNote = objAdminPostVM.ShortNote,
                ListAdminPostFileImages = new List<AdminImageFileDataModel>(),
                ListAdminPostComments = new List<AdminPostCommentDataModel>(),
                PosterContactNumber = objAdminPostVM.PosterContactNumber 
            };
        }

        public List<AdminImageFileDataModel> MapAdmiFileViweModelToAdminFileEntity(AdminPostViewModel adminFileVM)
        {
            List<AdminImageFileDataModel> objListFileDM = new List<AdminImageFileDataModel>();
            adminFileVM.ListAdminPostFileImages.ForEach(fileVM =>
            {
                objListFileDM.Add(new AdminImageFileDataModel ( fileVM.ImageFileContent));
            });
            return objListFileDM;
        }

        public void MapAdminPostDataModelToAdminPostViewModelListModel(AdminPostDataModel postDM, AdminPostViewModel postViewModel)
        {
            postViewModel.AdminPostID = postDM.AdminPostID;
            postViewModel.PostTitle = postDM.PostTitle;
            postViewModel.PosterContactNumber = postDM.PosterContactNumber;
            postViewModel.PosterName = postDM.PosterName;
            postViewModel.WebsiteUrl = postDM.WebsiteUrl;
            postViewModel.PostTypeID = postDM.PostTypeID;
            postViewModel.SearchTag = postDM.SearchTag;
            postViewModel.ShortNote = postDM.ShortNote;
            postViewModel.EnumAdminPostTypeDescription = EnumDescription.GetDescription((EnumPostType) postDM.PostTypeID);
        }
    }
}
