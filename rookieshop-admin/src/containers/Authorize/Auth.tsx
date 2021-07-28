import React, { useEffect, useState } from "react";
import { useHistory, useParams, Redirect } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { loginCallback, logoutCallback } from "./reducer";
import { URL } from "src/constants/oidc-configs";
import { HOME, UNAUTHORIZE } from "src/constants/pages";
import Roles from "src/constants/roles";

const Auth = () => {
  const history = useHistory();
  const { action } = useParams<{ action: string }>();
  const [isRedirect, setRedirect] = useState(false);

  const dispatch = useAppDispatch();
  const { loading, error, isAuth, account } = useAppSelector(state => state.authReducer);

  const handleAuthenticatedUser = () => {
    if (account?.profile?.role === Roles.Admin) {
      history.replace(HOME);
    }
    else{
      history.replace(UNAUTHORIZE);
    }
  }

  useEffect(() => {
    switch (action) {
      case "login-callback":
        if (!isAuth)
        {
          dispatch(loginCallback());
        }

        if (isAuth && account != undefined)
        {
          handleAuthenticatedUser();
        }
          
        break;

      case "logout-callback":
        dispatch(logoutCallback());
        history.replace(HOME);
        break;

      default:
        break;
    }
  }, [action, isAuth, account]);

  return (
    <>
    </>
  );
};

export default Auth;
