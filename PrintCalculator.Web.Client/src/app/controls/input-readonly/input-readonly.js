import { Component } from "react";
import '../ui/ui.css';
import './input-readonly.css';

class InputReadonly extends Component {
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
            <div
                className={"input input-readonly " + this.props.ui + " " + (this.props.label ? 'x2' : 'x1')}
                onClick={this.props.onClick}
            >
                {this.renderLabel()}
                <input
                    type="text"
                    readOnly={true}
                    value={`${this.props.value}${(this.props.suffix) || ''}`}
                />
            </div>
        );
    }
}

export default InputReadonly;