using Common;
using Data;

using Model;

namespace FineArtsWebApp
{
    public class GroupPostMappingService : IGroupPanelPostMappingService
    {
        private readonly IAValueRepository _AValueRepo;
        //private readonly HashingCryptographyService _HashingService;

        public GroupPostMappingService(
            IAValueRepository aValueRepo
            )
        {
            _AValueRepo = aValueRepo;
            // _HashingService = new HashingCryptographyService();
        }

        public PostViewModel LoadAValues(PostViewModel postViewModel)
        {
            postViewModel.AV_State = DropDownSelectListItem.GetAllStateList();
            postViewModel.AV_Category = DropDownSelectListItem.GetCategoryList(StaticAppSettings.CategoryFor);
            postViewModel.AV_SubCategory = DropDownSelectListItem.GetSubCategoryList(StaticAppSettings.CategoryFor);
            return postViewModel;
        }

        public void MapGroupPanelPostEntityToPostViewModelForEdit(GroupPanelPost groupPostEntity, PostViewModel postViewModel)
        {
            postViewModel.PostID = groupPostEntity.Post.PostID;
          //  postViewModel.CreatedDate = groupPostEntity.Post.CreatedDate;
            postViewModel.Title = groupPostEntity.Post.Title;
            postViewModel.CategoryID = groupPostEntity.Post.CategoryID.HasValue ? groupPostEntity.Post.CategoryID.Value : 0;
            postViewModel.SubCategoryID = groupPostEntity.Post.SubCategoryID.HasValue ? groupPostEntity.Post.SubCategoryID.Value : 0;
            postViewModel.DisplayCategory = BusinessObjectSeed.GetCatSubCategoryItemTextForId((long)postViewModel.CategoryID, EnumCategoryFor.FineArts);
            postViewModel.DisplaySubCategory = BusinessObjectSeed.GetCatSubCategoryItemTextForId(((long)postViewModel.SubCategoryID), EnumCategoryFor.FineArts);
            postViewModel.Description = groupPostEntity.Post.Description;
            postViewModel.IsBrandNew = groupPostEntity.Post.IsBrandNew.HasValue ? groupPostEntity.Post.IsBrandNew.Value : false;
            postViewModel.IsUsed = groupPostEntity.Post.IsUsed.HasValue ? groupPostEntity.Post.IsUsed.Value : false;
            postViewModel.IsUrgent = groupPostEntity.Post.IsUrgent.HasValue ? groupPostEntity.Post.IsUrgent.Value : false;
            postViewModel.IsForRent = groupPostEntity.Post.IsForRent.HasValue ? groupPostEntity.Post.IsForRent.Value : false;
            postViewModel.IsForSell = groupPostEntity.Post.IsForSell.HasValue ? groupPostEntity.Post.IsForSell.Value : false;
            postViewModel.PosterContactNumber = groupPostEntity.Post.PosterContactNumber;
            postViewModel.PosterName = groupPostEntity.Post.PosterName;
            postViewModel.Currency = groupPostEntity.Post.Currency;
            postViewModel.Price = groupPostEntity.Post.UnitPrice.HasValue ? (decimal)groupPostEntity.Post.UnitPrice.Value : 0;
           // postViewModel.FormattedPriceValue = postViewModel.GetFormatedPriceValue(postViewModel.Price.ToString());
            postViewModel.PublishDate = groupPostEntity.Post.PublishDate;
            postViewModel.WebsiteUrl = groupPostEntity.Post.WebsiteUrl;
            postViewModel.PostType = groupPostEntity.Post.PostType;
            postViewModel.SubCategoryCSS = BusinessObjectSeed.GetCategoryCSS(groupPostEntity.Post.SubCategoryID, StaticAppSettings.CategoryFor);
            postViewModel.CategoryCSS = BusinessObjectSeed.GetCategoryCSS(groupPostEntity.Post.CategoryID, StaticAppSettings.CategoryFor);
            postViewModel.LikeCount = groupPostEntity.Post.LikeCount.HasValue ? groupPostEntity.Post.LikeCount.Value : 0;
            postViewModel.CommentsCount = groupPostEntity.Post.ListComments != null && groupPostEntity.Post.ListComments.Count > 0 ? groupPostEntity.Post.ListComments.Count : 0;
            postViewModel.Comment = "";
            postViewModel.SearchTag = groupPostEntity.Post.SearchTag;
            MapImageFilesForDisplay(postViewModel, groupPostEntity.Post);
            MapUserReadonly(groupPostEntity.Post, postViewModel);
            MapAddressReadonly(groupPostEntity.Post, postViewModel);
            postViewModel.ListPostComments = GetPostCommentsReadonly(groupPostEntity.Post);
            LoadAValues(postViewModel);
        }

