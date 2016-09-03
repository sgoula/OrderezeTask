using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderezeTask
{
    public class BlobService
    {

        public CloudBlobContainer GetCloudBlobContainer()
        {
            //Create Account Blob Storage (Windows Authentication)
            CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnStr"));
            //Create Cloud blob service client
            CloudBlobClient BlobClient = StorageAccount.CreateCloudBlobClient();
            //Reference to a created container. Container is created to hold Blobs
            CloudBlobContainer BlobContainer = BlobClient.GetContainerReference("imagesblob");
            // Create the container if it doesn't already exist.
            BlobContainer.CreateIfNotExists();
            //Set all the required public access permissions.
            BlobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return BlobContainer;
        }

        //Upload image to azure blob storage and return block blob
        public CloudBlockBlob UploadBlob(HttpPostedFileBase Image)
        {
            //if image is not null
            if (Image.ContentLength > 0)
            {
                //Return Blob Container
                CloudBlobContainer BlobContainer = GetCloudBlobContainer();
                //Reference to blob
                CloudBlockBlob BlockBlob = BlobContainer.GetBlockBlobReference(Image.FileName);

                try
                {
                    BlockBlob.UploadFromStream(Image.InputStream);
                    return BlockBlob;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //Delete Block Blob
        public void DeleteBlob(string BlobImageName)
        {
            CloudBlobContainer BlobContainer = GetCloudBlobContainer();
            CloudBlockBlob BlockBlob = BlobContainer.GetBlockBlobReference(BlobImageName);
            BlockBlob.Delete();
        }

    }
}