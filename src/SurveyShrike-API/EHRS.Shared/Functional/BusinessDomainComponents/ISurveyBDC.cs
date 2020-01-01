using System;
using System.Collections.Generic;

namespace EHRS.Shared
{
    /// <summary>
    /// The SurveyBDC interface.
    /// </summary>
    /// <seealso cref="EHRS.Shared.IBusinessDomainComponent" />
    public interface ISurveyBDC : IBusinessDomainComponent
    {
        /// <summary>
        /// Gets Survey by Identifier.
        /// </summary>
        /// <param name="surveyId">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        OperationResult<ISurveyDTO> GetSurveyById(int surveyId);

        /// <summary>
        /// Gets Survey by Identifier.
        /// </summary>
        /// <param name="surveyId">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        OperationResult<IList<ISurveyDTO>> GetAllSurveys();

        /// <summary>
        /// Adds the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        OperationResult<ISurveyDTO> CreateSurvey(ISurveyDTO surveyDto);

        /// <summary>
        /// Updates the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        OperationResult<ISurveyDTO> UpdateSurvey(ISurveyDTO surveyDto);

        /// <summary>
        /// Deletes the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        OperationResult<bool> DeleteSurvey(int surveyId);
    }
}