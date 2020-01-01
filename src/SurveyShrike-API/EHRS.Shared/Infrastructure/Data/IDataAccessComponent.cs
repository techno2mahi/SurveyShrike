using System.Collections.Generic;

namespace EHRS.Shared
{
    /// <summary>
    /// Defines a contract for data access component,
    /// Author		: TMC
    /// </summary>
    public interface IDataAccessComponent
    {
        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        DACType Type { get; }

    }
}
