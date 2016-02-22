namespace PickUp.Services.Data
{
    using PickUp.Data.Common;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private IDbRepository<Image> images;

        public ImagesService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public void Create(Image image)
        {
            this.images.Add(image);
            this.images.Save();
        }
    }
}
