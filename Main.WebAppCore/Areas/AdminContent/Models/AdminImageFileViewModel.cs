using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FineArtsWebApp
{
    public class AdminImageFileViewModel : BaseModel
    {
        public AdminImageFileViewModel()
        {
        }

        public int AdminImageFileID { get; set; }
       
        public byte[] ImageFileContent { get; set; }
       
        public int AdminPostID { get; set; }
    }
}
