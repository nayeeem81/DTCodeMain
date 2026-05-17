

using Common;

namespace FineArtsWebApp
{
    public class FileViewModel
    {
        public FileViewModel() { }

        public bool? IsNewItem { get; set; }

        public int? FileID { get; set; }

        public string FileName { get; set; } = string.Empty;

        public byte[] Image { get; set; }

        public int? PostID { get; set; }

        public string FileType { get; set; } = string.Empty;

        public EnumPhoto EnumPhoto { get; set; } = EnumPhoto.Other;
    }
}
