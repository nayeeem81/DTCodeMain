using System.ComponentModel.DataAnnotations;

namespace FineArtsWebApp
{
    public class AdminPostCommentViewModel : BaseModel
    {
        public AdminPostCommentViewModel()
        {
        }

        public int AdminPostCommentID { get; set; }
       
        public string Comment { get; set; } = string.Empty;

        public int AdminPostID { get; set; }

    }
}
