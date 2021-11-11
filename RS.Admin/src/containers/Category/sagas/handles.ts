import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import { Status } from "../../../constants/status";

import IError from "../../../interfaces/IError";
import IQueryCategoryModel from "../../../interfaces/Category/IQueryCategoryModel";
import { setCategory, disableCategory, CreateAction, setCategories, setStatus, DisableAction } from "../reducer";

import { createCategoryRequest, DisableCategoryRequest, getCategoriesRequest, UpdateCategoryRequest } from './requests';
import ICategory from "../../../interfaces/Category/ICategory";

export function* handleCreateCategory(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        console.log('handleCreateCategory');
        console.log(formValues);
        
        const { data } = yield call(createCategoryRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setCategory(data));
        
    } catch (error) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetCategories(action: PayloadAction<IQueryCategoryModel>) {
    const query = action.payload;
    try {
        console.log('handleGetCategories');
        console.log(query);
        const { data } = yield call(getCategoriesRequest, query);
        
        console.log(data);
        yield put(setCategories(data));

    } catch (error) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleUpdateCategory(action : PayloadAction<CreateAction>){
    const { handleResult, formValues } = action.payload; 

    try {
        const { data } = yield call(UpdateCategoryRequest, formValues);

        handleResult(true, data.name.toString());
        
        yield put(setCategory(data));

    }catch (error) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDisableCategory(action: PayloadAction<DisableAction>) {
    const { handleResult, categoryId } = action.payload;

    try {
        const {data} = yield call(DisableCategoryRequest, categoryId);

        handleResult(data, '');

    } catch (error) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
