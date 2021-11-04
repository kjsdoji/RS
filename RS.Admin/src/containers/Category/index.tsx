import React, { lazy } from 'react';
import { Route, Switch } from 'react-router-dom';

import { CREATE_BRAND, CATEGORY, EDIT_BRAND } from '../../constants/pages';
import LayoutRoute from '../../routes/LayoutRoute';

const NotFound = lazy(() => import("../NotFound"));
const CreateBrand = lazy(() => import("./Create"));
const ListBrand = lazy(() => import("./List"));
const UpdateBrand = lazy(() => import("./Update"))

const Brand1 = () => {
    return (
        <Switch>
            <Route exact path={CATEGORY}>
                <ListBrand />
            </Route>

            <Route exact path={CREATE_BRAND}>
                <CreateBrand />
            </Route>

            <Route exact path={EDIT_BRAND}>
                <UpdateBrand />
            </Route>

            <Route component={NotFound} />
        </Switch>
    )
};

export default Brand1;