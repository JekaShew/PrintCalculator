import initialState from "./../../../initialState";

export default (state = initialState.authorization, action) => {
    switch (action.type) {
        case "AUTHORIZATION_SIGN_IN_SUCCESS":
            return {
                ...state,
                token: action.data.token,
                userInfo: action.data.userInfo
            }
        case "AUTHORIZATION_SIGN_IN_DIRECT":
            return {
                ...state,
                token: action.data.token,
                userInfo: action.data.userInfo
            }
        case "AUTHORIZATION_SIGN_OUT":
            return {
                ...state,
                token: null,
                userInfo: null
            }
        case "AUTHORIZATION_RESET":
            return {
                ...state,
                token: null,
                userInfo: null,
            }
        default:
            return state
    }
}