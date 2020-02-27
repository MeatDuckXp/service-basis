namespace ServiceBasis.Abstraction
{
    /// <summary>
    ///     Interface defining service base operations
    /// </summary>
    public interface IServiceBase
    {
        /// <summary>
        ///     Gets or sets the extension meta data
        /// </summary>
        BaseDefinition Definition { get; set; }

        /// <summary>
        ///     Install service
        /// </summary>
        void Install();

        /// <summary>
        ///     Uninstall service
        /// </summary>
        void Uninstall();
    }
}