import { Component } from "react";
import Button from "../button/button";
import InputReadonly from "../input-readonly/input-readonly";
import InputText from "../input-text/input-text";
import { ui } from "../ui/ui";
import { faBan, faTimes, faCheck, faPenToSquare } from '@fortawesome/free-solid-svg-icons';
import './form.css';
import InputDate from "../input-date/input-date";
import InputInt from "../input-int/input-int";
import InputPassword from "../input-password/input-password";
import InputFloat from "../input-float/input-float";
import { utils } from "../../service/utils/utils";
import InputObject from "../input-object/input-object";
import InputMedia from "../input-media/input-media";
import InputTable from "../input-table/input-table";
import InputRoles from "../input-roles/input-roles";

export const propType = ({
    hidden: 'hidden',
    text: 'text',
    password: 'password',
    date: 'date',
    int: 'int',
    float: 'float',
    dropdown: 'dropdown',
    readonly: 'readonly',
    media: 'media',
    table: 'table',
    roles: 'roles',
});

export const propDefault = ({
    [propType.hidden]: (prop) => '',
    [propType.text]: (prop) => '',
    [propType.password]: (prop) => '',
    [propType.date]: (prop) => {
        let dd = new Date();
        return utils.date.combine({
            day: (dd.getDate()),
            month: (dd.getMonth() + 1),
            year: dd.getFullYear(),
        });
    },
    [propType.int]: (prop) => '0',
    [propType.float]: (prop) => '0',
    [propType.object]: (prop) => null,
    [propType.readonly]: (prop) => '',
    [propType.media]: (prop) => null,
    [propType.table]: (prop) => [],
    [propType.roles]: (prop) => [],
})

export const formStyle = ({
    x1: 'form-x1',
    x2: 'form-x2',
    x3: 'form-x3',
    x4: 'form-x4',
    x5: 'form-x5',
    x6: 'form-x6',
    w2x9: 'form-w2-x9',
    x9: 'form-x9',
});

export const colStyle = ({
    w1: 'col-w-1',
    w1x2: 'col-w-1-2',
    w1x3: 'col-w-1-3',
    w2x3: 'col-w-2-3',
});

export const formControls = ({
    save: 'save',
    saveCancel: 'saveCancel',
    saveCancelDelete: 'saveCancelDelete'
    ,
});

class Form extends Component {
    constructor(props) {
        super(props);
        this.renderProp = this.renderProp.bind(this);
        this.renderControls = this.renderControls.bind(this);
        this.renderChildren = this.renderChildren.bind(this);
        this.renderEditBtn = this.renderEditBtn.bind(this);
        this.save = this.save.bind(this);
    }

    renderProp(prop, key) {
            
            switch (prop.type) {
                case propType.text:
                    return (
                        <InputText
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            isError={this.props.errors[prop.name]}
                            validation={prop.validation}
                            crud={this.props.crud}
                        />
                    );
                case propType.password:
                    return (
                        <InputPassword
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            isError={this.props.errors[prop.name]}
                            validation={prop.validation}
                            crud={this.props.crud}
                        />
                    );
                case propType.readonly:
                    return (
                        <InputReadonly
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={prop.func(this.props.data)}
                            suffix={prop.suffix}
                            validation={prop.validation}
                            crud={this.props.crud}
                        />
                    );
                case propType.date:
                    return (
                        <InputDate
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            validation={prop.validation}
                            crud={this.props.crud}
                        />
                    );
                case propType.int:
                    return (
                        <InputInt
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            validation={prop.validation}
                            nullable={prop.nullable}
                            largerLabel={prop.largerLabel}
                            crud={this.props.crud}
                        />
                    );
                case propType.float:
                    return (
                        <InputFloat
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            validation={prop.validation}
                            nullable={prop.nullable}
                            largerLabel={prop.largerLabel}
                            crud={this.props.crud}
                        />
                    );
                case propType.object:
                    return (
                        <InputObject
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            validation={prop.validation}
                            valueObject={prop.valueObject}
                            url={prop.url}
                            crud={this.props.crud}
                        />
                    );
                case propType.media:
                    return (
                        <InputMedia
                            ui={prop.ui || this.props.ui}
                            size={prop.size}
                            key={key}
                            label={prop.label}
                            value={this.props.data[prop.name]}
                            onChange={v => this.props.onChange(prop.name, v)}
                            validation={prop.valiadation}
                            crud={this.props.crud}
                        />
                    );
                case propType.table:
                    console.log("InputTable");
                    return (
                        <InputTable
                            ui={prop.ui || this.props.ui}
                            key={key}
                            label={prop.label}
                            data={this.props.data[prop.name]}
                            model={prop.model}
                            onChange={v => this.props.onChange(prop.name, v)}
                            hide={prop.hide}
                            cols={prop.cols}
                            singleRow={prop.singleRow}
                            crud={this.props.crud}
                        />
                    );
                case propType.roles:
                    return (
                        <InputRoles
                            key={key}
                            label={prop.label}
                            onChange={v => this.props.onChange(prop.name, v)}
                            value={this.props.data[prop.name]}
                            crud={this.props.crud}
                        />
                    );
                case propType.hidden:
                    return null;
                default:
                    return null;
            }
      
    }

