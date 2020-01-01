namespace EHRS.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Survey BDC
        /// </summary>
        [QualifiedTypeName("EHRS.Business.dll", "EHRS.Business.SurveyBDC")]
        Survey = 1
    }
}
