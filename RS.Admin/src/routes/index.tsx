import React, { lazy, Suspense, useEffect } from "react";
import { Route, Switch, useHistory } from "react-router-dom";

import { HOME, AUTH, BRAND, LOGIN, UNAUTHORIZE, CATEGORY } from '../constants/pages';
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import LayoutRoute from "./LayoutRoute";
import Roles from "src/constants/roles";
import { cleanUp, me } from "src/containers/Authorize/reducer";
import PrivateRoute from "./PrivateRoute";

const Home = lazy(() => import('../containers/Home'));
const Login = lazy(() => import('../containers/Authorize'));
const Brand = lazy(() => import('../containers/Brand'));
const Brand1 = lazy(() => import('../containers/Category'));
const NotFound = lazy(() => import("../containers/CategoryTemp"));
const CategoryTemp = lazy(() => import("../containers/NotFound"));
const AuthCallback = lazy(() => import('../containers/Authorize/Auth'));
const UnAuthorize = lazy(() => import("../containers/UnAuthorization"));

const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>
    {children}
  </Suspense>
);

const Routes = () => {
  const { isAuth, account } = useAppSelector(state => state.authReducer);
  const dispatch = useAppDispatch();
  const history = useHistory();

  useEffect(() => {
      dispatch(me());
  }, []);

  // if (!isAuth) return (
  //   <SusspenseLoading>
  //     <Switch>
  //       <PrivateRoute exact path={HOME}>
  //         <Home />
  //       </PrivateRoute>

  //       <Route path={LOGIN}>
  //         <Login />
  //       </Route>

  //       <Route path={AUTH}>
  //         <AuthCallback />
  //       </Route>

  //       <Route path={UNAUTHORIZE}>
  //         <UnAuthorize />
  //       </Route>
  //     </Switch>
  //   </SusspenseLoading>
  // );

  return (
    <SusspenseLoading>
      <Switch>
        <LayoutRoute exact path={HOME}>
          <Home />
        </LayoutRoute>

        <Route path={LOGIN}>
          <Login />
        </Route>

        <Route path={AUTH}>
          <AuthCallback />
        </Route>

        <LayoutRoute path={BRAND}>
          <Brand />
        </LayoutRoute>

        <LayoutRoute exact path={CATEGORY}>
          <Brand1 />
        </LayoutRoute>

        <Route path={UNAUTHORIZE}>
          <UnAuthorize />
        </Route>
        
        <Route component={NotFound} />

      </Switch>
    </SusspenseLoading>
  );
};

export default Routes;
