import { propType } from "../form/form";
import InputDate from "../input-date/input-date";
import InputFloat from "../input-float/input-float";
import InputInt from "../input-int/input-int";
import InputObject from "../input-object/input-object";
import InputText from "../input-text/input-text";

const propTypeToFilterRender = {
    [propType.text]: (filter, onFilterChange, column) => (
        <div className="column-filter text">
            <InputText
                label={'Поиск'}
                value={filter[column.display.name].query}
                onChange={v => onFilterChange(column.display.name, 'query', v)}
            />
        </div>
    ),
    [propType.int]: (filter, onFilterChange, column) => (
        <div className="column-filter int">
            <InputInt
                label={'От'}
                value={filter[column.display.name].min}
                onChange={v => onFilterChange(column.display.name, 'min', v)}
                nullable={true}
            />
            <InputInt
                label={'До'}
                value={filter[column.display.name].max}
                onChange={v => onFilterChange(column.display.name, 'max', v)}
                nullable={true}
            />
        </div>
    ),
    [propType.float]: (filter, onFilterChange, column) => (
        <div className="column-filter float">
            <InputFloat
                label={'От'}
                value={filter[column.display.name].min}
                onChange={v => onFilterChange(column.display.name, 'min', v)}
                nullable={true}
            />
            <InputFloat
                label={'До'}
                value={filter[column.display.name].max}
                onChange={v => onFilterChange(column.display.name, 'max', v)}
                nullable={true}
            />
        </div>
    ),
    [propType.date]: (filter, onFilterChange, column) => (
        <div className="column-filter date">
            <InputDate
                label="От"
                value={filter[column.display.name].min}
                onChange={v => onFilterChange(column.display.name, 'min', v)}
            />
            <InputDate
                label="До"
                value={filter[column.display.name].max}
                onChange={v => onFilterChange(column.display.name, 'max', v)}
            />
        </div>
    ),
    [propType.dropdown]: (filter, onFilterChange, column) => (
        <div className="column-filter object">
            <InputObject
                label={'Поиск'}
                value={filter[column.display.name].id}
                onChange={v => onFilterChange(column.display.name, 'id', v)}
                valueObject={column.display.valueObject}
                url={column.display.url}
            />
        </div>
    )
}

export const renderFilter = (filter, onFilterChange, column) => propTypeToFilterRender[column.display.type](filter, onFilterChange, column);