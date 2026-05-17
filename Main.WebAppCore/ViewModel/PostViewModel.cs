
using Common;
using FineArtsWebApp;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FineArtsWebApp
{
    public class PostViewModel : BaseViewModel
    {
        public PostViewModel()
        {
            ListImages = new List<FileViewModel>();
            CategorySearchInfoModel = new CategorySearchInfoModel();
            ContentInfoViewModel = new ContentInfoViewModel();
            //ItemDetailsCompanyAboutPanelDesktop = new GroupPanelConfigurationViewModel();
            //ItemDetailsCompanyAboutPanelMobile = new GroupPanelConfigurationViewModel();
            ListPostProcess = new List<PostProcessViewModel>();
            ListPostService = new List<PostServiceViewModel>();
            PostServiceViewModel = new PostServiceViewModel();
            PostProcessViewModel = new PostProcessViewModel();
            FabiaInformationViewModel = new FabiaInformationViewModel();
            ListFabiaProvider = new List<FabiaProviderViewModel>();
        }
      

        public int PostID { get; set; }

        public EnumPostType? PostType { get; set; } = EnumPostType.Post;

        public DateTime? PublishDate { get; set; }

        public int UserID { get; set; }

        public string PosterContactNumber { get; set; } = string.Empty;

        public string PosterName { get; set; } = string.Empty;

        public string WebsiteUrl { get; set; } = string.Empty;

        public long? AddressID { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "The field Title is required!")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(4000)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        public long? CategoryID { get; set; }

        public long? SubCategoryID { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? DiscountedUnitPrice { get; set; }

        public decimal? DeshiHutBazarCommissionAmount { get; set; }

        public double? PaymentGatewayCommissionAmountPercent { get; set; }

        public decimal? PortalProductPrice { get; set; }

        public decimal? ShopShareAmount { get; set; }

        public decimal? DeshiHutBazarShareAmount { get; set; }

        public int? AvailableTotalUnits { get; set; }

        public EnumCurrency Currency { get; set; }

        public bool? IsBrandNew { get; set; }

        public bool? IsUsed { get; set; }

        public bool? IsUrgent { get; set; }
        public bool? IsRecent { get; set; }

        public bool? IsStudentDeal { get; set; }

        public bool? IsForSell { get; set; }

        public bool? IsForRent { get; set; }

        public int? LikeCount { get; set; }

        public string SearchTag { get; set; } = string.Empty;

        public EnumPostStatus PostStatus { get; set; } = EnumPostStatus.FreePosted;

        public UserPackage UserPackage { get; set; }

        public long? UserPackageID { get; set; }

        public List<FileViewModel> ListImages { get; set; }

        public List<PostCommentViewModel> ListComments { get; set; }

        public List<PostProcessViewModel> ListPostProcess { get; set; }

        public List<PostServiceViewModel> ListPostService { get; set; }

        public List<FabiaProviderViewModel> ListFabiaProvider { get; set; }

        public List<PostCommentViewModel> ListPostComments { get; set; }

        //public GroupPanelConfigurationViewModel ItemDetailsCompanyAboutPanelDesktop { get; set; }

        //public GroupPanelConfigurationViewModel ItemDetailsCompanyAboutPanelMobile { get; set; }

        public FabiaInformationViewModel FabiaInformationViewModel { get; set; }

        public PostServiceViewModel PostServiceViewModel { get; set; }

        public PostProcessViewModel PostProcessViewModel { get; set; }

        public ContentInfoViewModel ContentInfoViewModel { get; set; }

        public IEnumerable<SelectListItem> AV_State { get; set; }

        public IEnumerable<SelectListItem> AV_Category { get; set; }

        public IEnumerable<SelectListItem> AV_SubCategory { get; set; }

        public IEnumerable<SelectListItem> AV_PostType { get; set; }

        [Display(Name = "Category")]
        public string DisplayCategory { get; set; } = string.Empty;

        public string DisplaySubCategory { get; set; } = string.Empty;

        [StringLength(25)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(8)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [MaxLength(8)]
        [Display(Name = "Retype Password")]
        public string RePassword { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Name")]
        public string ClientName { get; set; } = string.Empty;

        [StringLength(40)]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Location")]
        public long? Location { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "The field State is required!")]
        public long? StateID { get; set; }

        [Display(Name = "State")]
        public string DisplayState { get; set; } = string.Empty;

        [Display(Name = "Address Detail")]
        public string AddressDetail { get; set; } = string.Empty;

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal DiscountedPrice { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal DeshiHutCommissionAmount { get; set; }

        [Display(Name = "Payment Gateway Commission (percent)")]
        public double PaymentGatewayCommision { get; set; }

        public string FormattedPriceValue { get; set; } = string.Empty;

        public int Order { get; set; }

        public string PostItemDetailViewUrl { get; set; }

        [Display(Name = "Area")]
        public string AreaDescription { get; set; }

        public bool IsPrivateSeller { get; set; }

        public bool IsCompanySeller { get; set; }

        public FileViewModel MarketItemDisplayImage { get; set; }

        public string FBUserID { get; set; }

        public string FBClientName { get; set; }

        public string FBEmail { get; set; }

        public long GroupPostID { get; set; }

        public int GroupPanelConfigID { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "CommentCommentButton")]
        public string Comment { get; set; }

        public long? PriceLow { get; set; }

        public long? PriceHigh { get; set; }

        public string SearchKey { get; set; }

        public string SimpleSearchKey { get; set; }

        public long CommentsCount { get; set; }

        public string SubCategoryCSS { get; set; }

        public string CategoryCSS { get; set; }

        public EnumOfferType OfferType { get; set; }

        [Display(Name = "Post Type")]
        public long? PostTypeID { get; set; }

        public string DealerTypeDisplay
        {
            get
            {
                if (IsPrivateSeller)
                    return "Private";
                if (IsCompanySeller)
                    return "Company";
                return "Private";
            }
        }

        public string UrgentDisplay
        {
            get
            {
                return IsUrgent.HasValue && IsUrgent.Value ? "Urgent Deal" : string.Empty;
            }
        }

        public string NewItemDisplay
        {
            get
            {
                return IsBrandNew.HasValue && IsBrandNew.Value ? "New Item" : "Used Item";
            }
        }
    }
}






























































