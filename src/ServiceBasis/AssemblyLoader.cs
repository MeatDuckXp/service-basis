using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServiceBasis
{
    /// <summary>
    ///     Loads assembly files
    /// </summary>
    public class AssemblyLoader
    {
        private readonly string _fileExtension = "*.dll";

        /// <summary>
        ///     Loads assembly
        /// </summary>
        /// <param name="location">Assembly location.</param>
        /// <param name="fileName">Assembly file name.</param>
        /// <returns>Assembly if found, otherwise null.</returns>
        public Assembly LoadAssembly(DirectoryInfo location, string fileName)
        {
            var files = location.GetFiles(_fileExtension, SearchOption.AllDirectories);
            var serviceAssembly = files.FirstOrDefault(fileInfo => fileInfo.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));

            if (serviceAssembly == default)
            {
                return default;
            }

            var assembly = Assembly.LoadFile(serviceAssembly.FullName);
            return assembly;
        }
    }
}