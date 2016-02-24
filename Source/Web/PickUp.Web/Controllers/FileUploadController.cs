namespace PickUp.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using PickUp.Data.Models;
    using PickUp.Services.Data.Contracts;

    [Authorize]
    public class FileUploadController : Controller
    {
        private IImagesService images;
        private IUsersService users;

        public FileUploadController(IImagesService images, IUsersService users)
        {
            this.images = images;
            this.users = users;
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var imageToAdd = new Image();

                using (var memory = new MemoryStream())
                {
                    file.InputStream.CopyTo(memory);
                    var byteArray = memory.GetBuffer();
                    var fileName = file.FileName;
                    var fileExtension = Path.GetExtension(fileName).Substring(1);

                    imageToAdd.FileName = fileName;
                    imageToAdd.Content = byteArray;
                    imageToAdd.Extension = fileExtension;
                }

                this.images.Create(imageToAdd);
                var userId = this.User.Identity.GetUserId();
                var currentUser = this.users.GetById(userId);
                currentUser.ImageId = imageToAdd.Id;
                this.users.Update(currentUser);
            }

            return this.RedirectToAction("Details", "Users");
        }
    }
}
