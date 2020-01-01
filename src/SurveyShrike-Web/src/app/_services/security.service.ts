import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { UserRole } from '../_models/security';
import { LocalStorageKeys } from '../shared/constant';
import { Helper } from './helper.service';

export interface AuthToken {
    token: string;
}

@Injectable()
export class SecurityService {

    constructor(private authService: AuthService,
    private helper: Helper) { }

    public isInRole(key: string): boolean {
        return this.isRoleExist(key);
    }

    public getCurrentUserRole(): UserRole {
       let currentRole = '';
        const user = this.helper.getObjectFromLocalStorage(LocalStorageKeys.User);
        if (user && user.roles) {
            const roles = user.roles.split(',');
            roles.splice(roles.indexOf(UserRole.User), 1 );
            currentRole = roles[0];
        }

        if (!currentRole) {
            currentRole = user.roles;
        }
        return currentRole;
    }

    private isRoleExist(checkRole: string) {
        let isRole = false;
        const user = this.helper.getObjectFromLocalStorage(LocalStorageKeys.User);
        if (user && user.roles) {
            const roles = user.roles.toLocaleLowerCase().split(',');
            isRole = roles.indexOf(checkRole.toLowerCase()) > -1;
        }
        return isRole;
    }
 
}
