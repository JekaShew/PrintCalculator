import Config from './../../../config';
import axios from 'axios';
import { notifications } from '../notifications/service';
import { reset } from '../authorization/actions';

const apiMiddleware = store => next => action => {
    if (action.remote) {
        if (!action.remote.apiStart)
            action.remote.apiStart = action.type + '_START';
        if (!action.remote.apiSuccess)
            action.remote.apiSuccess = action.type + '_SUCCESS';
        if (!action.remote.apiFail)
            action.remote.apiFail = action.type + '_FAIL';
        if (!action.remote.apiDone)
            action.remote.apiDone = action.type + '_DONE';

        store.dispatch({ type: 'GLOBAL_API_START', nested: action.type });
        if (Array.isArray(action.remote.apiStart))
            action.remote.apiStart.forEach((act) => {
                if (typeof act == "object")
                    store.dispatch(act);
                else
                    store.dispatch({ type: act, data: action, nested: action });
            });
        else
            store.dispatch({ type: action.remote.apiStart, data: action, nested: action });

        let authorizationHeader = {};
        let authorization = store.getState().authorization;
        if (authorization.userInfo)
            authorizationHeader = { "Authorization": "Bearer " + authorization.token };
        let contentType;;
        if (action.remote.contentType) {
            if (action.remote.contentType == 'clear')
                contentType = null;
            else
                contentType = action.remote.contentType;
        } else
            contentType = { 'Content-Type': 'application/json; charset=utf-8' };

        axios({
            method: action.remote.type,
            url: Config.apiHost + action.remote.url,
            data: action.remote.body ? action.remote.body : action.remote.data,
            headers: { 'Cache': 'no-cache', ...authorizationHeader, ...contentType },
            withCredentials: true,
            ...action.remote.axiosExtra,
        })
            .then(result => {
                store.dispatch({ type: 'GLOBAL_API_SUCCESS', nested: action.type });
                if (Array.isArray(action.remote.apiSuccess))
                    action.remote.apiSuccess.forEach((act) => {
                        if (typeof act == "object")
                            store.dispatch(act);
                        else
                            store.dispatch({ type: act, data: result.data, nested: action });
                    });
                else
                    store.dispatch({ type: action.remote.apiSuccess, data: result.data, nested: action });
            })
            .catch(error => {
                if (error.response && (error.response.status == 403 || error.response.status == 401))
                    handleNotAuthorized(error.response, store);
                else if (error.response && error.response.status != 500 && error.response.data) {
                    if (Array.isArray(action.remote.apiFail))
                        action.remote.apiFail.forEach((act) => {
                            if (typeof act == "object")
                                store.dispatch(act);
                            else
                                store.dispatch({ type: act, data: error.response.data, nested: action });
                        });
                    else
                        store.dispatch({ type: action.remote.apiFail, data: error.response.data, nested: action });
                } else {
                    handleError(store, action, error);
                }
            })
            .then(() => {
                store.dispatch({ type: 'GLOBAL_API_DONE', nested: action.type });
                if (Array.isArray(action.remote.apiDone))
                    action.remote.apiFail.forEach((act) => {
                        if (typeof act == "object")
                            store.dispatch(act);
                        else
                            store.dispatch({ type: act, nested: action });
                    });
                else
                    store.dispatch({ type: action.remote.apiDone, nested: action });
            });
    }

    next(action);
}

const handleError = (store, action, error) => {
    store.dispatch({ type: 'GLOBAL_API_FAIL', nested: action.type });
    notifications.preset.error({
        title: 'Произошла ошибка при загрузке данных',
    });
    console.log(error);
};

const handleNotAuthorized = (response, store) => {
    if (response.status == 403) {
        notifications.preset.danger({
            title: 'Недостаточно прав',
        });
    }
    if (response.status == 401) {
        store.dispatch(reset());
    }
};

export default apiMiddleware;