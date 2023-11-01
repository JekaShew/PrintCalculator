import { Component } from "react";
import '../../../controls/ui/ui.css';
import './autocomplete-string.css';

class AutocompleteString extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.value)
            return (
                <div className="autocomplete autocomplete-string" style={this.props.height ? ({ height: this.props.height }) : null}>
                    Не выбран
                </div>
            );

        return (
            <div className="autocomplete autocomplete-string" style={this.props.height ? ({ height: this.props.height }) : null}>
                {this.props.value[this.props.prop]}
            </div>
        );
    }
}

export default AutocompleteString;