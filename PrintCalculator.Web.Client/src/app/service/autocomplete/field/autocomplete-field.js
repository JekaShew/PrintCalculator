import { Component } from "react";
import '../../../controls/ui/ui.css';
import AutocompleteString from "../string/autocomplete-string";
import './autocomplete-field.css';

class AutocompleteField extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.value)
            return (
                <div className="autocomplete autocomplete-field">
                    <AutocompleteString height="calc(2.5rem * var(--font-multiplier))" value={{ title: 'Не выбран' }} prop="title" />
                </div>
            );

        return (
            <div className="autocomplete autocomplete-field">
                <div className="top">
                    {this.props.value.name}
                </div>
                <div className="bottom">
                    <div className="left">
                        {this.props.value.organization}
                    </div>
                    <div className="right">
                        {this.props.value.area + " га"}
                    </div>
                </div>
            </div>
        );
    }
}

export default AutocompleteField;