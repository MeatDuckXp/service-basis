using System;

namespace ServiceBasis
{
    /// <summary>
    ///     Service base manager interface defines the operations that can be performed in order to manage service instances.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        ///     Initializes service base manager state.
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Returns service instance.
        /// </summary>
        /// <typeparam name="TServiceType">Type of service.</typeparam>
        /// <param name="serviceType">Service type object.</param>
        /// <returns>Service instance</returns>
        TServiceType GetInstance<TServiceType>(Type serviceType);
    }
}