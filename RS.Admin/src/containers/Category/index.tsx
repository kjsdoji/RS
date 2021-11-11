import React, { lazy } from 'react';
import { Route, Switch } from 'react-router-dom';

import { CREATE_CATEGORY, CATEGORY, EDIT_CATEGORY } from '../../constants/pages';
import LayoutRoute from '../../routes/LayoutRoute';

const NotFound = lazy(() => import("../NotFound"));
const CreateCategory = lazy(() => import("./Create"));
const ListCategory = lazy(() => import("./List"));
const UpdateCategory = lazy(() => import("./Update"))

const Category = () => {
    return (
        <Switch>
            <Route exact path={CATEGORY}>
                <ListCategory />
            </Route>

            <Route exact path={CREATE_CATEGORY}>
                <CreateCategory />
            </Route>

            <Route exact path={EDIT_CATEGORY}>
                <UpdateCategory />
            </Route>

            <Route component={NotFound} />
        </Switch>
    )
};

export default Category;