    getPropValue(prop) {
        switch (prop.type) {
            case propType.text:
                return this.props.data[prop.name];
            case propType.password:
                return this.props.data[prop.name];
            case propType.readonly:
                return prop.func(this.props.data);
            case propType.date:
                return this.props.data[prop.name];
            case propType.hidden:
                return this.props.data[prop.name];
            case propType.int:
                return this.props.data[prop.name];
            case propType.float:
                return this.props.data[prop.name];
            case propType.object:
                return this.props.data[prop.name];
            case propType.media:
                return this.props.data[prop.name];
            case propType.table:
                return this.props.data[prop.name];
            case propType.roles:
                return this.props.data[prop.name];
            default:
                return null;
        }
    }

    save() {
        let props = this.props.model.rows
            ? (
                this.props.model.rows.map(row =>
                    row.columns.map(col => col.props)
                ).reduce((r, c) => [...r, ...c])
            ).reduce((r, c) => [...r, ...c])
            : this.props.model.props;
        let data = Object.fromEntries([
            ...props.map(prop => [prop.name, this.getPropValue(prop)])
        ]);
        this.props.controls.save(data);
    }

    renderControls() {
        if (this.props.crud) {
            if (this.props.controls) {
                let result = [];
                if (this.props.controls.cancel)
                    result.push(
                        <Button ui={ui.d.dark} icon={faTimes} onClick={this.props.controls.cancel} text="Отмена" />
                    );
                if (this.props.controls.delete)
                    result.push(
                        <Button ui={ui.o.error} icon={faBan} onClick={this.props.controls.delete} text="Удалить" />
                    );
                if (this.props.controls.save) {
                    if (this.props.data.id)
                        result.push(
                            <Button ui={ui.d.success} icon={faCheck} onClick={this.save} text="Сохранить" />
                        );
                    else
                        result.push(
                            <Button ui={ui.d.success} icon={faCheck} onClick={this.save} text="Добавить" />
                        );
                }
                return (
                    <div className={"controls x" + result.length}>
                        {result}
                    </div>
                );
            }
            else {

                if (this.props.controls) {
                    let result = [];
                    if (this.props.controls.cancel)
                        result.push(
                            <Button ui={ui.d.dark} icon={faTimes} onClick={this.props.controls.cancel} text="Отмена" />
                        );
                }

            }
        }
    }

    renderChildren() {
        if (this.props.children) {
            return (
                <div className="custom">
                    {this.props.children}
                </div>
            );
        } else {
            return null;
        }
    }

    renderEditBtn(crud) {
        if (!crud) {
            return (
                <Button
                    width="70%"
                    text="Редактировать"
                    ui={ui.d.secondary}
                    icon={faPenToSquare}
                    onClick={() => this.props.onEditBtnClick(this.props.data.id)}
                />
            )
        }
    }

    renderProps() {
        if (this.props.model.rows)
            return (
                
                    <div className="props-extended">
                        {
                            this.props.model.rows.map((row, i) => (
                                <div className={"props-row height-" + row.height}>
                                    {
                                        row.columns.map((col, j) => (
                                            <div className={"props-col " + col.width}>
                                                {
                                                    col.props.map((prop, k) => this.renderProp(prop, i * 50 + j * 5 + k))
                                                }
                                            </div>
                                        ))
                                    }
                                </div>
                            ))
                        }
                        {
                            this.renderEditBtn(this.props.crud)
                        }
                    </div>
                   
            );
        else if (this.props.model.props)
            return (
                <div className="props">
                    {
                        this.props.model.props.map((prop, i) => this.renderProp(prop, i))
                    }
                </div>
            );
    }

    render() {
        return (
            <div className={"form " + (this.props.ui || 'x1')}>
                {this.renderProps()}
                {this.renderChildren()}
                {this.renderControls()}
            </div>
        );
    }
}

export default Form;