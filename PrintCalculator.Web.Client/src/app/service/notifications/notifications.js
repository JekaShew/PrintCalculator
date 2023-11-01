import { Component } from "react";
import { connect } from 'react-redux';
import './notifications.css';
import Widget from "../widget/widget";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { add, remove, removeAll } from "./actions";
// TODO : dont delete, some huinya happening
import { dialog } from "../dialog/service";

class Notifications extends Component {
    constructor(props) {
        super(props);

        this.renderNotification = this.renderNotification.bind(this);
        this.renderIcon = this.renderIcon.bind(this);
    }

    renderIcon(x) {
        if (x.icon) {
            return (
                <div className={"icon " + x.ui}>
                    <FontAwesomeIcon icon={x.icon} />
                </div>
            );
        }
    }

    renderNotification(x, i) {
        return (
            <div key={x.id} className={"item" + (x.content ? '' : ' no-content')}>
                {this.renderIcon(x)}
                <Widget
                    label={x.title}
                    onClose={() => this.props.remove(x.id)}
                >
                    {x.content || ' '}
                </Widget>
            </div>
        );
    }

    render() {
        return (
            <div className="notifications">
                <div className="items">
                    {
                        this.props.value.items.map((x, i) => 
                            this.renderNotification(x, i)
                        )
                    }
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = dispatch => {
    return {
        add: (data) => dispatch(add(data)),
        remove: (i) => dispatch(remove(i)),
        removeAll: () => dispatch(removeAll()),
    }
}

function mapStateToProps(state) {
    return {
        value: state.notifications,
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(Notifications)