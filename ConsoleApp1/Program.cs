// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Storage.Blobs;

//Console.WriteLine("Hello, World!");

string conString = "DefaultEndpointsProtocol=https;AccountName=daryncevstudent;AccountKey=Di2rFiceS4dsU8ghZkk18EcY/CacChk4QLK8keOgLyLQH8S+XuG/6ngZvEFLarD0fYfM33Pvq+0i+ASto3vfTg==;EndpointSuffix=core.windows.net";

//var blobServiceClient = new BlobServiceClient(new Uri("https://daryncevstudent.blob.core.windows.net"),new DefaultAzureCredential());
var blobServiceClient = new BlobServiceClient(conString);

string containerName="conn"+Guid.NewGuid().ToString();

string filePath = "Data";
Directory.CreateDirectory(filePath);

string fileName = "Test.txt";

await File.WriteAllTextAsync(Path.Combine(filePath, fileName), "Hello World of Azure!");

//BlobContainerClient blobContainerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
BlobContainerClient blobContainerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);


BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

await blobClient.UploadAsync(Path.Combine(filePath, fileName));

await foreach (var item in   blobContainerClient.GetBlobsAsync())
{
    Console.WriteLine(item.Name);
}
Console.ReadLine();