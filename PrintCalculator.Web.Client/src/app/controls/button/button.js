import { Component } from "react";
import './button.css';
import '../ui/ui.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from "@fortawesome/free-solid-svg-icons";

class Button extends Component {
    constructor(props) {
        super(props);

        this.renderIcon = this.renderIcon.bind(this);
    }

    renderIcon() {
        if (this.props.loading) {
            if (this.props.icon)
                return (<FontAwesomeIcon icon={faSpinner} />);
            else
                return null;
        } else {
            if (this.props.icon)
                return (<FontAwesomeIcon icon={this.props.icon} />);
            else
                return null;
        }
    }

    renderText() {
        if (this.props.text)
            return (<span style={(this.props.icon && this.props.text) ? { marginLeft: '0.5rem' } : {}}>{this.props.text}</span>);
        else
            return null;
    }

    render() {
        return (
            <button
                type="button"
                className={"user-button " + this.props.ui + (this.props.loading ? " loading" : "")}
                onClick={this.props.onClick}
                onDoubleClick={this.props.onDoubleClick}
            >
                {this.renderIcon()}
                {this.renderText()}
            </button>
        );
    }
}

export default Button;