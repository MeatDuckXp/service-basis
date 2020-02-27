using System.Collections.Generic;

namespace ServiceBasis.Abstraction
{
    /// <summary>
    ///     Service base definition
    /// </summary>
    public class BaseDefinition
    {
        /// <summary>
        ///     Gets or Sets service identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     Gets or Sets service group definition
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        ///     Gets or Sets service full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or Sets service system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        ///     Gets or Sets service version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or Sets service author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Gets or Sets service file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or Sets service description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or Sets service tags
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        ///     Gets or Sets supported versions
        /// </summary>
        public List<string> SupportedVersions { get; set; }
    }
}