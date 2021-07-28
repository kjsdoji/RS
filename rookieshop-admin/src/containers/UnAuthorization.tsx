import React from 'react';
import { useHistory, useParams, Redirect } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { logout } from "src/containers/Authorize/reducer";
import { HOME } from "src/constants/pages";

const UnAuthorization = () => {
    const history = useHistory();
    const dispatch = useAppDispatch();

    const handleLogout = () => {
        history.push(HOME);
        dispatch(logout());
      };

    return (
        <>
            <div className="d-flex flex-column">
                <div className="d-flex justify-content-center">
                    UnAuthorize, Please log in with Administrator Role to access the app
                </div>
                <div className="d-flex justify-content-center">
                    <button 
                        className="btn btn-danger"
                        type="button" 
                        onClick={handleLogout}
                    >
                        Back To Log In Page 
                    </button>
                </div>
            </div>
        </>
    )
};

export default UnAuthorization;