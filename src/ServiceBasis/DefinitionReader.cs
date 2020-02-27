using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ServiceBasis.Abstraction;

namespace ServiceBasis
{
    /// <summary>
    ///     Service base definition file reader implementation
    /// </summary>
    public class DefinitionReader : IDefinitionReader
    {
        /// <summary>
        ///     Validates that the given location has service base present.
        /// </summary>
        /// <param name="location">Path to the given location</param>
        /// <returns>True if present, otherwise false</returns>
        public bool HasExtensionPresent(string location)
        {
            var directoryInfo = new DirectoryInfo(location);
            return HasExtensionPresent(directoryInfo);
        }

        /// <summary>
        ///     Validates that the given location has service base present.
        /// </summary>
        /// <param name="location">Path to the given location</param>
        /// <returns>True if present, otherwise false</returns>
        public bool HasExtensionPresent(DirectoryInfo location)
        {
            var serviceBaseDefinitions = location.GetFiles(Constraints.ServiceBaseDefinitionFileName, SearchOption.AllDirectories);
            return serviceBaseDefinitions.Any();
        }

        /// <summary>
        ///     Loads service base meta data from the given location. 
        /// </summary>
        /// <param name="location">Directory Info.</param>
        /// <returns>BaseDefinitionContainer</returns>
        public BaseDefinitionContainer Load(string location)
        {
            var directoryInfo = new DirectoryInfo(location);
            return Load(directoryInfo);
        }

        /// <summary>
        ///     Loads service base meta data container from the given location. 
        /// </summary>
        /// <param name="location">Directory info.</param>
        /// <returns>BaseDefinitionContainer</returns>
        public BaseDefinitionContainer Load(DirectoryInfo location)
        {
            var metaDataFile = location.GetFiles(Constraints.ServiceBaseDefinitionFileName, SearchOption.AllDirectories);
            var fileInfo = metaDataFile.First();

            string fileContent;
            using (var streamReader = fileInfo.OpenText())
            {
                fileContent = streamReader.ReadToEnd();
            }

            var serviceBaseDefinition = JsonConvert.DeserializeObject<BaseDefinition>(fileContent);
            var response = new BaseDefinitionContainer
            {
                ServiceBaseDirectory = fileInfo.Directory,
                MetaData = serviceBaseDefinition
            };
            return response;
        }
    }
}
