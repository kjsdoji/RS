export const UrlBackEnd = process.env.REACT_APP_BACKEND_URL;

export const URL = process.env.REACT_APP_URL ?? "http://localhost:3000";

export const CallBackEndpoints = {
    redirect_uri: `${URL}/authentication/login-callback`,
    post_logout_redirect_uri: `${URL}/authentication/logout-callback`,
};