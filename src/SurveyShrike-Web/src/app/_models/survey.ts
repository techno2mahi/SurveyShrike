 
export interface ISurvey  {
    id: number;
    surveyTitle: string;
    createdOn: Date;
    createdBy: string 
    formFields: Array<IFormField>;
}

export class Survey implements ISurvey {
    id: number;
    surveyTitle: string;
    createdOn: Date;
    createdBy: string 
    formFields: Array<IFormField>; 
}
 

export interface IFormField  {
    id: number;
    surveyId: string;
    createdOn: Date;
    createdBy: string 
    formType: number;
}