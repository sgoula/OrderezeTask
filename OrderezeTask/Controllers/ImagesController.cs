using OrderezeTask.Models;
using OrderezeTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrderezeTask.Controllers
{
    public class ImagesController : Controller
    {

        private ImageRepository _iimageservice = new ImageRepository();

        BlobService _BlobService = new BlobService();


        // GET: Images
        public ActionResult Index()
        {
            List<Image> Images_View = _iimageservice.GetImages();
            return View(Images_View);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            var img = new Image();
            return View(img);
        }

        // POST: Images/Create
        [HttpPost]
        public ActionResult Create(Image image, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Upload Image to Blob
                    var BlockBlob = _BlobService.UploadBlob(ImageFile);
                    image.ImagePath = BlockBlob.Uri.ToString();

                    //Insert Image Information into database
                    _iimageservice.AddNewImage(image);

                    return RedirectToAction("Index");
                }
                catch
                {}
            }

            return View(image);
        }

        // GET: Images/Delete
        public ActionResult Delete(int id)
        {
            try
            {
                //Return Image Information
                Image ImageInfo = _iimageservice.GetImageInfo(id);
                return View(ImageInfo);
            }
            catch
            {
                return null;
            }
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //Return Image Information
                Image ImageInfo = _iimageservice.GetImageInfo(id);
                string BlobName = ImageInfo.ImagePath.Split('/').Last();

                //Delete Image from Blob
                _BlobService.DeleteBlob(BlobName);

                //Delete Image from database
                _iimageservice.DeleteImage(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return null;
            }
        }
    }
}