export const signIn = (login, password) => ({
    type: 'AUTHORIZATION_SIGN_IN',
    remote: {
        url: "/api/account/sign-in",
        type: 'post',
        body: {
            login: login,
            password: password,
        },
    },
});

export const signInDirect = (data) => ({
    type: 'AUTHORIZATION_SIGN_IN_DIRECT',
    data: data,
})

export const signOut = () => ({
    type: 'AUTHORIZATION_SIGN_OUT',
});

export const reset = () => ({
    type: 'AUTHORIZATION_RESET',
});