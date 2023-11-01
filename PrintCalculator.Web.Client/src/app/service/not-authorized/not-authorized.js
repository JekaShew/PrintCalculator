import { Component } from "react";
import { Redirect } from "react-router";
import { notifications } from "../notifications/service";

class NotAuthorized extends Component {
    constructor(props) {
        super(props);

        notifications.preset.danger({
            title: 'Вход не выполнен',
        });
    }

    render() {
        return (<Redirect to="/Login" />);
    }
}

export default NotAuthorized;