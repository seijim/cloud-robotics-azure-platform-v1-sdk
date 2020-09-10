using System;
using System.IO;
using CloudRoboticsUtil;

namespace RbAppVisionApi
{
    public class BlobData
    {
        private string _accountName;
        private string _accountKey;
        private string _container;
        private string blobStorageConnString;

        public BlobData(string accountName, string accountKey, string container)
        {
            _accountName = accountName;
            _accountKey = accountKey;
            _container = container;
            blobStorageConnString = "DefaultEndpointsProtocol=https;AccountName="
                + _accountName + ";AccountKey=" + _accountKey;
        }
        public void Delete(string filename)
        {
                RbAzureStorage rbAzureStorage = new RbAzureStorage(_accountName, _accountKey);
                rbAzureStorage.BlockBlobDelete(_container, filename);
        }
        public byte[] GetStream(string filename)
        {
            RbAzureStorage rbAzureStorage = new RbAzureStorage(_accountName, _accountKey);
            Stream stream = rbAzureStorage.BlockBlobOpenRead(_container, filename);
            long fileSize = rbAzureStorage.BlockBlobFileSize();
            byte[] buffer = new byte[fileSize];
            int readSize;
            int remain = (int)fileSize;
            int bufPos = 0;

            while (remain > 0)
            {
                // Read each 1024 bytes
                readSize = stream.Read(buffer, bufPos, Math.Min(1024, remain));
                bufPos += readSize;
                remain -= readSize;
            }
            stream.Close();

            return buffer;
        }
    }
}
