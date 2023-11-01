import { faCheck } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Component } from "react";
import { utils } from "../../service/utils/utils";
import '../ui/ui.css';
import './input-roles.css';

const roles = [
    { label: 'Сотрудники', roles: ["EMPLOYEES_GET", "EMPLOYEES_ADD", "EMPLOYEES_UPDATE", "EMPLOYEES_DELETE"] },
    { label: 'Поля', roles: ["FIELDS_GET", "FIELDS_ADD", "FIELDS_UPDATE", "FIELDS_DELETE"] },
    { label: 'Путевые листы', roles: ["WAYBILLS_GET", "WAYBILLS_ADD", "WAYBILLS_UPDATE", "WAYBILLS_DELETE"] },
    { label: 'Заправки', roles: ["REFUELS_GET", "REFUELS_ADD", "REFUELS_UPDATE", "REFUELS_DELETE"] },
    { label: 'Работы', roles: ["JOBS_GET", "JOBS_ADD", "JOBS_UPDATE", "JOBS_DELETE"] },
    { label: 'Справочники', roles: ["REFERENCES_GET", "REFERENCES_ADD", "REFERENCES_UPDATE", "REFERENCES_DELETE"] },
    { label: 'Техника', roles: ["UNITS_GET", "UNITS_ADD", "UNITS_UPDATE", "UNITS_DELETE"] },
    { label: 'Пользователи', roles: ["USERS_GET", "USERS_ADD", "USERS_UPDATE", "USERS_DELETE"] },
];

const rolesCount = roles.map(x => x.roles.length).reduce((r, c) => r + c, 0);

class InputRoles extends Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.toggleRow = this.toggleRow.bind(this);
        this.toggleCol = this.toggleCol.bind(this);
        this.toggleAll = this.toggleAll.bind(this);
        this.renderCheck = this.renderCheck.bind(this);
        this.renderLabel = this.renderLabel.bind(this);
    }

    toggle(role) {
        let roles = this.props.value;
        if (roles && roles.includes(role))
            roles = roles && roles.filter(x => x != role);
        else
            roles = [...roles, role];
        this.props.onChange(roles || []);
    }

    toggleRow(roles) {
        let result = this.props.value;
        if (utils.array.includesAll(result, roles)) {
            result = result && result.filter(x => !roles.includes(x));
        } else {
            result = [...result, ...roles.filter(x => !result.includes(x))];
        }
        this.props.onChange(result || []);
    }

    toggleCol(ix) {
        this.toggleRow(roles.map(x => x.roles[ix]))
    }

    toggleAll() {
        let result = [];
        if (this.props.value && this.props.value.length == rolesCount)
            result = [];
        else
            result = roles.map(x => x.roles).reduce((r, c) => [...r, ...c], []);
        this.props.onChange(result || []);
    }

    renderLabel() {
        if (this.props.label) {
            return (
                <div className="label">
                    {this.props.label}
                </div>
            );
        }
    }

    renderCheck(checked, onClick) {
        let check = null;
        if (checked)
            check = (
                <FontAwesomeIcon icon={faCheck} />    
            );
        return (
            <div
                className={"checkbox" + (checked ? ' checked' : '')}
                onClick={onClick}
            >
                {check}
            </div>
        );
    }

    render() {
        return (
            <div className="input input-roles">
                {this.renderLabel()}
                <table>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Все</th>
                            <th>Чтение</th>
                            <th>Добавление</th>
                            <th>Изменение</th>
                            <th>Удаление</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Все</td>
                            <td>
                                {this.renderCheck(
                                    this.props.value && this.props.value.length == rolesCount,
                                    () => this.toggleAll()
                                )}
                            </td>
                            <td>
                                {this.renderCheck(
                                    utils.array.includesAll(this.props.value, roles.map(x => x.roles[0])),
                                    () => this.toggleCol(0)
                                )}
                            </td>
                            <td>
                                {this.renderCheck(
                                    utils.array.includesAll(this.props.value, roles.map(x => x.roles[1])),
                                    () => this.toggleCol(1)
                                )}
                            </td>
                            <td>
                                {this.renderCheck(
                                    utils.array.includesAll(this.props.value, roles.map(x => x.roles[2])),
                                    () => this.toggleCol(2)
                                )}
                            </td>
                            <td>
                                {this.renderCheck(
                                    utils.array.includesAll(this.props.value, roles.map(x => x.roles[3])),
                                    () => this.toggleCol(3)
                                )}
                            </td>
                        </tr>
                        {
                            roles.map((x, i) => (
                                <tr key={i}>
                                    <td>
                                        {x.label}
                                    </td>
                                    <td>
                                        {this.renderCheck(
                                            utils.array.includesAll(this.props.value, x.roles),
                                            () => this.toggleRow(x.roles)
                                        )}
                                    </td>
                                    {
                                        x.roles.map((role, j) => (
                                            <td key={i * 4 + j}>
                                                {this.renderCheck(
                                                    this.props.value && this.props.value.includes(role),
                                                    () => this.toggle(role)
                                                )}
                                            </td>
                                        ))
                                    }
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

export default InputRoles;