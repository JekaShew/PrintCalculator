import { faSpinner } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Component } from "react";
import AutocompleteString from "../../service/autocomplete/string/autocomplete-string";
import { apiFetch } from "../../service/remote/api-service";
import Widget from "../../service/widget/widget";
import InputText from "../input-text/input-text";
import '../ui/ui.css';
import './input-object.css';

const popupSize = {
    width: 360,
    height: 376,
    half: {
        width: 180,
        height: 188,
    },
}

class InputObject extends Component {
    constructor(props) {
        super(props);

        this.renderLabel = this.renderLabel.bind(this);
        this.togglePopup = this.togglePopup.bind(this);
        this.onQueryChange = this.onQueryChange.bind(this);
        this.load = this.load.bind(this);
        this.onChange = this.onChange.bind(this);
        this.renderItems = this.renderItems.bind(this);
        this.renderValue = this.renderValue.bind(this);

        this.state = {
            autocomplete: {
                items: [],
                query: '',
            },
            show: false,
            loading: true,
        };
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

    togglePopup() {
        if (!this.state.show) {
            this.setState({
                autocomplete: {
                    query: '',
                    items: [],
                },
            });
            this.load('');
        }

        this.setState({
            show: !this.state.show,
        });
    }

    load(query) {
        let self = this;
        let remote = {
            url: this.props.url + '/?query=' + query,
            type: 'get',
        };
        let events = {
            start: () => {
                self.setState({
                    loading: true,
                });
            },
            success: (data) => {
                self.setState({
                    autocomplete: {
                        ...self.state.autocomplete,
                        items: data,
                    },
                    data: data,
                    loading: false,
                });
            },
            error: () => {
                self.setState({
                    loading: false,
                });
            }
        };
        apiFetch(remote, events);
    }

    onQueryChange(v) {
        this.setState({
            autocomplete: {
                ...this.state.autocomplete,
                query: v,
            },
        });
        this.load(v);
    }

    onChange(item) {
        if (item && item.id) {
            this.props.onChange({
                value: item.id,
                vm: item,
            });
        } else {
            this.props.onChange(null);
        }
        this.togglePopup();
    }

    renderItems() {
        if (this.state.loading) {
            return (
                <div className="items loading">
                    <FontAwesomeIcon icon={faSpinner} />
                </div>
            );
        } else {
            return (
                <div className="items">
                    <div className="item" onClick={() => this.onChange(null)}>
                        {this.props.valueObject(null)}
                    </div>
                    {
                        this.state.autocomplete.items.map(x => (
                            <div
                                key={x.id}
                                className="item"
                                onClick={() => this.onChange(x)}
                            >
                                {this.props.valueObject(x)}
                            </div>
                        ))
                    }
                </div>
            );
        }
    }

    renderValue() {
        if(this.props.crud == true)
        {
            return (
                <div className="content">
                    {this.renderLabel()}
                    <div
                        className="value"
                        onClick={this.togglePopup}
                    >
                        {this.props.valueObject(this.props.value && this.props.value.vm)}
                    </div>
                </div>
                );
        }
        else if(this.props.crud == false)
        {
            return(
                <div className="content">
                    {this.renderLabel()}
                    <div
                        className="value"
                    >
                        {this.props.valueObject(this.props.value && this.props.value.vm)}
                    </div>
                </div>
            );
        }
    }

    render() {
        return (
            <div
                className={"input input-object " + this.props.ui + " " + (this.props.label ? 'x2' : 'x1')}
                onClick={this.props.onClick}
            >
               {this.renderValue()}
                <div
                    className="popup"
                    style={{
                        display: (this.state.show ? 'block' : 'none'),
                        //left: popupSize.half.width,
                    }}
                >
                    <Widget
                        label={this.props.label}
                        onClose={this.togglePopup}
                    >
                        <div className="top">
                            <InputText
                                value={this.state.autocomplete.query}
                                onChange={this.onQueryChange}
                            />
                        </div>
                        {this.renderItems()}
                    </Widget>
                </div>
            </div>
        );
    }
}

export default InputObject;