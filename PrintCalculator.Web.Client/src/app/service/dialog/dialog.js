import { Component } from "react";
import { connect } from 'react-redux';
import Button from "../../controls/button/button";
import { ui } from "../../controls/ui/ui";
import { faCheck, faTimes } from '@fortawesome/free-solid-svg-icons';
import './dialog.css';
import Widget from "../widget/widget";
import { init, okNo, yes } from "./actions";

class Dialog extends Component {
    constructor(props) {
        super(props);

        this.yes = this.yes.bind(this);
        this.okNo = this.okNo.bind(this);
    }

    yes() {
        this.props.value.yes();
        this.props.yes();
    }

    okNo() {
        let fn = this.props.value.ok || this.props.value.no;
        fn();
        this.props.okNo();
    }

    renderControls() {
        if (this.props.value.yes && this.props.value.no) {
            return (
                <div className="controls x2">
                    <Button ui={ui.o.error} icon={faTimes} onClick={this.okNo} text="Нет" />
                    <Button ui={ui.d.success} icon={faCheck} onClick={this.yes} text="Да" />
                </div>
            );
        } else if (this.props.value.ok) {
            return (
                <div className="controls x1">
                    <Button ui={ui.d.success} icon={faCheck} onClick={this.okNo} text="OK" />
                </div>
            );
        }
    }

    render() {
        if (this.props.value.active) {
            return (
                <div className="dialog">
                    <Widget
                        label={this.props.value.label}
                        onClose={this.okNo}
                    >
                        <div className="content">
                            {this.props.value.content}
                        </div>
                        {this.renderControls()}
                    </Widget>
                </div>
            );
        } else {
            return null;
        }
    }
}

const mapDispatchToProps = dispatch => {
    return {
        init: (data) => dispatch(init(data)),
        yes: () => dispatch(yes()),
        okNo: () => dispatch(okNo()),
    }
}

function mapStateToProps(state) {
    return {
        value: state.dialog,
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(Dialog)