        public void MapGroupPanelPostEntityToPostViewModelReadonly(GroupPanelPost groupPostEntity, PostViewModel postVM)
        {
            postVM.PostID = groupPostEntity.Post.PostID;
        //    postVM.CreatedDate = groupPostEntity.Post.CreatedDate;
            postVM.Title = groupPostEntity.Post.Title;
            postVM.CategoryID = groupPostEntity.Post.CategoryID;
            postVM.SubCategoryID = groupPostEntity.Post.SubCategoryID;
            postVM.DisplayCategory = BusinessObjectSeed.GetCatSubCategoryItemTextForId((long)groupPostEntity.Post.CategoryID, EnumCategoryFor.FineArts);
            postVM.DisplaySubCategory = BusinessObjectSeed.GetCatSubCategoryItemTextForId((long)groupPostEntity.Post.SubCategoryID, EnumCategoryFor.FineArts);
            postVM.Description = groupPostEntity.Post.Description;
            postVM.IsBrandNew = groupPostEntity.Post.IsBrandNew.HasValue ? groupPostEntity.Post.IsBrandNew.Value : false;
            postVM.IsUsed = groupPostEntity.Post.IsUsed.HasValue ? groupPostEntity.Post.IsUsed.Value : false;
            postVM.IsUrgent = groupPostEntity.Post.IsUrgent.HasValue ? groupPostEntity.Post.IsUrgent.Value : false;
            postVM.IsForRent = groupPostEntity.Post.IsForRent.HasValue ? groupPostEntity.Post.IsForRent.Value : false;
            postVM.IsForSell = groupPostEntity.Post.IsForSell.HasValue ? groupPostEntity.Post.IsForSell.Value : false;
            postVM.PosterContactNumber = groupPostEntity.Post.PosterContactNumber;
            postVM.PosterName = groupPostEntity.Post.PosterName;
            postVM.Currency = groupPostEntity.Post.Currency;
            postVM.Price = groupPostEntity.Post.UnitPrice.HasValue ? (decimal)groupPostEntity.Post.UnitPrice.Value : 0;
         //   postVM.FormattedPriceValue = postVM.GetFormatedPriceValue(postVM.Price.ToString());
            postVM.PublishDate = groupPostEntity.Post.PublishDate;
            postVM.WebsiteUrl = groupPostEntity.Post.WebsiteUrl;
            postVM.PostType = groupPostEntity.Post.PostType;
            postVM.SubCategoryCSS = BusinessObjectSeed.GetCategoryCSS(groupPostEntity.Post.SubCategoryID, StaticAppSettings.CategoryFor);
            postVM.CategoryCSS = BusinessObjectSeed.GetCategoryCSS(groupPostEntity.Post.CategoryID, StaticAppSettings.CategoryFor);
            postVM.LikeCount = groupPostEntity.Post.LikeCount.HasValue ? groupPostEntity.Post.LikeCount.Value : 0;
            postVM.CommentsCount = groupPostEntity.Post.ListComments != null && groupPostEntity.Post.ListComments.Count > 0 ? groupPostEntity.Post.ListComments.Count : 0;
            postVM.Comment = "";
            postVM.SearchTag = groupPostEntity.Post.SearchTag;
            MapImageFilesForDisplay(postVM, groupPostEntity.Post);
            MapUserReadonly(groupPostEntity.Post, postVM);
            MapAddressReadonly(groupPostEntity.Post, postVM);
            postVM.ListPostComments = GetPostCommentsReadonly(groupPostEntity.Post);
        }

