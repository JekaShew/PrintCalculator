import { Component } from "react";
import InputText from "../input-text/input-text";
import '../ui/ui.css';
import './input-float.css';

class InputFloat extends Component {
    constructor(props) {
        super(props);

        this.onChange = this.onChange.bind(this);
        this.onClick = this.onClick.bind(this);
        this.validate = this.validate.bind(this);

        this.state = {
            value: this.props.value,
            isError: false,
        };
    }

    componentWillReceiveProps(nextProps) {
        this.setState({
            value: nextProps.value,
        });
        this.validate(nextProps.value);
    }

    validate(v) {
        if (!isNaN(v)) {
            let parsed = parseFloat(v);
            if (!isNaN(parsed)) {
                if (!this.props.validation
                    || ((this.props.validation.min == undefined || this.props.validation.min <= parsed)
                        && (this.props.validation.max == undefined || this.props.validation.max >= parsed))) {
                    this.setState({
                        isError: false,
                    });
                    return ({
                        valid: true,
                        value: parsed,
                    });
                }
            }
        }
        if (this.props.nullable && !v) {
            this.setState({
                isError: false,
            });
            return ({
                valid: true,
            });
        }
        this.setState({
            isError: true,
        });
        return ({
            valid: false,
        });
    }

    onChange(v) {
        this.setState({
            value: v,
        });
        let result = this.validate(v);
        if (result.valid) {
            this.props.onChange(v);
        }
    }

    onClick(eventargs) {
        eventargs.target.setSelectionRange(0, eventargs.target.value.length);
    }



    render() {
        return (
            <InputText
                ui={this.props.ui}
                label={this.props.label}
                value={this.state.value}
                onChange={this.onChange}
                onFocus={e => this.onClick(e)}
                isError={this.state.isError || this.props.isError}
                largerLabel={this.props.largerLabel}
                crud={this.props.crud}
            />
        );
    }
}

export default InputFloat;