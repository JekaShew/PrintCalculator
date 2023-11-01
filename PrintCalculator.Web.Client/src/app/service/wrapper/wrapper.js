import React, { Component } from 'react';
import { connect } from 'react-redux';
import { NavLink } from 'react-router-dom';
import './wrapper.css';
import '../../controls/ui/ui.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBriefcase, faFileContract, faUserGear, faRightFromBracket, faUsers, faTableList, faMapLocation, faLandmark, faFileLines, faFileInvoice, faGasPump } from '@fortawesome/free-solid-svg-icons';
import { roles } from '../data-models/data-models';

let topNavs = (authorization) => {
    const checkRole = (role) => authorization.userInfo && authorization.userInfo.roles.includes(role);

    let result = [];
    if (checkRole(roles.fields.get) || checkRole(roles.units.get))
        result.push({
            label: 'Карта',
            link: '/',
            icon: faMapLocation,
        });
    if (checkRole(roles.waybills.get))
        result.push({
            label: 'Путевые листы',
            link: '/Waybills',
            icon: faFileInvoice,
        });
    if (checkRole(roles.refuels.get))
        result.push({
            label: 'Заправки',
            link: '/Refuels',
            icon: faGasPump,
        });
    if (checkRole(roles.jobs.get))
        result.push({
            label: 'Работы',
            link: '/Jobs',
            icon: faBriefcase,
        });
    if (checkRole(roles.employees.get))
        result.push({
            label: 'Сотрудники',
            link: '/Employees',
            icon: faUsers,
        });
    if (checkRole(roles.references.get))
        result.push({
            label: 'Справочники',
            link: '/References',
            icon: faTableList,
        });
    if (checkRole(roles.users.get))
        result.push({
            label: 'Управление',
            link: '/Manage',
            icon: faLandmark,
        });
    result.push({
        label: 'Отчеты',
        link: '/Reports',
        icon: faFileContract,
    });
    result.push({
        label: 'Документы',
        link: '/Documents',
        icon: faFileLines,
    });

    return result;
};

let bottomNavs = (authorization) => [
    {
        label: authorization.userInfo.login,
        link: '/Account',
        icon: faUserGear,
    },
    {
        label: 'Выйти',
        link: '/Logout',
        icon: faRightFromBracket,
    },
]

class Wrapper extends Component {
    render() {
        return (
            <div className="wrapper">
                <div className="wrapper-sidebar">
                    <div className="header">
                        Crop
                    </div>
                    <div className="navs">
                        <div className="top-navs">
                            {
                                topNavs(this.props.authorization).map((x, i) => (
                                    <div className="nav" key={i}>
                                        <NavLink to={x.link}>
                                            <div className="icon"><FontAwesomeIcon icon={x.icon} /></div>
                                            <div className="label">{x.label}</div>
                                        </NavLink>
                                    </div>
                                ))
                            }
                        </div>
                        <div className="bottom-navs">
                            {
                                bottomNavs(this.props.authorization).map((x, i) => (
                                    <div className="nav" key={i}>
                                        <NavLink to={x.link}>
                                            <div className="icon"><FontAwesomeIcon icon={x.icon} /></div>
                                            <div className="label">{x.label}</div>
                                        </NavLink>
                                    </div>
                                ))
                            }
                        </div>
                    </div>
                </div>
                <div className="wrapper-content">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = dispatch => {
    return {

    }
}

function mapStateToProps(state) {
    return {
        authorization: state.authorization,
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(Wrapper)