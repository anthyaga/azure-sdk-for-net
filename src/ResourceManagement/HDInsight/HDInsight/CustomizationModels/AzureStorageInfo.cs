using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HDInsight.CustomizationsModels;

namespace Microsoft.Azure.Management.HDInsight.CustomizationModels
{
    /// <summary>
    /// Gets or sets the StorageAccountName, StorageAccountKey and StorageContainer for the Azure Blob Storage Account.
    /// </summary>
    public class AzureStorageInfo : IStorageInfo
    {
        /// <summary>
        /// Gets Azure Blob Storage Account Name.
        /// </summary>
        public string StorageAccountName { get; private set; }

        /// <summary>
        /// Gets Azure Blob Storage Container.
        /// </summary>
        public string StorageContainer { get; private set; }

        /// <summary>
        /// Gets Azure Blob Storage Account Key.
        /// </summary>
        public string StorageAccountKey { get; private set; }

        private const string AzureBlobStoreDnsSuffix = ".blob.core.windows.net";

        /// <summary>
        /// Initializes a new instance of the AzureStorageInfo class.
        /// </summary>
        /// <param name="storageAccountName">StorageName for the Azure Blob Storage Account.</param>
        /// <param name="storageAccountKey">StorageKey for the Azure Blob Storage Account.</param>
        /// <param name="storageContainer">StorageContainer for the Azure Blob Storage Account. The cluster will leverage to store some cluster level files.</param>
        public AzureStorageInfo(string storageAccountName, string storageAccountKey, string storageContainer)
        {
            if (string.IsNullOrEmpty(storageAccountName))
                throw new ArgumentException("Input cannot be empty", "storageAccountName");
            if (string.IsNullOrEmpty(storageAccountKey))
                throw new ArgumentException("Input cannot be empty", "storageAccountKey");
            if (string.IsNullOrEmpty(storageContainer))
                throw new ArgumentException("Input cannot be empty", "storageContainer");

            this.StorageAccountName = storageAccountName.Contains(".") ?
                storageAccountName :
                string.Format("{0}{1}", storageAccountName, AzureBlobStoreDnsSuffix);

            this.StorageAccountKey = storageAccountKey;
            this.StorageContainer = storageContainer;
        }
        /// <summary>
        /// Gets Azure Blob storage Uri.
        /// </summary>
        public string GetStorageAccountUri()
        {
            if (String.IsNullOrEmpty(StorageAccountName))
            {
                return String.Empty;
            }

            return string.Format("wasb://{0}@{1}", StorageContainer, StorageAccountName);
        }

        /// <summary>
        /// Gets Azure Blob Storage Account Key.
        /// </summary>
        public string GetStorageAccountKeyValue()
        {
            return StorageAccountKey;
        }
    }
}
