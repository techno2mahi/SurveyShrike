using System;
using System.Collections.Generic;
using EHRS.Shared; 
using System.Web.Caching; 

namespace EHRS.Web.Shared
{
    /// <summary>
    /// Contains common methods to be cached,
    /// Author: @techno2mahi.
    /// </summary>
    public static class CacheMethods
    {
        #region "Methods"

        /// <summary>
        /// Clears all cache items
        /// </summary>
        public static void ClearAllCache(Cache cache)
        {
            foreach (System.Collections.DictionaryEntry entry in cache)
            {
                cache.Remove((string)entry.Key);
            }
        }
 

        /// <summary>
        /// This Method is used to get the list of surveys and put in cache
        /// </summary>
        public static IList<ISurveyDTO> FetchAllSurveys()
        {
            if (CacheManager<SurveyState>.Data.Surveys == null)
            {
                OperationResult<IList<ISurveyDTO>> surveys = null;
                ISurveyBDC surveyBDC = (ISurveyBDC)BDCFactory.Instance.Create(BDCType.Survey);
                surveys = surveyBDC.GetAllSurveys();
                if (surveys != null && surveys.IsValid())
                {
                    CacheManager<SurveyState>.Data.Surveys = surveys.Data;
                }
                else
                {
                    throw new Exception(ResourceUtility.GetCaptionFor(ResourceConstants.Survey.ErrorMessages.FailedToFetchSurvey));
                }
            }
            return CacheManager<SurveyState>.Data.Surveys;
        }

        #endregion
    }
}
