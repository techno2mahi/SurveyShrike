using System;
using EntityDataModel.EntityModels;
using EHRS.EntityDataModel;
using EHRS.Shared.Factories;
using EHRS.Shared;
using System.Collections.Generic;
using System.Linq;

namespace EHRS.Data
{
    /// <summary>
    /// Implementation for SurveyDAC
    /// </summary> 
    public class SurveyDAC : DACBase, ISurveyDAC
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyBDC"/> class.
        /// </summary>
        public SurveyDAC()
            : base(DACType.Survey)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all surveys
        /// </summary>
        /// <param name="surveyId">The Survey identifier.</param>
        /// <returns>IList<ISurveyDTO>.</returns>
        /// <exception cref="DACException">Error while fetching the Survey detail.</exception>
        public IList<ISurveyDTO> GetAllSurveys()
        {
            IList<ISurveyDTO> surveyDtos = new List<ISurveyDTO>();
            try
            {
                using (var dbContext = new SSEntities())
                {
                    var surveyEntities = (from Survey in dbContext.Surveys
                                          select Survey).ToList();

                    ISurveyDTO surveyDto = null;
                    foreach (var surveyEntity in surveyEntities)
                    {
                        surveyDto = (ISurveyDTO)DTOFactory.Instance.Create(DTOType.Survey);
                        EntityConverter.FillDTOFromEntity(surveyEntity, surveyDto);
                        surveyDtos.Add(surveyDto);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("Error while fetching the Survey detail.", ex);
            }

            return surveyDtos;
        }

        /// <summary>
        /// Gets the survey by identifier.
        /// </summary>
        /// <param name="surveyId">The Survey identifier.</param>
        /// <returns>ISurveyDTO.</returns>
        /// <exception cref="DACException">Error while fetching the Survey detail.</exception>
        public ISurveyDTO GetSurveyById(int surveyId)
        {
            ISurveyDTO surveyDto = null;
            try
            {
                using (var dbContext = new SSEntities())
                {
                    var surveyEntity = (from Survey in dbContext.Surveys
                                        where Survey.Id == surveyId
                                        select Survey).SingleOrDefault();

                    if (surveyEntity != null)
                    {
                        surveyDto = (ISurveyDTO)DTOFactory.Instance.Create(DTOType.Survey);
                        EntityConverter.FillDTOFromEntity(surveyEntity, surveyDto);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("Error while fetching the Survey detail.", ex);
            }

            return surveyDto;
        }

        /// <summary>
        /// Creates a survey
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns></returns>
        public ISurveyDTO CreateSurvey(ISurveyDTO surveyDTO)
        {
            try
            {
                if (surveyDTO != null)
                {
                    using (var context = new SSEntities())
                    {
                        var surveyEntity = new Survey();
                        EntityConverter.FillEntityFromDTO(surveyDTO, surveyEntity);
                        context.Surveys.Add(surveyEntity);
                        if (context.SaveChanges() > 0)
                        {
                            surveyDTO.Id = surveyEntity.Id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("Error while creating the Survey.", ex);
            }
            return surveyDTO;
        }

        /// <summary>
        /// Updates a survey
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns></returns>
        public ISurveyDTO UpdateSurvey(ISurveyDTO surveyDto)
        {
            try
            {
                if (surveyDto != null)
                {
                    using (var dbContext = new SSEntities())
                    {
                        var surveyEntity = (from qs in dbContext.Surveys
                                            where qs.Id == surveyDto.Id
                                            select qs).Single();

                        if (surveyEntity != null)
                        {
                            EntityConverter.FillEntityFromDTO(surveyDto, surveyEntity);
                        }

                        if (dbContext.SaveChanges() > 0)
                        {
                            surveyDto.Id = surveyEntity.Id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("Error while updating the Survey.", ex);
            }
            return surveyDto;
        }

        /// <summary>
        /// Deletes a Survey
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns></returns>
        public bool DeleteSurvey(int surveyId)
        {
            var retVal = false;
            try
            {
                using (var dbContext = new SSEntities())
                {
                    var surveyEntity = (from qs in dbContext.Surveys
                                        where qs.Id == surveyId
                                        select qs).Single();

                    dbContext.Surveys.Remove(surveyEntity);
                    if (dbContext.SaveChanges() > 0)
                    {
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException("Error while deleting the survey.", ex);
            }
            return retVal;
        }

        #endregion
    }
}