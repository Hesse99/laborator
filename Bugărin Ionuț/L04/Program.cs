using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace L04
{
    class Program
    {
        private static CloudTableClient tableClient;

        private static CloudTable studentsTable;
        static void Main(string[] args)
        {
            Task.Run(async () => {await Initialize(); })
                .GetAwaiter()
                .GetResult();
        }

        static async Task Initialize()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=projectdatc;AccountKey=pHlt1hdQBsujMfclBd73xC1LkBLjUwG5oFQWXIoHvOE86aZleQJAcfHvSoTBlkySm+vNHTlrj4AkiP7/asdbYg==;EndpointSuffix=core.windows.net";
            var account = CloudStorageAccount.Parse(storageConnectionString);
            tableClient = account.CreateCloudTableClient();

            studentsTable = tableClient.GetTableReference("studenti");
            await studentsTable.CreateIfNotExistsAsync();


        }
    }
}
