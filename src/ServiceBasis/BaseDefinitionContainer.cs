using System.IO;
using ServiceBasis.Abstraction;

namespace ServiceBasis
{
    /// <summary>
    ///     Service base definition container
    /// </summary>
    public class BaseDefinitionContainer
    {
        /// <summary>
        ///     Gets or Sets meta data
        /// </summary>
        public BaseDefinition MetaData { get; set; }

        /// <summary>
        ///     Gets or Sets ServiceBaseDirectory
        /// </summary>
        public DirectoryInfo ServiceBaseDirectory { get; set; }
    }
}