        private long GetCommentsCount(Post postEntity)
        {
            if (postEntity.ListComments == null || postEntity.ListComments.Count == 0)
                return 0;
            return postEntity.ListComments.Count;
        }

        private void SetAddressInformationReadonly(Post postEntity, PostViewModel postVM)
        {
            var address = postEntity.Address;
            if (address != null)
            {
                postVM.AreaDescription = address.AreaDescription;
                postVM.StateID = address.StateID;
                postVM.DisplayState = LocationRelatedSeed.GetStateDescription((EnumState)postVM.StateID);
            }
        }

        private void SetUserInformationReadonly(Post postEntity, PostViewModel postVM)
        {
            var userEntity = postEntity.User;
            if (userEntity != null)
            {
                postVM.ClientName = userEntity.ClientName;
                postVM.IsCompanySeller = userEntity.UserAccountType == EnumUserAccountType.Company ? true : false;
                postVM.IsPrivateSeller = userEntity.UserAccountType == EnumUserAccountType.IndividualAdvertiser ? true : false;
                postVM.UserID = userEntity.UserID;
            }
        }

        private byte[] GetSingleDisplayImage(Post postEntity)
        {
            var fileObj = postEntity.ImageFiles.Where(a => a.Image != null).FirstOrDefault();
            return fileObj == null ? fileObj.Image : new byte[1];
        }

        private void MapUserReadonly(Post postEntity, PostViewModel postVM)
        {
            var userEntity = postEntity.User;
            if (userEntity != null)
            {
                postVM.Email = userEntity.Email;
                postVM.ClientName = userEntity.ClientName;
                postVM.UserID = userEntity.UserID;
                postVM.IsPrivateSeller = userEntity.UserAccountType == EnumUserAccountType.IndividualAdvertiser ? true : false;
                postVM.IsCompanySeller = userEntity.UserAccountType == EnumUserAccountType.Company ? true : false;
            }
        }

        private void MapAddressReadonly(Post postEntity, PostViewModel postVM)
        {
            var address = postEntity.Address;
            if (address != null)
            {
                postVM.AreaDescription = address.AreaDescription;
                postVM.StateID = address.StateID;
                postVM.DisplayState = LocationRelatedSeed.GetStateDescription((EnumState)postVM.StateID);
            }
        }

        private List<PostCommentViewModel> GetPostCommentsReadonly(Post postEntity)
        {
            var listComments = postEntity.ListComments.Where(a => a.IsActive).ToList();
            if (listComments.Count == 0 || listComments == null)
                return new List<PostCommentViewModel>();

            List<PostCommentViewModel> objListPostComments = new List<PostCommentViewModel>();
            foreach (var item in listComments)
            {
                PostCommentViewModel objItem = new PostCommentViewModel();
                objItem.CommentID = item.CommentID;
                objItem.Comment = item.Comment;
                objItem.CommentDate = item.CreatedDate.ToShortDateString();
                objListPostComments.Add(objItem);
            }
            return objListPostComments.ToList();
        }

        private void MapImageFilesForDisplay(PostViewModel postVM, Post postEntity)
        {
            if (postVM == null) throw new ArgumentNullException("postVm");
            if (postEntity == null) throw new ArgumentNullException("post");
            List<WinDocFile> imageList = new List<WinDocFile>();
            if (postEntity.ImageFiles != null)
            {
                imageList = postEntity.ImageFiles.Where(a => a.IsActive).ToList();
            }

            FileViewModel objImageVM;
            foreach (var fileEntity in imageList.ToList())
            {
                objImageVM = new FileViewModel();
                objImageVM.Image = fileEntity.Image;
                objImageVM.FileID = (int) fileEntity.FileID;
                objImageVM.FileName = fileEntity.FileName;
                objImageVM.PostID = fileEntity.PostID;
                objImageVM.IsNewItem = false;
                postVM.ListImages.Add(objImageVM);
            }
            var imageVM = postVM.ListImages.FirstOrDefault();
            postVM.Image = imageVM?.Image;
        }
    }
}
