using System;
using System.Configuration;
using System.Linq;

namespace EHRS.Shared
{
    /// <summary>
    /// Contains application level constants.    
    /// Author: TMC
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Contains configuration keys constants
        /// </summary>
        public struct ConfigurationKeys
        {
            #region "Properties"

            //Constants
            //todo some of these constants values need to be placed at the configuration file
            public const string AllowedOrigins = "http://localhost:55551,http://localhost:4200,http://localhost:5000,http://localhost:4300";
            public const string ApiVersion = "/v1";
            public const string JobsSecretKey = "wndowejsddbfshsdfjssfk";//change it each time it deploys and keep it to yourself
            public const int EmailConfirmationLifeTimeInHours = 6;
            public const int RequiredPasswordLength = 4;

            // Location API
            public static readonly bool IsStoringInMongo;
            public static readonly bool IsSimulating;
            public static readonly double TokenExpirationLifetimeInDays;

            /// <summary>
            /// Constant representing the assemblies' output bin folder name.
            /// </summary>
            public static readonly string OutputBinFolderName;
            public static readonly string WebApiUrl;
            public static readonly string IdentityUrl;
            public static readonly string WebApiVersion = ConfigurationManager.AppSettings["WebApiVersion"];
            public static readonly string WebApiBaseUrl;
            public static readonly string AppBaseUrl;
            public static readonly string EnableResourceOptimization;
            public static readonly string PatientMediaPath;
            public static readonly string ProfileImagePath;

            /// <summary>
            /// Facebook 
            /// </summary>
            public static readonly string FacebookAppToken;
            public static readonly string FacebookAppId;
            public static readonly string FacebookAppSecret;
            public static readonly string FacebookAccessToken;

            public static readonly string FacebookMobileAppId;
            public static readonly string FacebookMobileAppToken;
            

            /// <summary>
            /// Google 
            /// </summary>

            // Web
            public static readonly string GoogleClientId;
            public static readonly string GoogleClientSecret;
            public static readonly string AccessTokenExpireTimeInMinutes;

            // Mobile App
            public static readonly string GoogleMobileClientId;


            /// <summary>
            /// 
            /// </summary>
            public static readonly string IsTestMail;
            public static readonly bool IsDevelopment;
            public static readonly bool IsThrottlingEnabled;


            //POSITION QUEUE
            public static readonly string PositionExchangeName;
            public static readonly string PositionRoutingKeyPrefix;
            public static readonly string PositionRoutingKey;
            public static readonly string DatabaseCollectionName;
            public static readonly string PositionNotificationQueueName;
            public static readonly string PositionPersistenceQueueName;

            //Notification QUEUE
            public static readonly string NotificationExchangeName;
            public static readonly string NotificationRoutingKeyPrefix;
            public static readonly string NotificationRoutingKey;
            public static readonly string NotificationQueueName;

            public static readonly string QueueHostName;
            public static readonly string QueueUserName;
            public static readonly string QueuePassword;
            public static readonly string QueueProtocol;
            public static readonly int QueuePort;

            //Location Queue
            public static readonly string VehiclesExchangeName;
            public static readonly string VehiclesRoutingKeyPrefix;
            public static readonly string LocationQueueName;
            public static readonly double InstanceCountLocationQueueConsumers;
            public static readonly double LocationDataPushIntervalInMiliseconds;
            public static readonly string DriverDefaultMobileNumber;

            //Reddis cache            
            public static readonly bool RedisCachingEnabled;
            public static readonly string RedisCachingConnectionString;

            /// <summary>
            /// Company profile images upload folder path
            /// </summary>
            public static readonly string CompanyProfileImagesUploadFolderPath;

            /// <summary>
            /// SSO IsLoggedIn Url
            /// </summary>
            public static readonly string SSOIsLoggedInUrl;

            /// <summary>
            /// SSOLoginUrl
            /// </summary>
            public static readonly string SSOLoginUrl;

            /// <summary>
            /// SSOLogoutUrl
            /// </summary>
            public static readonly string SSOLogoutUrl;

