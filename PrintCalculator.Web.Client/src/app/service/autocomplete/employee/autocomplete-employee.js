import { Component } from "react";
import config from "../../../../config";
import '../../../controls/ui/ui.css';
import Media from "../../media/media";
import AutocompleteString from "../string/autocomplete-string";
import './autocomplete-employee.css';

class AutocompleteEmployee extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.value)
            return (
                <div className="autocomplete autocomplete-employee">
                    <AutocompleteString height="calc(4rem * var(--font-multiplier))" value={{ title: 'Не выбран' }} prop="title" />
                </div>
            );

        return (
            <div className="autocomplete autocomplete-employee">
                <div className="left">
                    <Media value={this.props.value.mediaId} />
                </div>
                <div className="right">
                    <div className="top">
                        {this.props.value.firstName} {this.props.value.lastName}
                    </div>
                    <div className="bottom">
                        {this.props.value.post}
                    </div>
                </div>
            </div>
        );
    }
}

export default AutocompleteEmployee;