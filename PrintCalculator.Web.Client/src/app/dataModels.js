import { colStyle, formStyle, propType } from "./controls/form/form";
import AutocompleteString from './service/autocomplete/string/autocomplete-string';

import { backendColumnType } from "./service/data-models/data-models";

//export const backendColumnType = {
//    string: "PrintCalculator.UI.Gen2.Table.ColumnFilters.StringColumnFilter, PrintCalculator.UI.Gen2",
//    int: "PrintCalculator.UI.Gen2.Table.ColumnFilters.IntColumnFilter, PrintCalculator.UI.Gen2",
//    float: "PrintCalculator.UI.Gen2.Table.ColumnFilters.FloatColumnFilter, PrintCalculator.UI.Gen2",
//    date: "PrintCalculator.UI.Gen2.Table.ColumnFilters.DateColumnFilter, PrintCalculator.UI.Gen2",
//    id: "PrintCalculator.UI.Gen2.Table.ColumnFilters.IdColumnFilter, PrintCalculator.UI.Gen2"
//};

//export const filterFromTable = (table) => {
//    return Object.fromEntries(table.columns.map((x) => [x.display.name, ({
//        ["$type"]: x.data.type,
//        title: x.data.title,
//        ...propTypeToFilter[x.display.type],
//    })]));
//};

