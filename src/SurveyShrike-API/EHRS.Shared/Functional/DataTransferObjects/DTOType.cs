
using EHRS.Shared;

namespace EHRS.Shared
{
    /// <summary>
    /// DTO Type
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.AllergyDTO")]
        Allergy = 1,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PatientTreatmentLogsDTO")]
        PatientTreatmentLogs = 2, 

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.TreatmentLogDTO")]
        TreatmentLog = 3,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.TreatmentLogParametersDTO")]
        TreatmentLogParameters = 4,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PatientParametersDTO")]
        PatientParameters = 5,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PatientSortParamsDTO")]
        PatientSortParams = 6,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PatientDTO")]
        Patient = 7,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PatientSearchDTO")]
        PatientSearch = 8,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.AppSettingsDTO")]
        AppSettings = 9,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SubscriptionDTO")]
        Subscription = 10,
 
        /// <summary>
        /// The User DTO
        /// </summary>
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.UserDTO")]
        User = 11,

        /// <summary>
        /// The File DTO
        /// </summary>
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.FileDTO")]
        File = 12,
 
        /// <summary>
        /// The City DTO
        /// </summary>
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.CityDTO")]
        City = 13,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.ContactDTO")]
        Contact = 14,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.MediaDTO")]
        Media = 15,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.ReviewDTO")]
        Review = 16,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.TokenDTO")]
        Token = 17,
 
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SortingParamsDTO")]
        SortingParams = 18,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PagingParamsDTO")]
        PagingParams = 19, 
        
        /// <summary>
        /// The Communication DTO
        /// </summary>
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.CommunicationDTO")]
        Communication = 20,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.FilterParamsDTO")]
        FilterParams = 21,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SuggestionDTO")]
        Suggestion = 22,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.FileVersionDTO")]
        FileVersion = 23,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.FileExtensionTypeDTO")]
        FileExtensionType = 24,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.FileTypeDTO")]
        FileType = 25,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.NotificationDTO")]
        Notification = 26,

        /// <summary>
        /// The AspNetUserProperties DTO
        /// </summary>
        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.UserPropertiesDTO")]
        UserProperties = 27,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.StudentDTO")]
        Student = 28,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.ParentDTO")]
        Parent = 29,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.VerificationCodeDTO")]
        VerificationCode = 30,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.AddressDTO")]
        Address = 31,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.GradeDTO")]
        Grade = 32,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SchoolGradeDTO")]
        SchoolGrade = 33,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SectionDTO")]
        Section = 34,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.QueuedSmsDTO")]
        QueuedSms = 35,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SmsAccountDTO")]
        SmsAccount = 36,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.QueuedEmailDTO")]
        QueuedEmail = 37,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.EmailAccountDTO")]
        EmailAccount = 38,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.ContactUsDTO")]
        ContactUs = 39,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PositionDTO")]
        Position = 40,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.DeviceDTO")]
        Device = 41,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.VehicleDTO")]
        Vehicle = 42,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.LocationDataFilterDTO")]
        LocationDataFilter = 43,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.LocationDTO")]
        Location = 44,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SmsTemplateDTO")]
        SmsTemplate = 45,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PositionDataFilterDTO")]
        PositionDataFilter = 46,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.NotificationRecipientDTO")]
        NotificationRecipient = 47,


        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.StudentGradeDTO")]
        StudentGrade = 48,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SessionDTO")]
        Session = 49,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.RawPositionDTO")]
        RawPosition = 50,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.PositionBundledDTO")]
        PositionBundled = 51,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.GroupDTO")]
        Group = 52,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.EmailTemplateDTO")]
        EmailTemplate = 53,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.UserVerificationDetailDTO")]
        UserVerificationDetail = 54,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.HelperContentDTO")]
        HelperContent = 55,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.HelperBulletDTO")]
        HelperBullet = 56,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SchoolDTO")]
        School = 57,

        [QualifiedTypeName("EHRS.DTOModel.dll", "EHRS.DTOModel.SurveyDTO")]
        Survey = 58
    }
}
