using System;
using System.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace kkkkkkaaaaaa.WindowsAzure.Storage.Blob
{
    public class Class1
    {
        public void Do(string path)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[@"kkkkkkaaaaaa.WindowsAzure.DevelopmentStorage.ConnectionString"];
            //var account = CloudStorageAccount.Parse(connectionString.ConnectionString);
            var account = CloudStorageAccount.DevelopmentStorageAccount;
            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference(@"container");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions()
                                         {
                                             PublicAccess = BlobContainerPublicAccessType.Container,
                                         });

            var blob = container.GetBlockBlobReference("a.txt");

            var stream = File.OpenRead(path);

            try
            {
                blob.UploadFromStream(stream);
            }
            finally
            {
                if (stream != null) { stream.Close(); }
            }
        }
    }
}