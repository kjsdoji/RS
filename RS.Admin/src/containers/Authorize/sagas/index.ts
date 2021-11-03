import { takeLatest } from 'redux-saga/effects';

import { login, me, logout, loginCallback, logoutCallback } from 'src/containers/Authorize/reducer';
import { 
    handleLogin, 
    handleGetMe, 
    handleLogout,
    handleLoginCallback,
    handleLogoutCallback
} from 'src/containers/Authorize/sagas/handles';

export default function* authorizeSagas() {
    yield takeLatest(login.type, handleLogin),
    yield takeLatest(me.type, handleGetMe),
    yield takeLatest(logout.type, handleLogout)
    yield takeLatest(loginCallback.type, handleLoginCallback)
    yield takeLatest(logoutCallback.type, handleLogoutCallback)
}