            /// <summary>
            /// To set Maximum Number of Invalid Login Attemps
            /// </summary>
            public static readonly short MaxInvalidLogOnAttempts;

            /// <summary>
            /// To set Maximum Time for Locked Account
            /// </summary>
            public static readonly short MaxTimeForLockedAccount;

            /// <summary>
            /// UserStatusToCheck
            /// </summary>
            public static readonly short UserStatusToCheck;

            /// <summary>
            /// Carousel Images Source Path
            /// </summary>
            public static readonly string CarouselImagesSourcePath;

            /// <summary>
            /// Carousel Images Number to be displayed
            /// </summary>
            public static readonly int CarouselImagesNumber;

            /// <summary>
            /// Default Email address to be used for 'From'
            /// </summary>
            public static readonly string DefaultEmailFromAddress;

            /// <summary>
            /// Email address to be used for sending email to when an exception occurs  
            /// </summary>
            public static readonly string ExceptionEmailToAddress;

            /// <summary>
            /// period for which a security stamp will be valid
            /// </summary>
            public static readonly int SecurityStampValidityPeriod;

            /// <summary>
            /// lear about training courses url.
            /// </summary>
            public static readonly string LearnAboutTrainingCoursesUrl;


            /// <summary>
            /// File types allowed for company logo
            /// </summary>
            public static readonly string FileTypesAllowedForCompanyLogo;

            /// <summary>
            /// File types allowed for company document
            /// </summary>
            public static readonly string FileTypesAllowedForCompanyDocument;

            /// <summary>
            /// Max file size allowed for company document uploader
            /// </summary>
            public static readonly int MaxFileSizeForCompanyDocumentUploader;


            /// <summary>
            /// Max file size allowed for company logo
            /// </summary>
            public static readonly int MaxFileSizeForCompanyLogo;

            /// <summary>
            /// GridPageSize
            /// </summary>
            public static readonly string GridPageSize;

            /// <summary>
            /// ExportedReportsPath
            /// </summary>
            public static readonly string ExportedReportsPath;

            /// <summary>
            /// The TMCRelativePath
            /// </summary>
            public static readonly string TMCRelativePath;

            /// <summary>
            /// Scheduler constants
            /// </summary>
            public static readonly string JobTriggerTimeSpan;

            /// <summary>
            /// QueuedRawPositionImportJobTriggerTimeSpan
            /// </summary>
            public static readonly string QueuedRawPositionImportJobTriggerTimeSpan;

            /// <summary>
            /// The debug mode.
            /// </summary>
            public static readonly string DebugMode;

            /// <summary>
            /// Enable employee required certificates Export job.
            /// </summary>
            public static readonly string EnableEmployeeRequiredCertificatesExportJob;

            /// <summary>
            /// Enable Enable Queued Email Sending Job.
            /// </summary>
            public static readonly string EnableQueuedEmailSendingJob;

            /// <summary>
            /// Enable Enable Queued Sms Sending Job.
            /// </summary>
            public static readonly string EnableQueuedSmsSendingJob;
            public static readonly string EnableQueuedRawPositionImportJob;
            

            #region Cookie Parameters
            public static readonly string UserNameCookieParameter = ConfigurationManager.AppSettings["UserNameCookieParameter"];
            public static readonly string PasswordCookieParameter = ConfigurationManager.AppSettings["PasswordCookieParameter"];
            public static readonly string UserApplicationCookieName = ConfigurationManager.AppSettings["UserApplicationCookieName"];

            #endregion

            #region FCM Parameters
            public static readonly string FCMServerAPIKey 
                = ConfigurationManager.AppSettings["FCMServerAPIKey"];
            public static readonly string FCM_SENDER_ID 
                = ConfigurationManager.AppSettings["FCM_SENDER_ID"];
            public static readonly string FCMToken 
                = ConfigurationManager.AppSettings["FCMToken"];
            public static readonly string FCMSendUrl
                = ConfigurationManager.AppSettings["FCMSendUrl"];

