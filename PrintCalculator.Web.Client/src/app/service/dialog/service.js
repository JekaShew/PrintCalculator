import store from "../../../store";
import { init } from "./actions";

export const dialog = ({
    yesNo: (data) => {
        return () => store.dispatch(init(data));
    },
    ok: (data) => {
        return () => store.dispatch(init(data));
    },
});