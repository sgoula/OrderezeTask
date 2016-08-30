using OrderezeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderezeTask.Repositories
{
    interface IImagesService
    {
        /// <summary>
        /// Returns all images 
        /// </summary>
        /// <returns></returns>
        List<Image> GetImages();

        // Returns Image with given id
        Image GetImageInfo(int id);

        /// <summary>
        /// Adds the supplied <paramref name="image"/> to the system and returns the Id.
        /// Part of the operation is to store the Image in the blob storage.
        /// </summary>
        int AddNewImage(Image image);

        /// <summary>
        /// Deletes the Image with the supplied <paramref name="id"/> from the system 
        /// and deletes the file from the blob storage as well.
        /// </summary>
        void DeleteImage(int id);
    }
}
