import React, { Suspense, useEffect } from "react";
import { Redirect, Route } from "react-router-dom";

import { LOGIN, UNAUTHORIZE } from "src/constants/pages";
import Layout from "src/containers/Layout";
import { useAppSelector } from "src/hooks/redux";
import InLineLoader from "../components/InlineLoader";
import Roles from "src/constants/roles";

export default function PrivateRoute({ children, ...rest }) {
    const { isAuth, account } = useAppSelector(state => state.authReducer);

    return (
        <Route
            {...rest}
            render={({ location }) =>
                isAuth ?
                    (
                        <Suspense fallback={<InLineLoader />}>
                            <Layout>
                                {children}
                            </Layout>
                        </Suspense>
                    )
                    : <Redirect to={LOGIN} />}
        />
    );
}