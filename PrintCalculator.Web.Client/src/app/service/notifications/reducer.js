import initialState from "./../../../initialState";

export default (state = initialState.notifications, action) => {
    switch (action.type) {
        case 'NOTIFICATIONS_ADD':
            return {
                ...state,
                items: [
                    ...state.items,
                    {
                        ...action.data,
                    },
                ],
            }
        case 'NOTIFICATIONS_REMOVE':
            return {
                ...state,
                items: [
                    ...state.items.slice(0, state.items.findIndex(x => x.id == action.id)),
                    ...state.items.slice(state.items.findIndex(x => x.id == action.id) + 1),
                ],
            }
        case 'NOTIFICATIONS_REMOVE_ALL':
            return {
                ...state,
                items: [],
            }
        default:
            return state
    }
}