namespace PickUp.Data.Models
{
    using PickUp.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public new int? Id { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
