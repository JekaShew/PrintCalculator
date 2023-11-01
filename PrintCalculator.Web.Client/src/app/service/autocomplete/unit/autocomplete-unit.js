import { Component } from "react";
import config from "../../../../config";
import '../../../controls/ui/ui.css';
import Media from "../../media/media";
import AutocompleteString from "../string/autocomplete-string";
import './autocomplete-unit.css';

class AutocompleteUnit extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.value)
            return (
                <div className="autocomplete autocomplete-unit">
                    <AutocompleteString height="calc(4rem * var(--font-multiplier))" value={{ title: 'Не выбран' }} prop="title" />
                </div>
            );

        return (
            <div className="autocomplete autocomplete-unit">
                <div className="left">
                    <Media value={this.props.value.mediaId} />
                </div>
                <div className="right">
                    <div className="top">
                        {this.props.value.number}
                    </div>
                    <div className="bottom">
                        {this.props.value.type}
                    </div>
                </div>
            </div>
        );
    }
}

export default AutocompleteUnit;