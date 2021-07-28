import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User } from "oidc-client";

import Roles from "src/constants/roles";
import { SetStatusType } from "src/constants/status";
import IError from "src/interfaces/IError";
import request from "src/services/request";
import { getLocalStorage, removeLocalStorage, setLocalStorage } from "src/utils/localStorage";

type AuthState = {
    loading: boolean;
    isAuth: boolean,
    account?: User;
    status?: number;
    error?: IError;
}

const token = getLocalStorage('token');

const initialState: AuthState = {
    account: undefined,
    isAuth: false,
    loading: false,
};

const AuthSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAccount: (state: AuthState, action: PayloadAction<User>): AuthState => {
            const account = action.payload;
            
            if (account?.profile?.role === Roles.Admin && account?.access_token) {
                setLocalStorage('token', account?.access_token);
                request.setAuthentication(account?.access_token);

                return {
                    ...state,
                    account,
                    isAuth: true,
                    loading: false,
                };
            }

            return {
                ...state,
                account,
                isAuth: true,
                loading: false,
            };
        },
        setStatus: (state: AuthState, action: PayloadAction<SetStatusType>) =>
        {
            const {status, error} = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
        me: (state) => {
            if (token) {
                request.setAuthentication(token);
            }
        },
        login: (state: AuthState) => ({
            ...state,
            loading: true,
        }),
        logout: (state: AuthState) => {

            removeLocalStorage('token');
            request.setAuthentication('')

            return {
                ...state,
                isAuth: false,
                account: undefined,
                status: undefined,
            };
        },
        cleanUp: (state) => ({
            ...state,
            loading: false,
            status: undefined,
            error: undefined,
            isAuth: false
        }),
        loginCallback: (state: AuthState) => ({
            ...state,
            loading: false,
            isAuth: true
        }),
        logoutCallback: (state: AuthState) => ({
            ...state,
            loading: false,
            isAuth: false
        }),
    }
});

export const {
    setAccount, login, setStatus, me, logout, cleanUp, loginCallback, logoutCallback
} = AuthSlice.actions;

export default AuthSlice.reducer;
