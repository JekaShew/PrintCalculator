import initialState from "../../../../initialState";


export default (state = initialState.sectors, action) => {
    switch (action.type) {

        //case "TAKE_PAPERSIZES_SUCCESS":
        //    return {
        //        ...state,
        //        paperSizes: action.data,
        //    }
       
        //case "DELETEPAPERSIZES_SUCCESS":
        //    return {
        //        ...state,
        //        paperSizes: [
        //            ...state.usercars.slice(0, action.ix),
        //            ...state.usercars.slice(action.ix + 1)
        //        ]

        //    }

        default:
            return state
    }
}