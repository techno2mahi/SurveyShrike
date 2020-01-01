using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using EHRS.Shared;
using EHRS.Web.Shared.ViewModels;
using EHRS.Web.Shared;
using EHRS.Shared.Caching;
using System;
using EHRS.Shared.Factories;
using EHRS.WebAPI.Helpers;

namespace EHRS.WebAPI.Controllers
{
    /// <summary>
    /// The city api controller.
    /// </summary>
    [RoutePrefix("api" + AppConstants.ConfigurationKeys.ApiVersion + "/surveys")]
    public class SurveyApiController : BaseApiController
    {
        private readonly ICacheManager _cacheManager;

        public SurveyApiController()
        {

        }
        public SurveyApiController(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        /// <summary>
        /// Get Survey by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult GetSurveyById(int id)
        {
            try
            {
                var surveyBdc = (ISurveyBDC)BDCFactory.Instance.Create(BDCType.Survey);
                var surveyViewModel = new SurveyViewModel();

                var result = surveyBdc.GetSurveyById(id);
                if (result != null && result.IsValid())
                {
                    DTOConverter.FillViewModelFromDTO(surveyViewModel, result.Data);
                    return Ok(surveyViewModel);
                }
                else
                {
                    return Error(HttpStatusCode.NotFound, "survey", "No Survey with specified id is found");
                }
            }
            catch (Exception ex)
            {
                //todo log the message
                return Error(HttpStatusCode.InternalServerError, "survey", "An internal error has occurred.");
            }
        }

        /// <summary>
        /// Get aLL Surveys
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("")]
        [Authorize]
        public IHttpActionResult GetSurveys()
        {
            try
            {
                var surveyBdc = (ISurveyBDC)BDCFactory.Instance.Create(BDCType.Survey);
                var surveyViewModels = new List<SurveyViewModel>();

                var result = surveyBdc.GetAllSurveys();
                if (result != null && result.IsValid())
                {
                    FillSurveysFromDto(surveyViewModels, result.Data);
                    return Ok(surveyViewModels);
                }
                else
                {
                    return Error(HttpStatusCode.NotFound, "survey", "No Surveys found");
                }
            }
            catch (Exception ex)
            {
                //todo log the message
                return Error(HttpStatusCode.InternalServerError, "survey", "An internal error has occurred.");
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IHttpActionResult PostSurvey(SurveyViewModel surveyViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var surveyDto = (ISurveyDTO)DTOFactory.Instance.Create(DTOType.Survey);
                    DTOConverter.FillDTOFromViewModel(surveyDto, surveyViewModel);
                    var surveyBdc = (ISurveyBDC)BDCFactory.Instance.Create(BDCType.Survey);
                    TokenIdentityHelper.FillTokenInfo(surveyDto, Request);
                    surveyDto.CreatedOn = DateTime.Now;
                    surveyDto.SurveyTitle = surveyViewModel.SurveyTitle;
                    var result = surveyBdc.CreateSurvey(surveyDto);
                    if (result.IsValid())
                    {
                        if (result.Data.Id > 0)
                        {
                            surveyViewModel.Id = result.Data.Id;
                            return Ok(surveyViewModel);
                        }
                    }

                    return BadRequest(ModelState);
                }
                catch (Exception ex)
                {
                    //todo log the message
                    return Error(HttpStatusCode.InternalServerError, "survey", "An internal error has occurred.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [Route("allSurveysCached")]
        public IHttpActionResult GetAllSurveys()
        {
            const string EHRS_ALL_SURVEYS_KEY = "SS.allSurveys";
            var allSurveys = _cacheManager.Get(EHRS_ALL_SURVEYS_KEY, () =>
           {
               var surveyBdc = (ISurveyBDC)BDCFactory.Instance.Create(BDCType.Survey);
               var surveyViewModels = new List<SurveyViewModel>();

               var result = surveyBdc.GetAllSurveys();
               if (result != null && result.IsValid())
               {
                   return result.Data;
               }
               else
               {
                   return null;
               }
           });

            return Ok(allSurveys);
        }



        #region Private Methods
        private void FillSurveysFromDto(List<SurveyViewModel> surveys, IEnumerable<ISurveyDTO> surveysResult)
        {
            foreach (var surveyDTO in surveysResult)
            {
                var surveyViewModel = new SurveyViewModel();
                DTOConverter.FillViewModelFromDTO(surveyViewModel, surveyDTO);
                surveys.Add(surveyViewModel);
            }
        }
        #endregion

    }
}
