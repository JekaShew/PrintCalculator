import { faTimes } from "@fortawesome/free-solid-svg-icons";
import React, { Component } from "react";
/*import { assets } from "../../../assets/assets";*/
import config from "../../../config";
import Button from "../button/button";
import { ui } from "../ui/ui";
import '../ui/ui.css';
import './input-media.css';

class InputMedia extends Component {
    constructor(props) {
        super(props);

        this.renderLabel = this.renderLabel.bind(this);
        this.renderRemove = this.renderRemove.bind(this);
        this.onMediaChange = this.onMediaChange.bind(this);

        this.state = {
            update: '',
        };
    }

    onMediaChange(value) {
        if (value == null) {
            this.props.onChange(null);
            this.setState({
                update: '',
            });
        } else {
            this.props.onChange({
                update: value,
            });
            let reader = new FileReader();
            let self = this;
            reader.onload = e => {
                self.setState({
                    update: e.target.result,
                });
            }
            reader.readAsDataURL(value);
        }
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

    renderRemove() {
        if (this.state.update || this.props.value) {
            return (
                <div className="remove">
                    <Button
                        icon={faTimes}
                        ui={ui.d.error}
                        onClick={() => this.onMediaChange(null)}
                    />
                </div>
            );
        }
    }

    render() {
        return (
            <div className={"input input-media " + this.props.ui + " " + (this.props.isError ? 'error ' : '')}>
                {this.renderLabel()}
                <div className="content">
                    <img
                        src={
                            this.state.update ? (
                                this.state.update    
                            ) : (
                                (this.props.value)
                                    ? (config.apiHost + "/media/" + this.props.value.id + ".png")
                                    : ("")
                            )
                        }
                        style={{
                            width: 'calc(' + this.props.size + 'rem * var(--font-multiplier))',
                            height: 'calc(' + this.props.size + 'rem * var(--font-multiplier))',
                        }}
                    />
                    <input
                        type="file"
                        onChange={e => this.onMediaChange(e.target.files[0])}
                        onClick={e => e.target.value = null}
                    />
                    <div className="edit">
                        <Button
                            text={this.state.update || this.props.value ? "Изменить" : "Добавить"}
                            ui={ui.d.secondary}
                        />
                    </div>
                    {this.renderRemove()}
                </div>
            </div>
        );
    }
}

export default InputMedia;