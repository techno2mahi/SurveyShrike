using System;
using System.Collections.Generic;
namespace EHRS.Shared
{
    /// <summary>
    /// ISurveyDAC interface.
    /// </summary>
    /// <seealso cref="EHRS.Shared.IDataAccessComponent"/>
    public interface ISurveyDAC : IDataAccessComponent
    {
        /// <summary>
        /// Gets Survey by Identifier.
        /// </summary>
        /// <param name="surveyId">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        ISurveyDTO GetSurveyById(int surveyId);

        /// <summary>
        /// Gets Survey by Identifier.
        /// </summary>
        /// <param name="surveyId">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        IList<ISurveyDTO> GetAllSurveys();

        /// <summary>
        /// Adds the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        ISurveyDTO CreateSurvey(ISurveyDTO surveyDto);

        /// <summary>
        /// Updates the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        ISurveyDTO UpdateSurvey(ISurveyDTO surveyDto);

        /// <summary>
        /// Deletes the Survey.
        /// </summary>
        /// <param name="surveyDto">The Survey dto.</param>
        /// <returns>EHRS.Shared.ISurveyDTO.</returns>
        bool DeleteSurvey(int surveyId);
    }
}