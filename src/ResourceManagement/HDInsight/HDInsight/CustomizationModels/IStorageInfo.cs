using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight.CustomizationsModels
{
    /// <summary>
    /// Contains cluster storage information.
    /// </summary>
    public interface IStorageInfo
    {
        /// <summary>
        /// Gets the storage account name.
        /// </summary>
        string StorageAccountName { get; }

        /// <summary>
        /// Gets the storage account Uri.
        /// </summary>
        string GetStorageAccountUri();

        /// <summary>
        /// Gets the storage account key.
        /// </summary>
        string GetStorageAccountKeyValue();
    }
}