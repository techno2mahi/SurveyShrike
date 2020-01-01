using EHRS.Shared;

namespace EHRS.Shared
{
    /// <summary>
    /// Defines a contract for base business domain component,
    /// Author : TMC
    /// </summary>
    public interface IBusinessDomainComponent
    {
        /// <summary>
        /// Gets the type of the BDC.
        /// </summary>
        /// <value>The type of the BDC.</value>
        BDCType BDCType { get; }
    }
}
