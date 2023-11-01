const persistMiddleware = store => next => action => {
    if (action.type == "AUTHORIZATION_SIGN_IN_SUCCESS" || action.type == "AUTHORIZATION_SIGN_IN_DIRECT") {
        localStorage.setItem("AUTHORIZATION", JSON.stringify(action.data));
    }
    else if (action.type == "AUTHORIZATION_SIGN_OUT")
        localStorage.removeItem("AUTHORIZATION");

    next(action);
}

export default persistMiddleware;