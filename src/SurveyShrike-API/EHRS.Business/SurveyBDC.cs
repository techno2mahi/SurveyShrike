using System;
using System.Collections.Generic;
using EHRS.Shared;

namespace EHRS.Business
{
    /// <summary>
    /// SurveyBDC
    /// </summary> 
    public class SurveyBDC : BDCBase, ISurveyBDC
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyBDC"/> class.
        /// </summary>
        public SurveyBDC()
            : base(BDCType.Survey)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all Surveys
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public OperationResult<IList<ISurveyDTO>> GetAllSurveys()
        {
            OperationResult<IList<ISurveyDTO>> operationResult = null;
            try
            {
                var surveyDac = (ISurveyDAC)DACFactory.Instance.Create(DACType.Survey);
                var surveyDto = surveyDac.GetAllSurveys();

                operationResult = surveyDto != null
                                                      ? OperationResult<IList<ISurveyDTO>>.CreateSuccessResult(surveyDto)
                                                      : OperationResult<IList<ISurveyDTO>>.CreateFailureResult(
                                                       ResourceUtility.GetCaptionFor(
                                              ResourceConstants.Survey.ErrorMessages.FailedToFetchSurvey));

            }
            catch (DACException dacEx)
            {
                operationResult = OperationResult<IList<ISurveyDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                operationResult = OperationResult<IList<ISurveyDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return operationResult;
        }

        /// <summary>
        /// Gets survey by identifier
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public OperationResult<ISurveyDTO> GetSurveyById(int surveyId)
        {
            OperationResult<ISurveyDTO> operationResult = null;
            try
            {
                var surveyDac = (ISurveyDAC)DACFactory.Instance.Create(DACType.Survey);
                var surveyDto = surveyDac.GetSurveyById(surveyId);

                operationResult = surveyDto != null
                                                      ? OperationResult<ISurveyDTO>.CreateSuccessResult(surveyDto)
                                                      : OperationResult<ISurveyDTO>.CreateFailureResult(
                                                       ResourceUtility.GetCaptionFor(
                                              ResourceConstants.Survey.ErrorMessages.FailedToFetchSurvey));

            }
            catch (DACException dacEx)
            {
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return operationResult;
        }

        /// <summary>
        /// Creates Survey
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns></returns>
        public OperationResult<ISurveyDTO> CreateSurvey(ISurveyDTO surveyDto)
        {
            OperationResult<ISurveyDTO> operationResult = null;
            try
            {
                var surveyDac = (ISurveyDAC)DACFactory.Instance.Create(DACType.Survey);

                var resultDto = surveyDac.CreateSurvey(surveyDto);
                operationResult = resultDto != null
                                                      ? OperationResult<ISurveyDTO>.CreateSuccessResult(surveyDto)
                                                      : OperationResult<ISurveyDTO>.CreateFailureResult(
                                                       ResourceUtility.GetCaptionFor(
                                              ResourceConstants.Survey.ErrorMessages.FailedToCreateSurvey));

            }
            catch (DACException dacEx)
            {
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return operationResult;
        }

        /// <summary>
        ///  Updates survey
        /// </summary>
        /// <param name="queuedSurveyDto"></param>
        /// <returns></returns>
        public OperationResult<ISurveyDTO> UpdateSurvey(ISurveyDTO surveyDto)
        {
            OperationResult<ISurveyDTO> operationResult = null;
            try
            {
                ISurveyDAC surveyDac = (ISurveyDAC)DataAccessComponent.Create(DACType.Survey);
                ISurveyDTO resultDto = surveyDac.UpdateSurvey(surveyDto);
                operationResult = resultDto != null
                                                      ? OperationResult<ISurveyDTO>.CreateSuccessResult(resultDto)
                                                      : OperationResult<ISurveyDTO>.CreateFailureResult(
                                                       ResourceUtility.GetCaptionFor(
                                              ResourceConstants.Survey.ErrorMessages.FailedToUpdateSurvey));

            }
            catch (DACException dacEx)
            {
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                operationResult = OperationResult<ISurveyDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return operationResult;
        }

        /// <summary>
        /// Deletes a Notification
        /// </summary>
        /// <param name="notificationDto"></param>
        /// <returns></returns>
        public OperationResult<bool> DeleteSurvey(int surveyId)
        {
            OperationResult<bool> operationResult = null;
            try
            {
                var surveyDac = (ISurveyDAC)DACFactory.Instance.Create(DACType.Survey);

                var result = surveyDac.DeleteSurvey(surveyId);
                operationResult = result
                                                      ? OperationResult<bool>.CreateSuccessResult(result)
                                                      : OperationResult<bool>.CreateFailureResult(
                                                       ResourceUtility.GetCaptionFor(
                                              ResourceConstants.Survey.ErrorMessages.FailedToDeleteSurvey));

            }
            catch (DACException dacEx)
            {
                operationResult = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                operationResult = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return operationResult;
        }

        #endregion
    }
}