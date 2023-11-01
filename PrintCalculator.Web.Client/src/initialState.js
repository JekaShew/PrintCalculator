

export default {
    dialog: {
        active: false,
        label: '',
        content: '',
        yes: '',
        no: '',
        ok: '',
    },
    notifications: {
        items: []
    },
    authorization: {
        token: null,
        userInfo: null,
        ...JSON.parse(localStorage.getItem("AUTHORIZATION"))
    },

    /*----------------------------------------  PAPER  -------------------------------------*/
    paperClasses: [
        {
            id: "123",
            title: "qwerty",
        },
        {
            id: "321",
            title: "asdfghgfd",
        },
    ],

    paperSizes: 
    {
            
    },

    paperDensities:
    {

    },

    paperFormats:
    {

    },

    paperPriceGroups:
    {

    },

    papereCoefficients:
    {

    },

    papers:
    {

    },

    paperTypes:
    {

    },

    /*----------------------------------------  PostPrint  -------------------------------------*/
    packagingTypes:
    {

    },

    postPrintGroups:
    {

    },

    postPrintOperations:
    {

    },

    postPrintPrices:
    {

    },

    postPrintPriceGroups:
    {

    },

    postPrintTargets:
    {

    },
    /*----------------------------------------  STORAGE  -------------------------------------*/

    categories:
    {

    },

    subCategories:
    {

    },

    storages:
    {

    },

    unitMeasures:
    {

    },

    storageProducts:
    {

    },

    /*----------------------------------------  TechProcess  -------------------------------------*/

    options:
    {

    },

    printTypes:
    {

    },

    sectors:
    {

    },

    techProcesses:
    {

    },

    techProcessOptions:
    {

    },

}