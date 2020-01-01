import { ISurvey } from './survey';

export interface IUserProfile {
    userId: string;
    firstName: string;
    lastName: string;
    email: string;
    mobileNo: string;
    emailConfirmed: boolean;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    userName: string;
    addressLine1: string;
    addressLine2: string;
    cityId?: number;
    city: string;
    areaId: string;
    pinCode?: number;
    password: string;
    userTypeId: string;
    joinedDate: string;
    fullName: string;
    gender: number;
    userProperties: UserProperties;
}

export class UserProfile implements IUserProfile {
    userId: string;
    firstName: string;
    lastName: string;
    email: string;
    mobileNo: string;
    emailConfirmed: boolean;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    userName: string;
    addressLine1: string;
    addressLine2: string;
    cityId?: number;
    city: string;
    areaId: string;
    pinCode?: number;
    gender: number;
    password: string;
    userTypeId: string;
    joinedDate: string;
    fullName: string;
    userProperties: UserProperties;

    public constructor() {
        this.userId = '';
        this.firstName = '';
        this.lastName = '';
        this.email = '';
        this.mobileNo = '';
        this.emailConfirmed = false;
        this.phoneNumber = '';
        this.phoneNumberConfirmed = false;
        this.userName = '';
        this.addressLine1 = '';
        this.addressLine2 = '';
        this.city = '';
        this.areaId = '';
        this.password = '';
        this.userTypeId = '';
        this.joinedDate = '';
        this.fullName = '';
        this.userProperties = null;
    }
}

export interface IUserProperties {
    profileMediaId: number;
    fcmRegToken: string;
}

export class UserProperties implements IUserProperties {
    profileMediaId: number;
    fcmRegToken: string;

    public constructor() {
        this.profileMediaId = 0;
        this.fcmRegToken = '';
    }
}

export interface IUser {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
}

export class User implements IUser {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;

    public constructor() {
        this.id = 0;
        this.username = '';
        this.password = '';
        this.firstName = '';
        this.lastName = '';
    }
}

export interface IForgotPassword {
    emailOrPhone: string;
    code: string;
    password: string;
    confirmPassword: string;
}

export class ForgotPassword implements IForgotPassword {
    emailOrPhone: string;
    code: string;
    password: string;
    confirmPassword: string;
    public constructor() {
        this.emailOrPhone = '';
        this.code = '';
        this.password = '';
        this.confirmPassword = '';
    }
}

export interface IResetPassword {
    userId: string;
    code: string;
    newPassword: string;
}

export class ResetPassword implements IResetPassword {
    userId: string;
    code: string;
    newPassword: string;
    public constructor() {
        this.userId = '';
        this.code = '';
        this.newPassword = '';
    }
}

export interface IChangePassword  {
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
}

export class ChangePassword implements IChangePassword {
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
    public constructor() {
        this.oldPassword = '';
        this.newPassword = '';
        this.confirmPassword = '';
    }
}

export interface IVerifyUser {
    verificationCode: string;
    isCorrect: boolean;
    reason?: string;
}

export class VerifyUser implements IVerifyUser {
    verificationCode: string;
    isCorrect: boolean;
    reason?: string;

    public constructor() {
        this.verificationCode = '';
        this.isCorrect = false;
    }
}

  
export interface IRole {
    roleId: number;
    roleName: string;
    roleDescription: string;
}

export class Role implements IRole {
    roleId: number;
    roleName: string;
    roleDescription: string;

    public constructor() {
        this.roleId = 0;
        this.roleName = '';
        this.roleDescription = '';
    }
}

export interface IUserRole {
    username: string;
    roleName: string;
}

export class UserRole implements IUserRole {
    username: string;
    roleName: string;

    public constructor() {
        this.username = '';
        this.roleName = '';
    }
}

export interface IRoleUsers {
    id: string;
    EnrolledUsers: string[];
    RemovedUsers: string[];
}

export class RoleUsers implements IRoleUsers {
    id: string;
    EnrolledUsers: string[];
    RemovedUsers: string[];

    public constructor() {
        this.id = '';
        this.EnrolledUsers = Array<string>();
        this.RemovedUsers = Array<string>();
    }
}

export interface IUserRoles {
    userName: string;
    roles: string[];
}

export class UserRoles implements IUserRoles {
    userName: string;
    roles: string[];

    public constructor() {
        this.userName = '';
        this.roles = Array<string>();
    }
}