export const dataModels = {

    // ------------------------------------------  PAPER  ------------------------------------------------//
    paperSize: {
        label: "Размер Бумаги",
        editLabel: "Редактирование размера бумаги",
        url: "/api/crud/papersizes",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },

            {
                name: "width",
                label: "Ширина",
                type: propType.float,
            },

            {
                name: "height",
                label: "Высота",
                type: propType.float,
            },
        ]
    },

    paperDensity: {
        label: "Плотность Бумаги",
        editLabel: "Редактирование плотности бумаги",
        url: "/api/crud/paperdensities",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "density",
                label: "Плотность Бумаги",
                type: propType.text,
            },

        ]
    },

    paperClass: {
        label: "Класс Бумаги",
        editLabel: "Редактирование класса бумаги",
        url: "/api/crud/paperclasses",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },

        ]
    },

    paperPriceGroup: {
        label: "Ценовые группы Бумаги",
        editLabel: "Редактирование ценовых групп бумаги",
        url: "/api/crud/paperpricegroups",
        rows: [
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "id",
                                    type: propType.hidden,
                                },
                                {
                                    name: "title",
                                    label: "Название",
                                    type: propType.text,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "pricePerKg",
                                    label: "Цена за кг.",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperClass',
                                    label: 'Класс Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/paperclasses',
                                },
                            ],
                        },
                    ],
            },
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props:
                                [
                                    {
                                        name: "markupMaxAmount",
                                        label: "Кол-во листов бумаги до начала падения наценки",
                                        type: propType.int,
                                    },
                                ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMaxCoefficient",
                                    label: "Максимальная наценка на бумагу",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMinAmount",
                                    label: "Кол-во листов бумаги до окончания падения наценки",
                                    type: propType.int,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMinCoefficient",
                                    label: "Минимальная наценка на бумагу",
                                    type: propType.float,
                                },
                            ],
                        },
                    ],
            },
        ],
    },

    paperFormat: {
        label: "Формат Бумаги",
        editLabel: "Редактирование формата бумаги",
        url: "/api/crud/paperformats",
        rows: [
            {
                height: 2,
                columns: [
                    {
                        width: colStyle.w1x3,
                        props: [
                            {
                                name: "id",
                                type: propType.hidden,
                            },
                            {
                                name: "title",
                                label: "Название",
                                type: propType.text,
                            },
                        ],
                    },
                    {
                        width: colStyle.w1x3,
                        props: [
                            {
                                name: 'paperSize',
                                label: 'Размер Бумаги',
                                type: propType.object,
                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                url: '/api/autocomplete/papersizes',
                            },
                        ],
                    },
                ],
            },
        ],
    },

    paper: {
        label: "Виды Бумаги",
        editLabel: "Редактирование видов бумаги",
        url: "/api/crud/papers",
        rows: [
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "id",
                                    type: propType.hidden,
                                },
                                {
                                    name: "title",
                                    label: "Название",
                                    type: propType.text,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "titleOnStorage",
                                    label: "Название на складе",
                                    type: propType.text,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "price",
                                    label: "Цена",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "priceKg",
                                    label: "Цена за кг.",
                                    type: propType.float,
                                },
                            ],
                        },
                        //{
                        // width: colStyle.w1x3,
                        // props: [

                        //{
                        //    name: "suspendedsupply",
                        //    label: "Приостановлена поставка",
                        //    type: propType.,
                        //},
                        // ],
                        //},
                    ],
            },
            {

                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMaxAmount",
                                    label: "Кол-во листов бумаги до начала падения наценки",
                                    type: propType.int,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMaxAmountCoefficient",
                                    label: "Максимальная наценка",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMinAmount",
                                    label: "Кол-во листов бумаги до окончания падения наценки",
                                    type: propType.int,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "markupMinAmountCoefficient",
                                    label: "Минимальная наценка",
                                    type: propType.float,
                                },
                            ],
                        },
                    ],
            },
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperSize',
                                    label: 'Размер Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/papersizes',
                                },
                            ],
                        },

                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperType',
                                    label: 'Тип Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/papertypes',
                                },
                            ],
                        },

                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperPriceGroup',
                                    label: 'Ценовая группа Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/paperpricegroups',
                                },
                            ],
                        },

                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperDensity',
                                    label: 'Плотность Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/paperdensities',
                                },
                            ],
                        },
                    ],
            },
        ],
    },

    paperType: {
        label: "Тип Бумаги",
        editLabel: "Редактирование типа бумаги",
        url: "/api/crud/papertypes",
        rows:
            [
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "id",
                                        type: propType.hidden,
                                    },
                                    {
                                        name: "title",
                                        label: "Название",
                                        type: propType.text,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "width",
                                        label: "Толщина",
                                        type: propType.float,
                                    },
                                ],
                            },
                            //{
                            // width: colStyle.w1x3,
                            //props: [
                            //{
                            //    name: "OneSided",
                            //    label: "Односторонняя",
                            //    type: propType.text,
                            //},
                            // ],
                            //},

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "minMarkUpPurchasePrice",
                                        label: "Минимальная наценка с закупочной цены",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "markupMaxAmount",
                                        label: "Кол-во листов бумаги до начала падения наценки",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "markupMaxAmountCoefficient",
                                        label: "Максимальная наценка",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "markupMinAmount",
                                        label: "Кол-во листов бумаги до окончания падения наценки",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "markupMinAmountCoefficient",
                                        label: "Минимальная наценка",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'paperDensity',
                                        label: 'Плотность Бумаги',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/paperdensities',
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'paperClass',
                                        label: 'Класс Бумаги',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/paperclasses',
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'paperPriceGroup',
                                        label: 'Ценовая группа Бумаги',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/paperpricegroups',
                                    },
                                ],
                            },
                        ],
                },
            ],
    },

    paperCoefficient: {
        label: "Коэффициент Бумаги",
        editLabel: "Редактирование коэффициента бумаги",
        url: "/api/crud/papercoefficients",
        rows:
            [
                {
                    height: 2,
                    columns: [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "id",
                                    type: propType.hidden,
                                },
                                {
                                    name: "title",
                                    label: "Название",
                                    type: propType.text,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "coefficient",
                                    label: "Коэффициент",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'paperDensity',
                                    label: 'Плотность Бумаги',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/paperdensities',
                                },
                            ],
                        },

                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'techProcess',
                                    label: 'ТехПроцесс',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/techprocesses',
                                },
                            ],
                        },
                    ],
                },
            ],
    },

    // ------------------------------------------  STORAGE  ------------------------------------------------//

    category: {
        label: "Категория",
        editLabel: "Редактирование категории",
        url: "/api/crud/categories",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    unitMeasure: {
        label: "Единица измерения",
        editLabel: "Редактирование единицы измерения",
        url: "/api/crud/unitmeasures",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    storage: {
        label: "Склад",
        editLabel: "Редактирование склада",
        url: "/api/crud/storages",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },

            {
                name: "description",
                label: "Описание",
                type: propType.text,
            },
        ]
    },

    subCategory: {
        label: "ПодКатегория",
        editLabel: "Редактирование подКатегории",
        url: "/api/crud/subcategories",
        rows: [
            {
                height: 2,
                columns: [
                    {
                        width: colStyle.w1x3,
                        props: [
                            {
                                name: "id",
                                type: propType.hidden,
                            },
                            {
                                name: "title",
                                label: "Название",
                                type: propType.text,
                            },
                        ],
                    },
                    {
                        width: colStyle.w1x3,
                        props: [
                            {
                                name: 'category',
                                label: 'Категория',
                                type: propType.object,
                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                url: '/api/autocomplete/categories',
                            },
                        ],
                    },
                ],
            },
        ],
    },

    storageProduct: {
        label: "Объект Склада",
        editLabel: "Редактирование объекта склада",
        url: "/api/crud/storageproducts",
        rows:
            [
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "id",
                                        type: propType.hidden,
                                    },
                                    {
                                        name: "title",
                                        label: "Название",
                                        type: propType.text,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "amountPackages",
                                        label: "Количество упаковок",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "amount",
                                        label: "Количество",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'storage',
                                                label: 'Склад',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/storages',
                                            },
                                        ],
                                    },

                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'unitMeasure',
                                                label: 'Единица измерения',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/unitmeasures',
                                            },
                                        ],
                                    },

                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'subCategory',
                                                label: 'ПодКатегория',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/subcategories',
                                            },
                                        ],
                                    },
                                ],
                            },
                        ],
                },
            ],
    },



    // ------------------------------------------  PostPrint  ------------------------------------------------//

    packagingType: {
        label: "Тип упаковки",
        editLabel: "Редактирование типа упаковки",
        url: "/api/crud/packagingtypes",
        rows:
            [
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "id",
                                        type: propType.hidden,
                                    },
                                    {
                                        name: "title",
                                        label: "Название",
                                        type: propType.text,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "preparationPrice",
                                        label: "Цена подготовки",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "preparationCostPrice",
                                        label: "Себестоимость подготовки",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "preparationTime",
                                        label: "Время подготовки",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "perPackPrice",
                                        label: "Цена за одну упаковку",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "perPackCostPrice",
                                        label: "Себестоимость за одну упаковку",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "perPackTime",
                                        label: "Время на одну упаковку",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
            ],
    },


    postPrintGroup: {
        label: "Группа ПостПринт обработки",
        editLabel: "Редактирование группы ПостПринт обработки",
        url: "/api/crud/postprintgroups",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    postPrintPriceGroup: {
        label: "Ценовая группа ПостПринт обработки",
        editLabel: "Редактирование ценовой группы ПостПринт Обработки",
        url: "/api/crud/postprintpricegroups",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    postPrintTarget: {
        label: "Объект ПостПринт обработки",
        editLabel: "Редактирование объекта ПостПринт обработки",
        url: "/api/crud/postprinttargets",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    postPrintOperation: {
        label: "Операции ПостПринт обработки",
        editLabel: "Редактирование операции ПостПринт обработки",
        url: "/api/crud/postprintoperations",
        rows: [
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "id",
                                    type: propType.hidden,
                                },
                                {
                                    name: "title",
                                    label: "Название",
                                    type: propType.text,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "measureUnit",
                                    label: "Единица измерения",
                                    type: propType.text,
                                },
                            ],
                        },
                        //{
                        //width: colStyle.w1x3,
                        //props: [
                        //{
                        //    name: "ConsumesPaperMaterial",
                        //    label: "Расходует бумагу/материал",
                        //    type: propType.text,
                        //},
                        //],
                        //},
                    ],
            },
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "waitingTime",
                                    label: "Время отсрочки",
                                    type: propType.int,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "preparationTime",
                                    label: "Время подготовки",
                                    type: propType.int,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "operationTime",
                                    label: "Время операции",
                                    type: propType.int,
                                },
                            ],
                        },
                    ],
            },
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    width: colStyle.w1x3,
                                    props: [
                                        {
                                            name: 'postPrintGroup',
                                            label: 'Группа ПостПринт обработки',
                                            type: propType.object,
                                            valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                            url: '/api/autocomplete/postprintgroups',
                                        },
                                    ],
                                },

                                {
                                    width: colStyle.w1x3,
                                    props: [
                                        {
                                            name: 'postPrintTarget',
                                            label: 'Объект ПостПринт обработки',
                                            type: propType.object,
                                            valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                            url: '/api/autocomplete/postprinttargets',
                                        },
                                    ],
                                },

                                {
                                    width: colStyle.w1x3,
                                    props: [
                                        {
                                            name: 'sector',
                                            label: 'Сектор',
                                            type: propType.object,
                                            valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                            url: '/api/autocomplete/sectors',
                                        },
                                    ],
                                },
                            ],
                        },
                    ],
            },
        ],
    },

    postPrintPrice: {
        label: "Цена ПостПринт обработки",
        editLabel: "Редактирование цены ПостПринт обработки",
        url: "/api/crud/postprintprices",
        rows:
            [

                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "id",
                                        type: propType.hidden,
                                    },
                                    {
                                        name: "title",
                                        label: "Название",
                                        type: propType.text,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "weight",
                                        label: "Масса",
                                        type: propType.int,
                                    },
                                ],
                            },
                           
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "preparationCostPrice",
                                        label: "Себестомость подготовки",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "forUnitCostPrice",
                                        label: "Себестоимость за единицу",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingPerKPLpsc",
                                        label: "Приладка на каждый КПЛ",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingPerOrderpsc",
                                        label: "Приладка на ордер",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingFromEditionCoefficient",
                                        label: "Приладка от тиража",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "appliesTo",
                                        label: "Применяется к",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                //{
                    //height: 2,
                    //columns:
                        //[
                            //BOOL{
                            //width: colStyle.w1x3,
                            //props: [
                            //{
                            //    name: "Consumable",
                            //    label: "Расходник",
                            //    type: propType.text,
                            //},
                            //],
                            //},
                            //{
                            //width: colStyle.w1x3,
                            //props: [
                            //{
                            //    name: "DestroySheet",
                            //    label: "Уничтожает лист",
                            //    type: propType.text,
                            //},
                            //],
                            //},
                            //{
                            //width: colStyle.w1x3,
                            //props: [
                            //{
                            //    name: "OneSide",
                            //    label: "Односторонняя",
                            //    type: propType.text,
                            //},
                            //],
                            //},
                            //{
                            //width: colStyle.w1x3,
                            //props: [
                            //{
                            //    name: "RequirePrepress",
                            //    label: "Требует препресс",
                            //    type: propType.text,
                            //},
                            //],
                            //},
                        //],
                //},
                 
                
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "sheetWidth",
                                        label: "Ширина листа",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "sheetHeight",
                                        label: "Высота листа",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "indentLong",
                                        label: "Отступ по длинной стороне",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "indentShort",
                                        label: "Отступ по короткой стороне",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "measureUnit",
                                        label: "Единица измерения",
                                        type: propType.text,
                                    },
                                ],
                            },
                            //Переделать в BOOL{
                            //width: colStyle.w1x3,
                            //props: [
                            //{
                            //name: "multiplierPreparation",
                            //label: "Мультипликатор подготовки",
                            //type: propType.int,
                            //},
                            //],
                            //},
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "mainPreparation",
                                        label: "Основная цена пдоготовки",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "additionalPreparation",
                                        label: "Дополнительная цена подготовки",
                                        type: propType.int,
                                    },
                                ],
                            },

                        ],
                },

                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "mainPerUnitMax",
                                        label: "Основная максимальная цена за единицу",
                                        type: propType.float,
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "mainPerUnitMin",
                                        label: "Основная минимальная цена за единицу",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "mainAmountForMaxPrice",
                                        label: "Основное количество для максимальной цены",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "mainAmountForMinPrice",
                                        label: "Основное количество для минимальной цены",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "additionalPerUnitMax",
                                        label: "Дополнительная максимальная цена за еденицу ",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "additionalPerUnitMin",
                                        label: "Дополнительная минимальная цена за еденицу",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "additionalAmountForMaxPrice",
                                        label: "Дополнительное количество для максимальной цены",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "additionalAmountForMinPrice",
                                        label: "Дополнительное количество для минимальной цены",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'postPrintPriceGroup',
                                                label: 'Ценовая группа ПостПринт обработки',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/postprintpricegroups',
                                            },
                                        ],
                                    },

                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'mainPostPrintTarget',
                                                label: 'Основной цена расчитывается от',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/postprinttargets',
                                            },
                                        ],
                                    },

                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'additionalPostPrintTarget',
                                                label: 'Дополнительная цена расчитывается от',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/postprinttargets',
                                            },
                                        ],
                                    },

                                    {
                                        width: colStyle.w1x3,
                                        props: [
                                            {
                                                name: 'paperFormat',
                                                label: 'Формат Бумаги',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/paperformats',
                                            },
                                        ],
                                    },
                                ],
                            },
                        ],
                },
            ],
    },

    // ------------------------------------------  TechProcess  ------------------------------------------------//

    option: {
        label: "Опция",
        editLabel: "Редактирование опции",
        url: "/api/crud/options",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },

            {
                name: "description",
                label: "Описание",
                type: propType.text,
            },
        ]
    },

    sector: {
        label: "Сектор",
        editLabel: "Редактирование сектора",
        url: "/api/crud/sectors",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    printType: {
        label: "Тип Печати",
        editLabel: "Редактирование типа печати",
        url: "/api/crud/printtypes",
        props: [
            {
                name: "id",
                type: propType.hidden,
            },

            {
                name: "title",
                label: "Название",
                type: propType.text,
            },
        ]
    },

    techProcessOption: {
        label: "ТехПроцесс - Опция",
        editLabel: "Редактирование ТехПроцесс - Опция",
        url: "/api/crud/techprocessoptions",
        rows: [
            {
                height: 2,
                columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "id",
                                    type: propType.hidden,
                                },
                                {
                                    name: 'techProcess',
                                    label: 'ТехПроцесс',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/techprocesses',
                                },
                            ],
                        },

                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: 'option',
                                    label: 'Опция',
                                    type: propType.object,
                                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                    url: '/api/autocomplete/options',
                                },
                            ],
                        },
                    ],
            },
        ],
    },

    techProcess: {
        label: "ТехПроцесс",
        editLabel: "Редактирование ТехПроцесса",
        url: "/api/crud/techprocesses",
        rows:
            [
                {
                    height: 3,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "id",
                                        type: propType.hidden,
                                    },
                                    {
                                        name: "title",
                                        label: "Название",
                                        type: propType.text,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "color",
                                        label: "Цвет",
                                        type: propType.int,
                                    },
                                ],
                            },
                            //{
                            //    width: colStyle.w1x3,
                            //    props: [
                            //{
                            //    name: "special",
                            //    label: "Специальный",
                            //    type: propType.text,
                            //},
                            //    ],
                            //},

                        ],
                },
                {
                    height: 3,
                    columns:
                    [
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "maxPaperWidth",
                                    label: "Максимальная ширина листа",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "maxPaperHeight",
                                    label: "Максимальная высота листа",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "minPaperWidth",
                                    label: "Минимальная ширина листа",
                                    type: propType.float,
                                },
                            ],
                        },
                        {
                            width: colStyle.w1x3,
                            props: [
                                {
                                    name: "minPaperHeight",
                                    label: "Минимальная высота листа",
                                    type: propType.float,
                                },
                            ],
                        },
                    ],
                },
                {
                    height: 3,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "beforePrintTime",
                                        label: "Время до печати",
                                        type: propType.int,
                                    },

                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "startPrintTime",
                                        label: "Время на старт печати",
                                        type: propType.int,
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "oneInstancePrintTime",
                                        label: "Печать одного экземпляра",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "waitingPostPrintTime",
                                        label: "Ожидание постпечати",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "dryingTime",
                                        label: "Время сушки",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "checkTime",
                                        label: "Время для препресса на проверку",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "installationTime",
                                        label: "Время для препресса на монтаж",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "costPrice",
                                        label: "Себестоимость",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "materialMarkup",
                                        label: "Наценка на материал",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingPrice",
                                        label: "Приладка цена",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "formsPrice",
                                        label: "Формы прайс",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "pantonBatchPrice",
                                        label: "Пантон цена замеса",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "lacquerPreparationPrice",
                                        label: "Лак цена подготовки",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "cuttingCutPrice",
                                        label: "Резка цена реза",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "printRunPrice",
                                        label: "Печать цена прогона",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "printRunLacquerPrice",
                                        label: "Печать цена прогона лака",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "cuttingPreparationPrice",
                                        label: "Резка цена подготовки",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w2x3,
                                props: [
                                    {
                                        name: "sectionsInThePriceOfARun",
                                        label: "Секций в цене прогона",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1,
                                props: [
                                    {
                                        name: "fittingPerRunPrice",
                                        label: "Цена приладки за прогон",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "minPrintPrice",
                                        label: "Миниальная цена печати",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "minPrintSheetPrice",
                                        label: "Минимальная цена печати листа",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "cuttingWithACollarMarkUp",
                                        label: "Наценка за резку с подворотом",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "coefficientPerTurnOver",
                                        label: "Коэффициент на оборот",
                                        type: propType.float,
                                    },
                                ],
                            },

                         
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingWithoutTurnOver",
                                        label: "Приладка без оборота",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingForeignerTurnOver",
                                        label: "Приладка чужой оборот",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingKombo",
                                        label: "Приладка Комбо",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingYourTurnOver",
                                        label: "Приладка свой оборот",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "paperFittingFirstPrint",
                                        label: "Бумага приладка первая краска",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "paperFittingAdditionalPaint",
                                        label: "Бумага Приладка дополнительная краска",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "paperFittingPanton",
                                        label: "Бумага приладка пантон",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "paperFittingFromEdition",
                                        label: "Бумага Приладка от тиража",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x2,
                                props: [
                                    {
                                        name: "valveWidth",
                                        label: "Ширина клапана",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "paperTrim",
                                        label: "Подрезка бумаги",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fieldForCrosses",
                                        label: "Поле для крестов",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "diesWidth",
                                        label: "Ширина плашек",
                                        type: propType.int,
                                    },
                                ],
                            },
                        ],
                },
                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "increasedTireWear",
                                        label: "Повышенный износ резины",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "platesCtPResource",
                                        label: "Ресурс пластин CtP",
                                        type: propType.int,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "customCutting",
                                        label: "Нестандартная резка",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "rewash",
                                        label: "Перемывка",
                                        type: propType.float,
                                    },
                                ],
                            },
                        ],
                },

                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingYourTurnOverThroughValvePrice",
                                        label: "Приладка свой оборот через клапан цена",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: "fittingCoefficientForYourTurnOver",
                                        label: "Коэффициент на приладку для своего оборота",
                                        type: propType.float,
                                    },
                                ],
                            },
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'storage',
                                        label: 'Склад',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/storages',
                                    },
                                ],
                            },
                        ],
                },


                {
                    height: 2,
                    columns:
                        [
                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'printType',
                                        label: 'Тип печати',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/printtypes',
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'sector',
                                        label: 'Сектор',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/sectors',
                                    },
                                ],
                            },

                            

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'paperFormat',
                                        label: 'Формат бумаги',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/paperformats',
                                    },
                                ],
                            },

                            {
                                width: colStyle.w1x3,
                                props: [
                                    {
                                        name: 'paperSize',
                                        label: 'Размер бумаги',
                                        type: propType.object,
                                        valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                        url: '/api/autocomplete/papersizes',
                                    },
                                ],
                            },
                        ],
                },
                {
                    columns: [{
                        height: 2,
                        width: colStyle.w1,
                        props:
                            [
                                {
                                    name: 'techProcessOptions',
                                    label: 'Опции',
                                    type: propType.table,
                                    cols: 4,
                                    model: {
                                        ui: formStyle.w2x9,
                                        props: [
                                            {
                                                ui: formStyle.x1,
                                                name: 'option',
                                                type: propType.object,
                                                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                                url: '/api/autocomplete/options',
                                            },

                                            //{
                                            //    ui: formStyle.x2,
                                            //    name: 'techProcess',
                                            //    type: propType.object,
                                            //    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                                            //    url: '/api/autocomplete/techprocesses',
                                            //},
                                        ]
                                    }
                                },
                            ]
                    }]
                },
            ],
    },
}

