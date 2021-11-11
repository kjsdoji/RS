import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";

import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IQueryCategoryModel from "../../interfaces/Category/IQueryCategoryModel";
import ICategory from "../../interfaces/Category/ICategory";
import ICategoryForm from "../../interfaces/Category/ICategoryForm";

type CategoryState = {
    loading: boolean;
    categoryResult?: ICategory;
    categories: IPagedModel<ICategory> | null;
    status?: number;
    error?: IError;
    disable: boolean;
}

export type CreateAction = {
    handleResult: Function,
    formValues: ICategoryForm,
}

export type DisableAction = {
    handleResult: Function,
    categoryId: number,
}

const initialState: CategoryState = {
    categories: null,
    loading: false,
    disable: false,
};

const categoryReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getCategories: (state, action: PayloadAction<IQueryCategoryModel>): CategoryState => {

            return {
                ...state,
                loading: true,
            }
        },
        setCategories: (state, action: PayloadAction<IPagedModel<ICategory>>): CategoryState => {
            const categories = action.payload;

            return {
                ...state,
                categories,
                loading: false,
            }
        },
        createCategory: (state, action: PayloadAction<CreateAction>): CategoryState => {
            return {
                ...state,
                loading: true,
            }
        },
        updateCategory: (state, action: PayloadAction<CreateAction>): CategoryState => {
            return {
                ...state,
                loading: true,
            }
        },
        disableCategory: (state, action: PayloadAction<DisableAction>): CategoryState => {
            return {
                ...state,
                loading: true,
            }
        },
        setCategory: (state, action: PayloadAction<ICategory>): CategoryState => {
            const categoryResult = action.payload;

            return {
                ...state,
                categoryResult,
                loading: false,
            }
        },
        setStatus: (state, action: PayloadAction<SetStatusType>): CategoryState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
        cleanUp: (state): CategoryState => ({
            ...state,
            loading: false,
            categoryResult: undefined,
            status: undefined,
            error: undefined,
        }),
    }
});

export const {
    createCategory, setCategory, setStatus, cleanUp,  getCategories, setCategories, updateCategory, disableCategory
} = categoryReducerSlice.actions;

export default categoryReducerSlice.reducer;
