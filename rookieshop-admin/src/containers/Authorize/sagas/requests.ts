import { AxiosResponse } from "axios";
import { User } from "oidc-client";

import RequestService from 'src/services/request';
import AuthService from 'src/services/auth-service';
import EndPoints from 'src/constants/endpoints';
import ILoginModel from "src/interfaces/ILoginModel";
import IAccount from "src/interfaces/IAccount";
import IChangePassword from "src/interfaces/IChangePassword";

export function loginRequest(): Promise<void> {
    return AuthService.loginAsync();
}

export function loginCallbackRequest(): Promise<User | undefined> {
    return AuthService.completeLoginAsync(window.location.href);
}

export function getMeRequest(): Promise<User | null> {
    return AuthService.getUserAsync();
}

export function logoutRequest(): Promise<void> {
    return AuthService.logoutAsync();
}

export function logoutCallbackRequest(): Promise<void> {
    return AuthService.completeLogoutAsync(window.location.href);
}


