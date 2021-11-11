import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import ICategoryForm from "../../../interfaces/Category/ICategoryForm";
import ICategory from "../../../interfaces/Category/ICategory";
import IQueryCategoryModel from "../../../interfaces/Category/IQueryCategoryModel";

export function createCategoryRequest(categoryForm: ICategoryForm): Promise<AxiosResponse<ICategory>> {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.post(EndPoints.category, formData);
}

export function getCategoriesRequest(query: IQueryCategoryModel): Promise<AxiosResponse<ICategory>> {
    return RequestService.axios.get(EndPoints.category, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function UpdateCategoryRequest(categoryForm: ICategoryForm): Promise<AxiosResponse<ICategory>> {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.put(EndPoints.categoryId(categoryForm.id ?? - 1), formData);
}

export function DisableCategoryRequest(categoryId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.categoryId(categoryId));
}