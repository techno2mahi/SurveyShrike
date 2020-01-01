
export class AppSettings {

  private static API_IdentityBase = 'http://localhost:44442';
  private static API_WebAPIBase = 'http://localhost:44444';

  public static API_Login = AppSettings.API_IdentityBase + '/token';
  public static API_Register = AppSettings.API_IdentityBase + '/api/identity/v1/account/Register';
  
  public static API_LogOut = AppSettings.API_IdentityBase + '/api/identity/v1/logout';
  public static API_GetUser = AppSettings.API_IdentityBase + '/api/identity/v1/account/GetUser';
  
  public static API_AddSurvey = AppSettings.API_WebAPIBase + '/api/services/v1/surveyApi';
  public static API_UpdateSurvey = AppSettings.API_WebAPIBase + '/api/services/v1/surveyAPI/{:id}';

  public static API_GetSurveys = AppSettings.API_WebAPIBase + '/api/v1/surveys';

  public static API_GetSurveyById = AppSettings.API_WebAPIBase + '/api/v1/surveys/{:id}';
}



export class AppURLs {
  public static home = '/';
  public static login = '/login';
  public static logout = '/logout';
  public static dashboard = '/dashboard';
  public static profile = AppURLs.dashboard + '/profile';
  public static manageSurveys = AppURLs.dashboard + '/manage-survey';
  public static viewSurveyDetail = AppURLs.dashboard + '/view-survey';
  public static addUpdateSurvey = AppURLs.dashboard + '/add-update-survey';
}

export class LocalStorageKeys {
  public static User = 'currentUser';
  public static AuthToken = 'authToken';
  public static Survey = 'survey';
  public static Child = 'child';
}

export class ValidationConstants {
  public static PhoneNotConfirmed = 'phone_unconfirmed';
}

export class SnackToastAction {
  public static Success = 'Success';
  public static Error = 'Error';
  public static Warning = 'Warning';
}

export class Messages {
  public static Offline = 'No network connection';
  public static Online = 'Now connected';
}

export class Constants {
  public static NoAvatar = 'assets/images/noavatar.png';
}



export enum ForgotPasswordView {
  Default = 0,
  VerifyAndSubmit = 1,
  EmailSent = 2
}

export enum AccountView {
  Default = 0
}


export enum Gender {
  Male = 1,
  Female = 2,
  Other = 3
}
