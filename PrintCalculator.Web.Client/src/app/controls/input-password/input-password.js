import { Component } from "react";
import '../ui/ui.css';
import './input-password.css';

class InputPassword extends Component {
    constructor(props) {
        super(props);

        this.renderLabel = this.renderLabel.bind(this);
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

    render() {
        return (
            <div className={"input input-password " + this.props.ui + " " + (this.props.isError ? 'error ' : '') + (this.props.label ? 'x2' : 'x1')}>
                {this.renderLabel()}
                <input
                    type="password"
                    value={this.props.value}
                    onChange={e => this.props.onChange(e.target.value)}
                />
            </div>
        );
    }
}

export default InputPassword;