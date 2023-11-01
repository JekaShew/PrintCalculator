import { Component } from "react";
import './dialog.css';
import Widget from "../widget/widget";

class DialogSimple extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="dialog">
                <Widget
                    label={this.props.label}
                    onClose={this.props.onClose}
                >
                    <div className="content">
                        {this.props.children}
                    </div>
                </Widget>
            </div>
        );
    }
}

export default DialogSimple;