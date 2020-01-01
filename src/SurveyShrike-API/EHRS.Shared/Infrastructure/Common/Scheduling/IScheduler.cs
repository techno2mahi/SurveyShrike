
namespace EHRS.Shared
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines a contract for scheduler
    /// </summary>
    public interface IScheduler : IDisposable
    {
        /// <summary>
        /// Initializes the scheduler service.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starts the scheduler service.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the scheduler service.
        /// </summary>
        [SuppressMessage(SuppressMessageConstants.NamingCategory,
            SuppressMessageConstants.IdentifiersShouldNotMatchKeywords)]
        void Stop();
    }
}