import apiMiddleware from "../remote/api-middleware";
import store from "../../../store";

export const actions = {
    apiStart: 'SERVICE_API_START',
    apiSuccess: 'SERVICE_API_SUCCESS',
    apiFail: 'SERVICE_API_FAIL',
    apiDone: 'SERVICE_API_DONE',
}

export const apiFetch = (remote, events) => {
    let action = {
        remote: {
            ...remote,
            ...actions,
        }
    }
    let storeMock = {
        getState: store.getState,
        dispatch: (a) => {
            switch (a.type) {
                case actions.apiStart:
                    if (events.start)
                        events.start(a.data);
                    return;
                case actions.apiSuccess:
                    if (events.success)
                        events.success(a.data);
                    return;
                case actions.apiFail:
                    if (events.fail)
                        events.fail(a.data);
                    return;
                case actions.apiDone:
                    if (events.done)
                        events.done(a.data);
                    return;
                default:
                    store.dispatch(a);
                    return;
            }
        }
    };
    apiMiddleware(storeMock)(() => { })(action);
}

export const apiFetchSimple = (url, success, data) => {
    let remote = {
        url: url,
        type: 'get',
        data: data,
    };
    let events = {
        success: success
    };
    return apiFetch(remote, events);
}