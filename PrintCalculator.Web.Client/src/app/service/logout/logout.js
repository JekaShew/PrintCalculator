import { Component } from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router";
import { signOut } from "../authorization/actions";
import { notifications } from "../notifications/service";

class Logout extends Component {
    constructor(props) {
        super(props);

        notifications.preset.success({
            title: 'Выход выполнен',
        });

        this.props.signOut();
    }

    render() {
        return (<Redirect to="/Login" />);
    }
}

const mapDispatchToProps = dispatch => {
    return {
        signOut: () => dispatch(signOut()),
    }
}

function mapStateToProps(state) {
    return {
        authorization: state.authorization,
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(Logout)