using System.IO;

namespace ServiceBasis
{
    /// <summary>
    ///     Provides service definition that enables extension definition reading
    /// </summary>
    public interface IDefinitionReader
    {
        /// <summary>
        ///     Validates that the given location has extension located within
        /// </summary>
        /// <param name="location">Path to the given location</param>
        /// <returns>True if present, otherwise false</returns>
        bool HasExtensionPresent(string location);

        /// <summary>
        ///     Validates that the given location has extension located within
        /// </summary>
        /// <param name="location">Path to the given location</param>
        /// <returns>True if present, otherwise false</returns>
        bool HasExtensionPresent(DirectoryInfo location);

        /// <summary>
        ///     Loads extension meta data container from the given location.
        /// </summary>
        /// <param name="location">Path to the given location.</param>
        /// <returns>BaseDefinitionContainer</returns>
        BaseDefinitionContainer Load(string location);

        /// <summary>
        ///     Loads extension meta data container from the given location.
        /// </summary>
        /// <param name="location">Path to the given location.</param>
        /// <returns>BaseDefinitionContainer</returns>
        BaseDefinitionContainer Load(DirectoryInfo location);
    }
}