import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from '../../components/FormInputs/TextField';
import DateField from '../../components/FormInputs/DateField';
import CheckboxField from '../../components/FormInputs/CheckboxField';
import SelectField from '../../components/FormInputs/SelectField';
import { CATEGORY } from '../../constants/pages';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { createCategory, updateCategory } from './reducer';
import ICategoryForm from '../../interfaces/Category/ICategoryForm';
import {Status} from '../../constants/status';
import { NormalBrandType } from "../../constants/Brand/BrandConstants";
import { BrandTypeOptions } from "../../constants/selectOptions";
import FileUpload from '../../components/FormInputs/FileUpload';

const initialFormValues: ICategoryForm = {
    name: ''
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required')
});

type Props = {
    initialCategoryForm?: ICategoryForm;
};

const CategoryFormContainer: React.FC<Props> = ({ initialCategoryForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialCategoryForm.id ? true : false;

    const history = useHistory();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Category ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(CATEGORY);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <Formik
            initialValues={initialCategoryForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(updateCategory({ handleResult, formValues: values }));
                    }
                    else {
                        dispatch(createCategory({ handleResult, formValues: values }));
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => (
                <Form className='intro-y col-lg-6 col-12'>
                    <TextField 
                        name="name" 
                        label="Name" 
                        placeholder="input category name" 
                        disabled={isUpdate ? true : false} />



                    <div className="d-flex">
                        <div className="ml-auto">
                            <button className="btn btn-danger"
                                type="submit" disabled={loading}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to={CATEGORY} className="btn btn-outline-secondary ml-2">
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default CategoryFormContainer;
