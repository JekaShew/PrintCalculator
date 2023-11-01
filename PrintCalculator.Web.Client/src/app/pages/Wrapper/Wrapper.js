import React, { Component } from 'react';

import { withRouter } from 'react-router';
/*import icons from '../../assets/icons';*/
import './Wrapper.css';
var ReactRouterDom = require('react-router-dom');
const NavLink = ReactRouterDom.NavLink;

class Wrapper extends Component {
    render() {
        return (
            <div className="wrapper">
                <div className="header">
                    <div className="title"><NavLink className="navLink" to="/referencebooks">PrintCalculator</NavLink></div>
                    <div className="navItem"><NavLink className="navLink" to="/referencebooks">Справочники</NavLink></div>
                    <div className="navItem"><NavLink className="navLink" to="/orders"> Заказы</NavLink></div>
                    <div className="navItem"><NavLink className="navLink" to="/calculations">Калькуляции</NavLink></div>
                    <div className="navItem"><NavLink className="navLink" to="/calculator">Калькулятор</NavLink></div>

                </div>
                <div className="wrapper-content">
                    {this.props.children}
                </div>
                
            </div>
        );
    }
}

export default withRouter(Wrapper);