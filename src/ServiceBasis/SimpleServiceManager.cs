using System;
using System.IO;
using System.Linq;
using LightInject;
using ServiceBasis.Abstraction;

namespace ServiceBasis
{
    /// <summary>
    ///     Simple service manager provides a simple logic that allows the user to load and manage the service implementations.
    /// </summary>
    public class SimpleServiceManager : IServiceManager
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="definitionReader">Service base definition Reader.</param>
        /// <param name="location">Services implementation folder.</param>
        public SimpleServiceManager(IDefinitionReader definitionReader, string location)
        {
            _location = location;
            _definitionReader = definitionReader;
            _serviceContainer = new ServiceContainer();
        }

        /// <summary>
        ///     Initializes state.
        /// </summary>
        public void Initialize()
        {
            var rootDirectory = new DirectoryInfo(_location);
            if (!rootDirectory.Exists)
            {
                rootDirectory.Create();
            }

            var serviceImplementations = rootDirectory.GetDirectories();
            foreach (var serviceImplementation in serviceImplementations)
            {
                if (CheckHasPlugin(serviceImplementation))
                {
                    InitializePlugIn(serviceImplementation.FullName);
                }
            }
        }

        /// <summary>
        ///     Returns service instance.
        /// </summary>
        /// <typeparam name="TServiceType">Type of service.</typeparam>
        /// <param name="serviceType">Service type object.</param>
        /// <returns>Service instance</returns>
        public TServiceType GetInstance<TServiceType>(Type serviceType)
        {
            return (TServiceType) _serviceContainer.GetInstance(serviceType);
        }

        #region Fields

        private readonly IServiceContainer _serviceContainer;
        private readonly IDefinitionReader _definitionReader;
        private readonly string _location;

        #endregion

        #region Private methods

        /// <summary>
        ///     Validates does the given directory contain any service implementation.
        /// </summary>
        /// <param name="directoryInfo">Directory info.</param>
        /// <returns>True if found, otherwise false.</returns>
        private bool CheckHasPlugin(DirectoryInfo directoryInfo)
        {
            var extensionDataFound = _definitionReader.HasExtensionPresent(directoryInfo);
            return extensionDataFound;
        }

        /// <summary>
        ///     Initializes the given service to ready to use state.
        /// </summary>
        /// <param name="location">Service definition folder.</param>
        private void InitializePlugIn(string location)
        {
            var definitionContainer = _definitionReader.Load(location);
            var metaData = definitionContainer.MetaData;

            var assemblyFileLoader = new AssemblyLoader();
            var extensionAssembly = assemblyFileLoader.LoadAssembly(definitionContainer.ServiceBaseDirectory, metaData.FileName);

            var referencedTypes = extensionAssembly.GetTypes();
            var classType = referencedTypes.SingleOrDefault(item => typeof(IServiceBase).IsAssignableFrom(item) &&
                                                                    item.IsClass &&
                                                                    !item.IsInterface &&
                                                                    !item.IsAbstract);

            if (classType == default)
            {
                return;
            }

            var interfaceType = classType.GetInterfaces().Single(item => item.Name != typeof(IServiceBase).Name);
            var extensionInstance = ObjectCreator.Create<IServiceBase>(classType);

            extensionInstance.Definition = metaData;

            _serviceContainer.RegisterInstance(interfaceType, extensionInstance, metaData.Identifier);
        }

        #endregion
    }
}