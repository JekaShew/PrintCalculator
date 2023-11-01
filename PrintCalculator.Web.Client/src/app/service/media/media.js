import { Component } from "react";
/*import { assets } from "../../../assets/assets";*/
import config from "../../../config";

class Media extends Component {
    render() {
        if (this.props.value)
            return (
                <img src={config.apiHost + "/media/" + this.props.value + ".png"} />
            );
        else
            return (
                <img src="" />   
            );
    }
}

export default Media;