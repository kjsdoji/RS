import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IBrandForm from "../../../interfaces/Brand/IBrandForm";
import IBrand from "../../../interfaces/Brand/IBrand";
import IQueryBrandModel from "../../../interfaces/Brand/IQueryBrandModel";

export function createBrandRequest(brandForm: IBrandForm): Promise<AxiosResponse<IBrand>> {
    const formData = new FormData();

    Object.keys(brandForm).forEach(key => {
        formData.append(key, brandForm[key]);
    });

    return RequestService.axios.post(EndPoints.brand, formData);
}

export function getBrandsRequest(query: IQueryBrandModel): Promise<AxiosResponse<IBrand>> {
    return RequestService.axios.get(EndPoints.brand, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function UpdateBrandRequest(brandForm: IBrandForm): Promise<AxiosResponse<IBrand>> {
    const formData = new FormData();

    Object.keys(brandForm).forEach(key => {
        formData.append(key, brandForm[key]);
    });

    return RequestService.axios.put(EndPoints.brandId(brandForm.id ?? - 1), formData);
}

export function DisableBrandRequest(brandId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.brandId(brandId));
}