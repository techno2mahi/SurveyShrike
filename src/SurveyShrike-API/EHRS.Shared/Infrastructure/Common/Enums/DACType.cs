namespace EHRS.Shared
{
    /// <summary>
    /// The DAC Types
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC Type (Default)
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Survey DAC
        /// </summary>
        [QualifiedTypeName("EHRS.Data.dll", "EHRS.Data.SurveyDAC")]
        Survey = 1
    }
}