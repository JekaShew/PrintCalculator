import initialState from "../../../../initialState";


export default (state = initialState.paperClasses, action) => {
    switch (action.type) {

        //case "TAKE_PAPERCLASSES_SUCCESS":
        //    return {
        //        ...state,
        //        paperClasses: action.data,
        //    }
       
        //case "DELETEPAPERCLASSES_SUCCESS":
        //    return {
        //        ...state,
        //        paperClasses: [
        //            ...state.usercars.slice(0, action.ix),
        //            ...state.usercars.slice(action.ix + 1)
        //        ]

        //    }

        default:
            return state
    }
}