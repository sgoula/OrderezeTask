using OrderezeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderezeTask.Repositories
{
   // Implements operations of IImageService interface

    public class ImageRepository : IImagesService
    {
        //Connection to database
        ImageContext db = new ImageContext();

        public List<Image> GetImages()
        {
            return db.Images.ToList();
        }

        public Image GetImageInfo(int id)
        {
            Image ImageInfo = db.Images.Find(id);
            return db.Images.Find(id);
        }

        public int AddNewImage(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
            return image.Id;
        }

        public void DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
        }
    }
}