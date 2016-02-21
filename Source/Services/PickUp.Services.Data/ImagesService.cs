using PickUp.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickUp.Data.Models;
using PickUp.Data.Common;

namespace PickUp.Services.Data
{
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