export const dataTables = {

    // --------------------------------------  PAPER  ------------------------------------//

    paperSizes: {
        url: '/api/table/papersizes',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '60%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Ширина',
                    name: 'width',
                    width: '20%',
                    type: propType.float,
                },
                data: {
                    name: 'Width',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Высота',
                    name: 'height',
                    width: '20%',
                    type: propType.float,
                },
                data: {
                    name: 'Height',
                    type: backendColumnType.float,
                },
            },
        ],
    },

    paperDensities: {
        url: '/api/table/paperdensities',
        defaultOrder: {
            name: 'Density',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Плотность',
                    name: 'density',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Density',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    paperClasses: {
        url: '/api/table/paperclasses',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    paperPriceGroups: {
        url: '/api/table/paperpricegroups',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '40%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Цена за кг.',
                    name: 'pricePerKg',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'PricePerKg',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для максимальной наценки',
                    name: 'markupMaxAmount',
                    width: '10%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMaxAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Максимальный коэйффициент наценки',
                    name: 'markupMaxCoefficient',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMaxCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для минимальной наценки',
                    name: 'markupMinAmount',
                    width: '10%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMinAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Минимальный коэйффициент наценки',
                    name: 'markupMinCoefficient',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMinCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Класс Бумаги',
                    name: 'paperClass',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperclasses',
                },
                data: {
                    name: 'PaperClassId',
                    orderName: 'PaperClasses.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    paperTypes: {
        url: '/api/table/papertypes',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '30%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Ширина',
                    name: 'width',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'Width',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для максимальной наценки',
                    name: 'markupMaxAmount',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMaxAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Максимальный коэйффициент наценки',
                    name: 'markupMaxAmountCoefficient',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMaxAmountCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для минимальной наценки',
                    name: 'markupMinAmount',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMinAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Минимальный коэйффициент наценки',
                    name: 'markupMinAmountCoefficient',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMinAmountCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Класс Бумаги',
                    name: 'paperClass',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperclasses',
                },
                data: {
                    name: 'PaperClassId',
                    orderName: 'PaperClasses.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Плотность Бумаги',
                    name: 'paperDensity',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperdensities',
                },
                data: {
                    name: 'PaperDensityId',
                    orderName: 'PaperDensities.Density',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Ценовая группа Бумаги',
                    name: 'paperPriceGroup',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperpricegroups',
                },
                data: {
                    name: 'PaperPriceGroupId',
                    orderName: 'PaperPriceGroups.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    paperFormats: {
        url: '/api/table/paperformats',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '60%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
            {
                display: {
                    label: 'Размер Бумаги',
                    name: 'paperSize',
                    width: '40%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/papersizes',
                },
                data: {
                    name: 'PaperSizeId',
                    orderName: 'PaperSizes.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    papers: {
        url: '/api/table/papers',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '20%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Наименование на складе',
                    name: 'titleOnStorage',
                    width: '10%',
                    type: propType.text,
                },
                data: {
                    name: 'TitleOnStorage',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Цена',
                    name: 'price',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'Price',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для максимальной наценки',
                    name: 'markupMaxAmount',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMaxAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Максимальный коэйффициент наценки',
                    name: 'markupMaxAmountCoefficient',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMaxAmountCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество для минимальной наценки',
                    name: 'markupMinAmount',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'MarkupMinAmount',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Минимальный коэйффициент наценки',
                    name: 'markupMinAmountCoefficient',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'MarkupMinAmountCoefficient',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Цена за кг.',
                    name: 'priceKg',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'PriceKg',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Тип Бумаги',
                    name: 'paperType',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/papertypes',
                },
                data: {
                    name: 'PaperTypeId',
                    orderName: 'PaperTypes.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Ценовая группа Бумаги',
                    name: 'paperPriceGroup',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperpricegroups',
                },
                data: {
                    name: 'PaperPriceGroupId',
                    orderName: 'PaperPriceGroups.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Плотность Бумаги',
                    name: 'paperDensity',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperdensities',
                },
                data: {
                    name: 'PaperDensityId',
                    orderName: 'PaperDensities.Density',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Размер Бумаги',
                    name: 'paperSize',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/papersizes',
                },
                data: {
                    name: 'PaperSizeId',
                    orderName: 'PaperSizes.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    paperCoefficiets: {
        url: '/api/table/papercoefficients',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '50%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Коэффициент',
                    name: 'coefficient',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'Coefficient',
                    type: backendColumnType.float,
                },
            },
            {
                display: {
                    label: 'ТехПроцесс',
                    name: 'techProcess',
                    width: '30%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/techprocesses',
                },
                data: {
                    name: 'TechProcessId',
                    orderName: 'TechProcesses.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Плотность Бумаги',
                    name: 'paperDensity',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperdensities',
                },
                data: {
                    name: 'PaperDensityId',
                    orderName: 'PaperDensities.Density',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    // --------------------------------------  STORAGE  ------------------------------------//

    categories: {
        url: '/api/table/categories',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    unitMeasures: {
        url: '/api/table/unitmeasures',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    storages: {
        url: '/api/table/storages',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '35%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Описание',
                    name: 'description',
                    width: '65%',
                    type: propType.text,
                },
                data: {
                    name: 'Description',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    subCategories: {
        url: '/api/table/subcategories',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '50%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
            {
                display: {
                    label: 'Категория',
                    name: 'category',
                    width: '50%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/categories',
                },
                data: {
                    name: 'CategoryId',
                    orderName: 'Categories.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    storageProducts: {
        url: '/api/table/storageproducts',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '65%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Количество упаковок',
                    name: 'amountPackages',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'AmountPackages',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Количество',
                    name: 'amount',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'Amount',
                    type: backendColumnType.string,
                },
            },
            {
                display: {
                    label: 'Единица измерения',
                    name: 'unitMeasure',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/unitmeasures',
                },
                data: {
                    name: 'UnitMeasureId',
                    orderName: 'UnitMeasures.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'ПодКатегория',
                    name: 'subCategory',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/subcategories',
                },
                data: {
                    name: 'SubCategoryId',
                    orderName: 'SubCategories.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Склад',
                    name: 'storage',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/storages',
                },
                data: {
                    name: 'StorageId',
                    orderName: 'Storages.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    // --------------------------------------  PostPrint  ------------------------------------//

    packagingTypes: {
        url: '/api/table/packagingtypes',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '40%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Цена подготовки',
                    name: 'preparationPrice',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'PreparationPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Цена за одну упаковку',
                    name: 'perPackPrice',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'PerPackPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Себестоимость подготовки',
                    name: 'preparationCostPrice',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'PreparationCostPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Себестоимость одной упаковки',
                    name: 'perPackCostPrice',
                    width: '10%',
                    type: propType.float,
                },
                data: {
                    name: 'PerPackCostPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Время подготовки',
                    name: 'preparationTime',
                    width: '10%',
                    type: propType.int,
                },
                data: {
                    name: 'PreparationTime',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Время на одну упаковку ',
                    name: 'perPackTime',
                    width: '10%',
                    type: propType.int,
                },
                data: {
                    name: 'PerPackTime',
                    type: backendColumnType.int,
                },
            },

        ],
    },

    postPrintGroups: {
        url: '/api/table/postprintgroups',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    postPrintPriceGroups: {
        url: '/api/table/postprintpricegroups',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    postPrintTargets: {
        url: '/api/table/postprinttargets',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    postPrintOperations: {
        url: '/api/table/postprintoperations',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '30%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Единиа измерения',
                    name: 'measureUnit',
                    width: '25%',
                    type: propType.text,
                },
                data: {
                    name: 'MeasureUnit',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Время ожидания',
                    name: 'waitingTime',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'WaitingTime',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Время подготовки',
                    name: 'preparationTime',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'PreparationTime',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Время обработки',
                    name: 'operationTime',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'OperationTime',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Группа ПостПринт обработки',
                    name: 'postPrintGroup',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/postprintgroups',
                },
                data: {
                    name: 'PostPrintGroupId',
                    orderName: 'PostPrintGroups.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Объект ПостПринт обработки',
                    name: 'postPrintTarget',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/postprinttargets',
                },
                data: {
                    name: 'PostPrintTargetId',
                    orderName: 'PostPrintTargets.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Сектор',
                    name: 'sector',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/sectors',
                },
                data: {
                    name: 'SectorId',
                    orderName: 'Sectors.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    postPrintPrices: {
        url: '/api/table/postprintprices',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '20%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'MainPreparation',
                    name: 'mainPreparation',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'MainPreparation',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'AdditionalPreparation',
                    name: 'additionalPreparation',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'AdditionalPreparation',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'MainPerUnitMax',
                    name: 'mainPerUnitMax',
                    width: '3%',
                    type: propType.float,
                },
                data: {
                    name: 'MainPerUnitMax',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'AdditionalPerUnitMax',
                    name: 'additionalPerUnitMax',
                    width: '3%',
                    type: propType.float,
                },
                data: {
                    name: 'AdditionalPerUnitMax',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'MainPerUnitMin',
                    name: 'mainPerUnitMin',
                    width: '3%',
                    type: propType.float,
                },
                data: {
                    name: 'MainPerUnitMin',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'AdditionalPerUnitMin',
                    name: 'additionalPerUnitMin',
                    width: '3%',
                    type: propType.float,
                },
                data: {
                    name: 'AdditionalPerUnitMin',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'MainAmountForMaxPrice',
                    name: 'mainAmountForMaxPrice',
                    width: '3%',
                    type: propType.int,
                },
                data: {
                    name: 'MainAmountForMaxPrice',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'AdditionalAmountForMaxPrice',
                    name: 'additionalAmountForMaxPrice',
                    width: '3%',
                    type: propType.int,
                },
                data: {
                    name: 'AdditionalAmountForMaxPrice',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'MainAmountForMinPrice',
                    name: 'mainAmountForMinPrice',
                    width: '3%',
                    type: propType.int,
                },
                data: {
                    name: 'MainAmountForMinPrice',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'AdditionalAmountForMinPrice',
                    name: 'additionalAmountForMinPrice',
                    width: '3%',
                    type: propType.int,
                },
                data: {
                    name: 'AdditionalAmountForMinPrice',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Себестоимость подготовки',
                    name: 'preparationCostPrice',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'PreparationCostPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Себестоимость за единицу',
                    name: 'forUnitCostPrice',
                    width: '5%',
                    type: propType.float,
                },
                data: {
                    name: 'ForUnitCostPrice',
                    type: backendColumnType.float,
                },
            },

            {
                display: {
                    label: 'Единица измерения',
                    name: 'measureUnit',
                    width: '3%',
                    type: propType.text,
                },
                data: {
                    name: 'MeasureUnit',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Шиина листа',
                    name: 'sheetWidth',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'SheetWidth',
                    type: backendColumnType.int,
                },
            },

            {
                display: {
                    label: 'Высота листа',
                    name: 'sheetHeight',
                    width: '5%',
                    type: propType.int,
                },
                data: {
                    name: 'SheetHeight',
                    type: backendColumnType.int,
                },
            },



            {
                display: {
                    label: 'Ценовая группа ПостПринт Обработки',
                    name: 'postPrintPriceGroup',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/postprintpricegroups',
                },
                data: {
                    name: 'PostPrintPriceGroupId',
                    orderName: 'PostPrintPriceGroups.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Основной объект ПостПринт обработки',
                    name: 'mainPostPrintTarget',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/postprinttargets',
                },
                data: {
                    name: 'MainPostPrintTargetId',
                    orderName: 'PostPrintTargets.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Дополнительный объект ПостПринт обработки',
                    name: 'additionalPostPrintTarget',
                    width: '5%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/postprinttargets',
                },
                data: {
                    name: 'AdditionalPostPrintTargetId',
                    orderName: 'PostPrintTargets.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Формат Бумаги',
                    name: 'paperFormat',
                    width: '3%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperformats',
                },
                data: {
                    name: 'PaperFormatId',
                    orderName: 'PaperFormats.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    // --------------------------------------  TechProcess  ------------------------------------//

    options: {
        url: '/api/table/options',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '60%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            {
                display: {
                    label: 'Описание',
                    name: 'description',
                    width: '40%',
                    type: propType.text,
                },
                data: {
                    name: 'Description',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    printTypes: {
        url: '/api/table/printtypes',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    sectors: {
        url: '/api/table/sectors',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '100%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },
        ],
    },

    techProcessOptions: {
        url: '/api/table/techprocessoptions',
        defaultOrder: {
            name: 'techprocess',
            isAsc: true,
        },
        columns: [

            {
                display: {
                    label: 'ТехПроцесс',
                    name: 'techprocess',
                    width: '50%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/techprocesses',
                },
                data: {
                    name: 'TechProcessId',
                    orderName: 'TechProcesses.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Опция',
                    name: 'option',
                    width: '50%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/options',
                },
                data: {
                    name: 'OptionId',
                    orderName: 'Options.Title',
                    type: backendColumnType.id,
                }
            },
        ],
    },

    techProcesses: {
        url: '/api/table/techprocesses',
        defaultOrder: {
            name: 'Title',
            isAsc: true,
        },
        columns: [
            {
                display: {
                    label: 'Наименование',
                    name: 'title',
                    width: '15%',
                    type: propType.text,
                },
                data: {
                    name: 'Title',
                    type: backendColumnType.string,
                },
            },

            //{
            //    display: {
            //        label: 'Цвет',
            //        name: 'color',
            //        width: '3%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'Color',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Максимальная ширина бумаги',
            //        name: 'maxPaperWidth',
            //        width: '5%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MaxPaperWidth',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Максимальная высота бумаги',
            //        name: 'maxPaperHeight',
            //        width: '5%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MaxPaperHeight',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Минимальная ширина бумаги',
            //        name: 'minPaperWidth',
            //        width: '2%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MinPaperWidth',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Минимальная высота бумаги',
            //        name: 'minPaperHeight',
            //        width: '2%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MinPaperHeight',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'BeforePrintTime',
            //        name: 'beforePrintTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'BeforePrintTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'StartPrintTime',
            //        name: 'startPrintTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'StartPrintTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'OneInstancePrintTime',
            //        name: 'oneInstancePrintTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'OneInstancePrintTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'WaitingPostPrintTime',
            //        name: 'waitingPostPrintTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'WaitingPostPrintTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'DryingTime',
            //        name: 'dryingTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'DryingTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Время проверки',
            //        name: 'checkTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'CheckTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'InstallationTime',
            //        name: 'installationTime',
            //        width: '2%',
            //        type: propType.int,
            //    },
            //    data: {
            //        name: 'InstallationTime',
            //        type: backendColumnType.int,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Себестоимость',
            //        name: 'costPrice',
            //        width: '5%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'CostPrice',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Наценка на материал',
            //        name: 'materialMarkup',
            //        width: '3%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MaterialMarkup',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'PrintRunPrice',
            //        name: 'printRunPrice',
            //        width: '5%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'PrintRunPrice',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Минимальная цена печати',
            //        name: 'minPrintPrice',
            //        width: '3%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MinPrintPrice',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Минимальная цена листа печати',
            //        name: 'minPrintSheetPrice',
            //        width: '3%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'MinPrintSheetPrice',
            //        type: backendColumnType.float,
            //    },
            //},

            //{
            //    display: {
            //        label: 'Коэффициент за один переворот',
            //        name: 'coefficientPerTurnOver',
            //        width: '3%',
            //        type: propType.float,
            //    },
            //    data: {
            //        name: 'CoefficientPerTurnOver',
            //        type: backendColumnType.float,
            //    },
            //},


            {
                display: {
                    label: 'Тип печати',
                    name: 'printType',
                    width: '15%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/printtypes',
                },
                data: {
                    name: 'PrintTypeId',
                    orderName: 'PrintTypes.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Сектор',
                    name: 'sector',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/sectors',
                },
                data: {
                    name: 'SectorId',
                    orderName: 'Sectors.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Склад',
                    name: 'storage',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/storages',
                },
                data: {
                    name: 'StorageId',
                    orderName: 'Storages.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Формат бумаги',
                    name: 'paperFormat',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/paperformats',
                },
                data: {
                    name: 'PaperFormatId',
                    orderName: 'PaperFormats.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Предпочитаемый размер бумаги',
                    name: 'paperSize',
                    width: '10%',
                    type: propType.dropdown,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/papersizes',
                },
                data: {
                    name: 'PaperSizeId',
                    orderName: 'PaperSizes.Title',
                    type: backendColumnType.id,
                }
            },

            {
                display: {
                    label: 'Опции',
                    name: 'options',
                    width: '20%',
                    type: propType.string,
                    valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
                    url: '/api/autocomplete/options',
                },
                data: {
                    name: 'Options',
                    /*orderName: 'Options.Title',*/
                    type: backendColumnType.string,
                }
            },
        ],
    },

    //paperPriceGroups: {
    //    url: '/api/table/paperpricegroups',
    //    defaultOrder: {
    //        name: 'Title',
    //        isAsc: true,
    //    },
    //    columns: [
    //        {
    //            display: {
    //                label: 'Наименование',
    //                name: 'title',
    //                width: '40%',
    //                type: propType.text,
    //            },
    //            data: {
    //                name: 'Title',
    //                type: backendColumnType.string,
    //            },
    //        },
    //        {
    //            display: {
    //                label: 'Ценовая группа Бумаги',
    //                name: 'paperpricegroup',
    //                width: '10%',
    //                type: propType.dropdown,
    //                valueObject: (value) => (<AutocompleteString value={value} prop="title" />),
    //                url: '/api/autocomplete/paperpricegroups',
    //            },
    //            data: {
    //                name: 'PaperPriceGroupId',
    //                orderName: 'PaperPriceGroups.Title',
    //                type: backendColumnType.id,
    //            }
    //        },
    //    ],
    //},
}