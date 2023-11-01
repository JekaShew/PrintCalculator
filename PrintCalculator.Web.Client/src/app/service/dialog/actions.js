export const init = (data) => ({
    type: 'DIALOG_INIT',
    data: data,
});

export const yes = () => ({
    type: 'DIALOG_YES',
});

export const okNo = () => ({
    type: 'DIALOG_OKNO',
})