import initialState from "./../../../initialState";

export default (state = initialState.dialog, action) => {
    switch (action.type) {
        case 'DIALOG_INIT':
            return {
                ...state,
                ...action.data,
                active: true,
            }
        case 'DIALOG_YES':
            return {
                ...state,
                active: false,
            }
        case 'DIALOG_OKNO':
            return {
                ...state,
                active: false,
            }
        default:
            return state
    }
}