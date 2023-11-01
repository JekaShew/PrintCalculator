import store from "../../../store";
import { add, remove } from "./actions";
import { faCheck, faCircleExclamation, faTriangleExclamation, faCircleInfo } from '@fortawesome/free-solid-svg-icons';
import { ui } from "../../controls/ui/ui";

export const notifications = ({
    push: (data) => {
        data.id = Math.floor(Math.random() * 10000);
        store.dispatch(add(data));
        setTimeout(() => {
            store.dispatch(remove(data.id));
        }, 3000);
    },
    preset: {
        success: (data) => {
            data.icon = faCheck;
            data.ui = ui.t.success;
            notifications.push(data);
        },
        error: (data) => {
            data.icon = faCircleExclamation;
            data.ui = ui.t.error;
            notifications.push(data);
        },
        danger: (data) => {
            data.icon = faTriangleExclamation;
            data.ui = ui.t.danger;
            notifications.push(data);
        },
        info: (data) => {
            data.icon = faCircleInfo;
            data.ui = ui.t.primary;
            notifications.push(data);
        }
    }
});