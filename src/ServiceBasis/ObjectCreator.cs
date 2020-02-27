using System;

namespace ServiceBasis
{
    /// <summary>
    ///     Type instance creator
    /// </summary>
    public class ObjectCreator
    {
        /// <summary>
        ///     Creates instance of the given type by invoking the default constructor.
        /// </summary>
        /// <typeparam name="TServiceType">Service type.</typeparam>
        /// <param name="implementingType">Implementation type.</param>
        /// <returns>Instance of the TServiceType</returns>
        public static TServiceType Create<TServiceType>(Type implementingType)
        {
            var instance = (TServiceType) Activator.CreateInstance(implementingType);
            return instance;
        }
    }
}