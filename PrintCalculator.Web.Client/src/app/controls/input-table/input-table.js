import { faDownLeftAndUpRightToCenter, faMaximize, faPlus, faTimes } from "@fortawesome/free-solid-svg-icons";
import { Component } from "react";
import Button from "../button/button";
import { buildModelFromProps, buildModelFromPropsExtended } from "../form/crud-form";
import Form from "../form/form";
import { ui } from "../ui/ui";
import '../ui/ui.css';
import './input-table.css';

class InputTable extends Component {
    constructor(props) {
        super(props);

        this.onChange = this.onChange.bind(this);
        this.add = this.add.bind(this);
        this.remove = this.remove.bind(this);
        this.toggle = this.toggle.bind(this);
        this.renderControls = this.renderControls.bind(this);
        this.renderRemoveBtn = this.renderRemoveBtn.bind(this);

        this.state = {
            show: this.props.hide ? false : true,
        };
    }

    toggle() {
        this.setState({
            show: !this.state.show,
        });
    }

    onChange(i, n, v) {
        let data = this.props.data;
        data[i][n] = v;
        this.props.onChange(data);
    }

    add() {
        let rs = this.props.model.rows ? buildModelFromPropsExtended(this.props.model.rows) : buildModelFromProps(this.props.model.props);
        let data = this.props.data;
        data = [...data, rs];
        this.props.onChange(data);
    }

    remove(i) {
        let data = this.props.data;
        data = [...data.slice(0, i), ...data.slice(i + 1)];
        this.props.onChange(data);
    }

    renderControls() {
        if (this.props.crud == true) {
            return (
                <div className="controls">
                    <Button ui={ui.d.primary} icon={this.state.show ? faDownLeftAndUpRightToCenter : faMaximize} onClick={() => this.toggle()} />
                    <Button ui={ui.d.success} icon={faPlus} onClick={() => this.add()} />
                </div>
            );
        }
        else if (this.props.crud == false) {
            return (
                <Button ui={ui.d.primary} icon={this.state.show ? faDownLeftAndUpRightToCenter : faMaximize} onClick={() => this.toggle()} />
            );

        }
    }

    renderRemoveBtn(i) {
        console.log("renderRemoveBtn");
        if (this.props.crud == true) {
            return (
                <Button ui={ui.d.error} icon={faTimes} onClick={() => this.remove(i)} />
                );
        }
        else if (this.props.crud == false) {
            return (<div></div>);
        }
    }

    renderBody() {
        if (!this.state.show)
            return;

        if (this.props.data && this.props.data.length > 0) {
            if (this.props.singleRow)
                return (
                    <div className="content single-row">
                        {
                            this.props.data.map((x, i) => (
                                <div key={i} className={"cols-" + this.props.cols}>
                                    <Form
                                        data={x}
                                        ui={this.props.ui}
                                        model={this.props.model}
                                        onChange={(n, v) => this.onChange(i, n, v)}
                                    />
                                    {
                                        this.renderRemoveBtn(i)
                                    }
                                    
                                </div>
                            ))
                        }
                    </div>
                );
            else
                return (
                    <div className="content">
                        {
                            this.props.data.map((x, i) => (
                                <div key={i} className={"cols-" + this.props.cols }>
                                    <Form
                                        data={x}
                                        ui={this.props.ui}
                                        model={this.props.model}
                                        onChange={(n, v) => this.onChange(i, n, v)}
                                        crud={this.props.crud}
                                    >
                                        
                                    </Form>
                                    {
                                        this.renderRemoveBtn(i)
                                    }
                                </div>
                            ))
                        }
                    </div>
                );
        } else {
            return (
                <div className="content nodata">
                    Нет данных
                </div>
            );
        }
    }

    render() {
        return (
            <div className={"input input-table " + this.props.ui + " "}>
                <div className="header">
                    <div className="label">
                        <span onClick={() => this.toggle()}>{this.props.label} ({this.props.data && this.props.data.length || 0})</span>
                    </div>
                    { this.renderControls()}
                </div>
                {this.renderBody()}
            </div>
        );
    }
}

export default InputTable;