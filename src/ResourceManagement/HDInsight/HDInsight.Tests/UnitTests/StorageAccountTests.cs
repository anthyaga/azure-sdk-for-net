using System;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.CustomizationModels;
using Microsoft.Azure.Management.HDInsight.Models;
using Xunit;

namespace HDInsight.Tests.UnitTests
{
    public class StorageAccountTests
    {
        [Fact]
        public void TestAzureStorageInfo()
        {
            string existingStorageName = "testblob";
            string existingStorageNameFqdn = existingStorageName + ".blob.core.windows.net";
            string existingStorageKey = "testtest==";
            string containerName = "testcontainer";
            string existingStorageNameFqdnUri = "wasb://" + containerName +"@" + existingStorageNameFqdn;

            // Test for null input parameters
            try
            {
                var wasbStorageInfo = new AzureStorageInfo(existingStorageName, existingStorageKey, "");
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, "Input cannot be empty\r\nParameter name: storageContainer");
            }

            try
            {
                var wasbStorageInfo = new AzureStorageInfo("", existingStorageKey, containerName);
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, "Input cannot be empty\r\nParameter name: storageAccountName");
            }

            try
            {
                var wasbStorageInfo = new AzureStorageInfo(existingStorageName, "", containerName);
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, "Input cannot be empty\r\nParameter name: storageAccountKey");
            }

            // Test for StorageAccountUri
            var testWasbStorageInfo = new AzureStorageInfo(existingStorageName, existingStorageKey, containerName);
            Assert.Equal(existingStorageNameFqdnUri, testWasbStorageInfo.GetStorageAccountUri());

            testWasbStorageInfo = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey, containerName);
            Assert.Equal(existingStorageNameFqdnUri, testWasbStorageInfo.GetStorageAccountUri());
        }
    }
}
