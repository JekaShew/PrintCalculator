import { Component } from "react";
import Button from "../button/button";
import './input-date.css';
import { ui } from "../ui/ui";
import InputReadonly from "../input-readonly/input-readonly";
import '../ui/ui.css';
import Widget from "../../service/widget/widget";
import { lastDayOfMonth, startOfMonth, endOfMonth, format, addDays, startOfISOWeek, endOfISOWeek, getMonth, getDay } from "date-fns";
import InputInt from "../input-int/input-int";
import { utils } from "../../service/utils/utils";
import { faRotate, faTrash } from "@fortawesome/free-solid-svg-icons";

const daysOfWeek = [
    'Пн',
    'Вт',
    'Ср',
    'Чт',
    'Пт',
    'Сб',
    'Вс',
]

const popupSize = {
    width: 360,
    height: 376,
    half: {
        width: 180,
        height: 188,
    },
}

class InputDate extends Component {
    constructor(props) {
        super(props);
        
        this.onChange = this.onChange.bind(this);
        this.getDays = this.getDays.bind(this);
        this.togglePopup = this.togglePopup.bind(this);
        this.getMaxDay = this.getMaxDay.bind(this);
        this.validate = this.validate.bind(this);
        this.reset = this.reset.bind(this);

        let now = new Date();
        this.state = {
            ...(this.props.value
                ? this.validate(utils.date.split(this.props.value))
                : this.validate(utils.date.split((now.getDate()) + '.' + (now.getMonth() + 1) + '.' + now.getFullYear()))
            ),
            currentDay: getDay(now),
            show: false,
        };
    }

    reset() {
        this.props.onChange(null);
    }

    getMaxDay(state) {
        if (!state)
            state = this.state;
        let dd = new Date(state.year, parseInt(state.month) - 1, 1);
        let lastDay = lastDayOfMonth(dd).getDate();
        return lastDay;
    }

    getDays() {
        let mm = this.state.month;
        if (mm < 1)
            mm = 1;
        if (mm > 12)
            mm = 12;
        let monthDate = new Date(this.state.year, mm - 1, this.state.day);

        const monthStart = startOfMonth(monthDate);
        const monthEnd = endOfMonth(monthDate);

        const startOfWeek = startOfISOWeek(monthStart);
        const endOfWeek = endOfISOWeek(monthEnd);
        let month = getMonth(monthDate);
        let now = new Date();

        let result = [];
        let date = startOfWeek;
        while (date <= endOfWeek) {
            let week = [];
            for (let i = 0; i < 7; i++) {
                let day = format(date, "d");
                if (getMonth(date) != month)
                    day = 0;
                week = [
                    ...week,
                    {
                        day: day,
                        isSelected: this.props.value
                            ? (
                                date.getDate() == this.state.day &&
                                date.getMonth() == this.state.month - 1 &&
                                date.getFullYear() == this.state.year
                            ) : false,
                        isNow: (
                            now.getDate() == date.getDate() &&
                            now.getMonth() == date.getMonth() &&
                            now.getFullYear() == date.getFullYear()
                        ),
                    },
                ];
                date = addDays(date, 1);
            }
            result = [
                ...result,
                week,
            ];
        }
        return result;
    }

    validate(state) {
        let day = state.day;
        let month = state.month;
        let year = state.year;

        let maxDay = this.getMaxDay(state);

        return ({
            ...state,
            day: utils.int.clamp(day, 1, maxDay),
            month: utils.int.clamp(month, 1, 12),
            year: utils.int.clamp(year, 1900, 2100),
        });
    }

    onChange(name, value) {
        let state = {
            ...this.state,
            [name]: value,
        };
        this.props.onChange(utils.date.combine(this.validate(state)));
    }

    togglePopup() {
        this.setState({
            show: !this.state.show,
        });
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.value) {
            this.setState({
                ...this.validate(utils.date.split(nextProps.value)),
            });
        }
    }

    render() {
        return (
            <div className={"input input-date " + this.props.ui}>
                <InputReadonly
                    label={this.props.label}
                    value={this.props.value || ''}
                    onClick={this.togglePopup}
                />
                <div
                    className="popup"
                    style={{
                        display: (this.state.show ? 'flex' : 'none'),
                        //top: -popupSize.half.height,
                        //left: popupSize.half.width,
                    }}
                >
                    <Widget
                        label={this.props.label}
                        onClose={this.togglePopup}
                        customControls={(<Button ui={ui.o.error} icon={faRotate} onClick={this.reset} />)}
                    >
                        <div className="header">
                            <InputInt
                                value={this.state.day}
                                onChange={e => this.onChange('day', e)}
                                validation={{
                                    min: 1,
                                    max: this.getMaxDay(),
                                }}
                            />
                            <InputInt
                                value={this.state.month}
                                onChange={e => this.onChange('month', e)}
                                validation={{
                                    min: 1,
                                    max: 12,
                                }}
                            />
                            <InputInt
                                value={this.state.year}
                                onChange={e => this.onChange('year', e)}
                                validation={{
                                    min: 1900,
                                    max: 2100,
                                }}
                            />
                        </div>
                        <div className="calendar">
                            <div className="days-of-week">
                                {
                                    daysOfWeek.map(d => (
                                        <InputReadonly
                                            key={d}
                                            value={d}
                                        />
                                    ))
                                }
                            </div>
                            <div className="table">
                                {
                                    this.getDays().map((w, i) => (
                                        <div className="week" key={i}>
                                            {
                                                w.map((d, i) => (
                                                    d.day == 0 ? (
                                                        <InputReadonly
                                                            key={i}
                                                            value={' '}
                                                        />
                                                    ) : (
                                                            <Button
                                                                key={i}
                                                                text={d.day}
                                                                ui={(
                                                                    d.isSelected
                                                                        ? ui.d.success
                                                                        : (
                                                                            d.isNow
                                                                                ? ui.d.primary
                                                                                : ui.o.primary
                                                                        )
                                                                )}
                                                                onClick={e => this.onChange('day', d.day)}
                                                        />
                                                    )
                                                ))
                                            }
                                        </div>
                                    ))
                                }
                            </div>
                        </div>
                    </Widget>
                </div>
            </div>
        );
    }
}

export default InputDate;