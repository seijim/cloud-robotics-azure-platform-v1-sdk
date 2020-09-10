using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudRoboticsUtil
{
    public class RbAzureStorage
    {
        private string storageAccount;
        private string storageKey;
        private string storageConnectionString;
        private CloudBlockBlob cloudBlockBlob;
        private Stream blobStream;
        private long blobFileSize = 0;

        public RbAzureStorage(string storageAccount, string storageKey)
        {
            this.storageAccount = storageAccount;
            this.storageKey = storageKey;
            storageConnectionString = "DefaultEndpointsProtocol=https;AccountName="
                    + storageAccount + ";AccountKey=" + storageKey;
        }

        public void BlockBlobDownload(FileStream stream, string blobContainer, string fileName)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(blobContainer);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

                blockBlob.DownloadToStream(stream);
            }
            catch (Exception ex)
            {
                ApplicationException ae = new ApplicationException("AzureStorage * Blob download error!! (" + ex.Message + ")", ex);
                throw ae;
            }
        }

        public void BlockBlobUpload(FileStream stream, string blobContainer, string fileName)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(blobContainer);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

                blockBlob.UploadFromStream(stream);
            }
            catch (Exception ex)
            {
                ApplicationException ae = new ApplicationException("AzureStorage * Blob upload error!! (" + ex.Message + ")", ex);
                throw ae;
            }
        }

        public Stream BlockBlobOpenRead(string blobContainer, string fileName)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(blobContainer);
                cloudBlockBlob = container.GetBlockBlobReference(fileName);
                blobStream = cloudBlockBlob.OpenRead();
                blobFileSize = cloudBlockBlob.Properties.Length;

                return blobStream;
            }
            catch (Exception ex)
            {
                ApplicationException ae = new ApplicationException("AzureStorage * Blob OpenRead error!! (" + ex.Message + ")", ex);
                throw ae;
            }
        }

        public long BlockBlobFileSize()
        {
            return this.blobFileSize;
        }

        public void BlockBlobDelete(string blobContainer, string fileName)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(blobContainer);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

                blockBlob.Delete();
            }
            catch (Exception ex)
            {
                ApplicationException ae = new ApplicationException("AzureStorage * Blob delete error!! (" + ex.Message + ")", ex);
                throw ae;
            }
        }

    }
}

