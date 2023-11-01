import { colStyle, formStyle, propType } from '../../controls/form/form';
import AutocompleteField from '../autocomplete/field/autocomplete-field';
import AutocompleteString from '../autocomplete/string/autocomplete-string';
import AutocompleteEmployee from '../autocomplete/employee/autocomplete-employee';
import { utils } from '../utils/utils';
import AutocompleteUnit from '../autocomplete/unit/autocomplete-unit';
import { faFileWord } from '@fortawesome/free-solid-svg-icons';



export const backendColumnType = {
    string: "PrintCalculator.UI.Gen2.Table.ColumnFilters.StringColumnFilter, PrintCalculator.UI.Gen2",
    int: "PrintCalculator.UI.Gen2.Table.ColumnFilters.IntColumnFilter, PrintCalculator.UI.Gen2",
    float: "PrintCalculator.UI.Gen2.Table.ColumnFilters.FloatColumnFilter, PrintCalculator.UI.Gen2",
    date: "PrintCalculator.UI.Gen2.Table.ColumnFilters.DateColumnFilter, PrintCalculator.UI.Gen2",
    id: "PrintCalculator.UI.Gen2.Table.ColumnFilters.IdColumnFilter, PrintCalculator.UI.Gen2"
};

export const filterFromTable = (table) => {
    return Object.fromEntries(table.columns.map((x) => [x.display.name, ({
        ["$type"]: x.data.type,
        name: x.data.name,
        ...propTypeToFilter[x.display.type],
    })]));
};

const propTypeToFilter = {
    [propType.text]: ({ query: '' }),
    [propType.float]: ({ min: '', max: '' }),
    [propType.int]: ({ min: '', max: '' }),
    [propType.date]: ({ min: '', max: '' }),
    [propType.dropdown]: null,
};
