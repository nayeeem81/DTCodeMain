namespace FineArtsWebApp
{
    public class ManageAdminPostViewModel : BaseModel
    {
        public ManageAdminPostViewModel()
        {
            ListAdminPost = new List<AdminPostViewModel>();
        }

        public List<AdminPostViewModel> ListAdminPost { get; set; }
    }
}
