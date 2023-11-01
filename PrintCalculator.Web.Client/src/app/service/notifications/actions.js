export const add = (data) => ({
    type: 'NOTIFICATIONS_ADD',
    data: data,
});

export const remove = (id) => ({
    type: 'NOTIFICATIONS_REMOVE',
    id: id,
});

export const removeAll = () => ({
    type: 'NOTIFICATIONS_REMOVE_ALL',
})