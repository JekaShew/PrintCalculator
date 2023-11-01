import { Component } from "react";
import '../ui/ui.css';
import './input-text.css';

class InputText extends Component {
    constructor(props) {
        super(props);

        this.renderLabel = this.renderLabel.bind(this);
        this.renderInput = this.renderInput.bind(this);
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

    renderInput() {
        console.log("InputTextForm");
        if (this.props.crud == true) 
        {
            return (
                <input
                    className="inputText"
                    type="text"
                    value={this.props.value}
                    onChange={e => this.props.onChange(e.target.value)}
                    onFocus={this.props.onFocus}
                    onWheel={this.props.onWheel}
                />
            );
        }
        else if (this.props.crud == false ) 
        {
            return (
                <input
                    className="inputText-readOnly"
                    type="text"
                    value={this.props.value}
                    readOnly
                />
                
            );
        }
    }

    render() {
        return (
            <div className={"input input-text " + this.props.ui + " " + (this.props.isError ? 'error ' : '') + 'inputDiv'/*(this.props.label ? (this.props.largerLabel ? 'x3' : 'x2') : 'x1')*/}>
                {this.renderLabel()}
                {this.renderInput()}
            </div>
        );
    }
}

export default InputText;