            #endregion

            #endregion

            #region Service Urls

            public static readonly string ResourceManagementServiceUrl = ConfigurationManager.AppSettings["ResourceManagementServiceUrl"];
            public static readonly string SiteManagementServiceUrl = ConfigurationManager.AppSettings["SiteManagementServiceUrl"];
            public static readonly string UserManagementServiceUrl = ConfigurationManager.AppSettings["UserManagementServiceUrl"];
            public static readonly string RequestManagementServiceUrl = ConfigurationManager.AppSettings["RequestManagementServiceUrl"];
            public static readonly string EncryptDecryptServiceUrl = ConfigurationManager.AppSettings["EncryptDecryptServiceUrl"];
            public static readonly string TokenServiceUrl = ConfigurationManager.AppSettings["TokenServiceUrl"];
            #endregion

            #region token
            public static readonly string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            public static readonly string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            #endregion

            public static readonly long EntityType = Convert.ToInt64(ConfigurationManager.AppSettings["EntityType"]);


            #region "Constructor"

            static T GetAppSetting<T>(string key)
            {
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
            }

            static ConfigurationKeys()
            {
                WebApiUrl = GetAppSetting<string>("WebApiBaseUrl") + "api/services/" + GetAppSetting<string>("WebApiVersion") + "/";
                IdentityUrl = GetAppSetting<string>("IdentityServerBaseUrl") + "api/identity/" + GetAppSetting<string>("WebApiVersion") + "/";
                WebApiBaseUrl = GetAppSetting<string>("WebApiBaseUrl");
                AppBaseUrl = GetAppSetting<string>("AppBaseUrl");
                PatientMediaPath = GetAppSetting<string>("PatientMediaPath");
                ProfileImagePath = GetAppSetting<string>("ProfileImagePath");
                EnableResourceOptimization = GetAppSetting<string>("EnableResourceOptimization");
                FacebookAppToken = GetAppSetting<string>("FacebookAppToken");
                FacebookAccessToken = GetAppSetting<string>("FacebookAccessToken");
                FacebookAppId = GetAppSetting<string>("FacebookAppId");

                FacebookMobileAppId = GetAppSetting<string>("FacebookMobileAppId");
                FacebookMobileAppToken = GetAppSetting<string>("FacebookMobileAppToken");


                FacebookAppSecret = GetAppSetting<string>("FacebookAppSecret");

                DriverDefaultMobileNumber = GetAppSetting<string>("DriverDefaultMobileNumber");

                //location
                VehiclesExchangeName = GetAppSetting<string>("VehiclesExchangeName");
                VehiclesRoutingKeyPrefix = GetAppSetting<string>("VehiclesRoutingKeyPrefix");



                if (ConfigurationManager.AppSettings.AllKeys.Contains("OutputBinFolderName"))
                {
                    OutputBinFolderName = ConfigurationManager.AppSettings["OutputBinFolderName"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("GoogleClientId"))
                {
                    GoogleClientId = ConfigurationManager.AppSettings["GoogleClientId"];
                }
                
                if (ConfigurationManager.AppSettings.AllKeys.Contains("GoogleMobileClientId"))
                {
                    GoogleMobileClientId = ConfigurationManager.AppSettings["GoogleMobileClientId"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("GoogleClientSecret"))
                {
                    GoogleClientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("AccessTokenExpireTimeInMinutes"))
                {
                    AccessTokenExpireTimeInMinutes = ConfigurationManager.AppSettings["AccessTokenExpireTimeInMinutes"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("JobTriggerTimeSpan"))
                {
                    JobTriggerTimeSpan = ConfigurationManager.AppSettings["JobTriggerTimeSpan"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("QueuedRawPositionImportJobTriggerTimeSpan"))
                {
                    QueuedRawPositionImportJobTriggerTimeSpan = ConfigurationManager.AppSettings["QueuedRawPositionImportJobTriggerTimeSpan"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("DebugMode"))
                {
                    DebugMode = ConfigurationManager.AppSettings["DebugMode"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsDevelopment"))
                {
                    IsDevelopment = Convert.ToBoolean(ConfigurationManager.AppSettings["IsDevelopment"]);
                }
                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsThrottlingEnabled"))
                {
                    IsThrottlingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["IsThrottlingEnabled"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsTestMail"))
                {
                    IsTestMail = ConfigurationManager.AppSettings["IsTestMail"];
                }


                if (ConfigurationManager.AppSettings.AllKeys.Contains("LocationDataPushIntervalInMiliseconds"))
                {
                    LocationDataPushIntervalInMiliseconds = Convert.ToDouble(ConfigurationManager.AppSettings["LocationDataPushIntervalInMiliseconds"]);
                }

                PositionExchangeName = GetAppSetting<string>("PositionExchangeName");                
                PositionRoutingKeyPrefix = GetAppSetting<string>("PositionRoutingKeyPrefix");
                PositionRoutingKey = GetAppSetting<string>("PositionRoutingKey");
                
                DatabaseCollectionName = GetAppSetting<string>("DatabaseCollectionName");
                PositionNotificationQueueName = GetAppSetting<string>("PositionNotificationQueueName");
                PositionPersistenceQueueName = GetAppSetting<string>("PositionPersistenceQueueName");
                
                LocationQueueName = GetAppSetting<string>("LocationQueueName");
                QueueHostName = GetAppSetting<string>("QueueHostName");
                QueueUserName = GetAppSetting<string>("QueueUserName");
                QueuePassword = GetAppSetting<string>("QueuePassword");
                QueueProtocol = GetAppSetting<string>("QueueProtocol");

                NotificationExchangeName = GetAppSetting<string>("NotificationExchangeName");
                NotificationRoutingKeyPrefix = GetAppSetting<string>("NotificationRoutingKeyPrefix");
                NotificationRoutingKey = GetAppSetting<string>("NotificationRoutingKey");
                NotificationQueueName = GetAppSetting<string>("NotificationQueueName");
                

                if (ConfigurationManager.AppSettings.AllKeys.Contains("QueuePort"))
                {
                    QueuePort = Convert.ToInt32(ConfigurationManager.AppSettings["QueuePort"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("OutputBinFolderName"))
                {
                    OutputBinFolderName = ConfigurationManager.AppSettings["OutputBinFolderName"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("RedisCachingConnectionString"))
                {
                    RedisCachingConnectionString = ConfigurationManager.AppSettings["RedisCachingConnectionString"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("RedisCachingEnabled"))
                {
                    RedisCachingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["RedisCachingEnabled"]);
                }
                //Location

                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsStoringInMongo"))
                {
                    IsStoringInMongo = Convert.ToBoolean(ConfigurationManager.AppSettings["IsStoringInMongo"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsSimulating"))
                {
                    IsSimulating = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSimulating"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("TokenExpirationLifetimeInDays"))
                {
                    TokenExpirationLifetimeInDays = Convert.ToDouble(ConfigurationManager.AppSettings["TokenExpirationLifetimeInDays"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("InstanceCountLocationQueueConsumers"))
                {
                    InstanceCountLocationQueueConsumers = Convert.ToInt16(ConfigurationManager.AppSettings["InstanceCountLocationQueueConsumers"]);
                }








                if (ConfigurationManager.AppSettings.AllKeys.Contains("CompanyProfileImagesUploadFolderPath"))
                {
                    CompanyProfileImagesUploadFolderPath = ConfigurationManager.AppSettings["CompanyProfileImagesUploadFolderPath"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("SSOIsLoggedInUrl"))
                {
                    SSOIsLoggedInUrl = ConfigurationManager.AppSettings["SSOIsLoggedInUrl"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("SSOLoginUrl"))
                {
                    SSOLoginUrl = ConfigurationManager.AppSettings["SSOLoginUrl"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("SSOLogoutUrl"))
                {
                    SSOLogoutUrl = ConfigurationManager.AppSettings["SSOLogoutUrl"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("MaxInvalidLogOnAttempts"))
                {
                    MaxInvalidLogOnAttempts = Convert.ToInt16(ConfigurationManager.AppSettings["MaxInvalidLogOnAttempts"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("MaxTimeForLockedAccount"))
                {
                    MaxTimeForLockedAccount = Convert.ToInt16(ConfigurationManager.AppSettings["MaxTimeForLockedAccount"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("UserStatusToCheck"))
                {
                    UserStatusToCheck = Convert.ToInt16(ConfigurationManager.AppSettings["UserStatusToCheck"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("CarouselImagesSourcePath"))
                {
                    CarouselImagesSourcePath = ConfigurationManager.AppSettings["CarouselImagesSourcePath"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("CarouselImagesNumber"))
                {
                    CarouselImagesNumber = Convert.ToInt32(ConfigurationManager.AppSettings["CarouselImagesNumber"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("EnableEmployeeRequiredCertificatesExportJob"))
                {
                    EnableEmployeeRequiredCertificatesExportJob = ConfigurationManager.AppSettings["EnableEmployeeRequiredCertificatesExportJob"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("EnableQueuedEmailSendingJob"))
                {
                    EnableQueuedEmailSendingJob = ConfigurationManager.AppSettings["EnableQueuedEmailSendingJob"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("EnableQueuedSmsSendingJob"))
                {
                    EnableQueuedSmsSendingJob = ConfigurationManager.AppSettings["EnableQueuedSmsSendingJob"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("EnableQueuedRawPositionImportJob"))
                {
                    EnableQueuedRawPositionImportJob = ConfigurationManager.AppSettings["EnableQueuedRawPositionImportJob"];
                }
                
                if (ConfigurationManager.AppSettings.AllKeys.Contains("DefaultEmailFromAddress"))
                {
                    DefaultEmailFromAddress = ConfigurationManager.AppSettings["DefaultEmailFromAddress"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("ExceptionEmailToAddress"))
                {
                    ExceptionEmailToAddress = ConfigurationManager.AppSettings["ExceptionEmailToAddress"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("SecurityStampValidityPeriod"))
                {
                    SecurityStampValidityPeriod = Convert.ToInt32(ConfigurationManager.AppSettings["SecurityStampValidityPeriod"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("LearnAboutTrainingCoursesUrl"))
                {
                    LearnAboutTrainingCoursesUrl = ConfigurationManager.AppSettings["LearnAboutTrainingCoursesUrl"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("FileTypesAllowedForCompanyLogo"))
                {
                    FileTypesAllowedForCompanyLogo = ConfigurationManager.AppSettings["FileTypesAllowedForCompanyLogo"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("FileTypesAllowedForCompanyDocument"))
                {
                    FileTypesAllowedForCompanyDocument = ConfigurationManager.AppSettings["FileTypesAllowedForCompanyDocument"];
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("MaxFileSizeAllowedForCompanyDocumentUploader"))
                {
                    MaxFileSizeForCompanyDocumentUploader = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSizeAllowedForCompanyDocumentUploader"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("MaxFileSizeForCompanyLogo"))
                {
                    MaxFileSizeForCompanyLogo = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSizeForCompanyLogo"]);
                }

                if (ConfigurationManager.AppSettings.AllKeys.Contains("GridPageSize"))
                {
                    GridPageSize = ConfigurationManager.AppSettings["GridPageSize"];
                }
            }

            #endregion
        }

        public struct EMAILREDIRECTIONURL
        {
            public static readonly string ReturnToDashboard = "returnToDashboard";
        }

        public struct Common
        {
            public static readonly string Url = "http://{0}/{1}";
            public static readonly string DataNotAvailable = "DataNotAvailable";
            public static readonly string PrintBodyPlaceholder = "pl_PrintBody";
            public static readonly char UnderScore = '_';
            public static readonly char Comma = ',';
        }

        public static class Delimiters
        {
            public const string StartDelimiter = "##";
            public const string EndDelimiter = "##";
        }
    }
}
