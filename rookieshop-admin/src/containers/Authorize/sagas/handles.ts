import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import { Status } from "src/constants/status";
import IError from "src/interfaces/IError";

import { setAccount, setStatus } from "../reducer";
import { 
    loginRequest, 
    getMeRequest, 
    logoutRequest, 
    loginCallbackRequest, 
    logoutCallbackRequest 
} from './requests';
import { HOME, UNAUTHORIZE } from "src/constants/pages";

export function* handleLogin() {
    try {
        const {data} = yield call(loginRequest);
    } catch (error) {
        const errorModel = error?.response?.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleLoginCallback() {
    try {
        const data = yield call(loginCallbackRequest);

        yield put(setAccount(data));

    } catch (error) {
        const errorModel = error?.response?.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
  }

export function* handleGetMe() {
    try {
        const data = yield call(getMeRequest);

        if (data?.access_token) {
            yield put(setAccount(data));
        }

    } catch (error) {
        console.log(error);
        const errorModel = error?.response?.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleLogout() {
    try {
        yield call(logoutRequest);
    } catch (error) {
        const errorModel = error?.response?.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleLogoutCallback() {
    try {
        yield call(logoutCallbackRequest);
    } catch (error) {
        const errorModel = error?.response?.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

