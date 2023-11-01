import { Component } from "react";
import Button from "../../controls/button/button";
import { ui } from "../../controls/ui/ui";
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import './widget.css';

class Widget extends Component {
    constructor(props) {
        super(props);

        this.renderClose = this.renderClose.bind(this);
    }

    renderClose() {
        if (!this.props.noClose && this.props.onClose) {
            return (
                <div className="close">
                    {this.props.customControls}
                    <Button ui={ui.o.dark} icon={faTimes} onClick={this.props.onClose} />
                </div>
            );
        }
    }

    render() {
        return (
            <div className="widget">
                <div className="header">
                    <div className="label">
                        {this.props.label}
                    </div>
                    {this.renderClose()}
                </div>
                <div className="content">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

export default Widget;