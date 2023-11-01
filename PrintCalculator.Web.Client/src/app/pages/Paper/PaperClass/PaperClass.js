//import React, { Component } from 'react';
//import { connect } from 'react-redux';
///*import config from '../../../config';*/
//import './PaperClass.css';
///*import Carousel from 'react-bootstrap/Carousel';*/
//import Wrapper from '../../Wrapper/Wrapper';
///*import { takeAll } from './actions';*/
//var ReactRouterDom = require('react-router-dom');

//const NavLink = ReactRouterDom.NavLink;
//const withRouter = ReactRouterDom.withRouter;


//class PaperClass extends React.Component {
//    constructor(props) {
//        super(props);
//        this.onEdit = this.onEdit.bind(this);
//        this.onDelete = this.onDelete.bind(this);
//    }


//    onEdit(id) {
//        this.props.history.push('/paperclasses/' + id);
//    };

//    onDelete(id) {
//        this.props.history.push('//' + id);
//    };

//    render() {
//        console.log(this.props);
//        return (
//            <Wrapper>
//            <div className="paperClass">
//                <table className="table text-center mt-3">
//                    <thead className="thead-light ">
//                        <tr>
//                            <th>
//                                Title
//                            </th>
//                            <th>
//                                Action
//                            </th>
//                        </tr>
//                    </thead>
//                    <tbody>
//                        {
//                            this.props.value.paperClasses.map(x => (
//                                <tr>
//                                    <td>
//                                        {x.title}
//                                    </td>
//                                    <td>
//                                        <button className="btn btn-outline-primary btn-sm " onClick={() => this.onEdit(x.id)}>
//                                            Edit
//                                            </button>   |
//                                        <button className="btn btn-outline-danger btn-sm font-weight-bold text-dark" onClick={() => this.onDelete(this.props.data.id)}>
//                                            Delete
//                                        </button>
//                                    </td>
//                                </tr>
//                            ))
//                        }                               
//                    </tbody>
//                    </table>
//                </div>
//            </Wrapper>
//        )
//    };

//};

//const mapDispatchToProps = dispatch => {
//    return {
//   /*     takeAll: () => dispatch(takeAll()),*/
//    }
//}

//function mapStateToProps(state) {
//    console.log(state);
//    return {
        
//        value: state.paperClasses,
//    };
//}
//export default connect(mapStateToProps, mapDispatchToProps)(withRouter(PaperClass));

import React, { Component } from 'react';
import { connect } from 'react-redux';
import './PaperClass.css';
/*import { takeAll } from './actions';*/
import Wrapper from '../../Wrapper/Wrapper';
import CrudForm from '../../../controls/form/crud-form';
import { formStyle } from '../../../controls/form/form';
import { dataModels, dataTables } from '../../../dataModels';
import Table, { loadStrategy } from '../../../controls/table/table';
import Button from '../../../controls/button/button';
import { ui } from '../../../controls/ui/ui';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

var ReactRouterDom = require('react-router-dom');

const NavLink = ReactRouterDom.NavLink;
const withRouter = ReactRouterDom.withRouter;


class PaperClass extends React.Component {
    constructor(props) {
        super(props);
        this.setEdit = this.setEdit.bind(this);
        this.setItems = this.setItems.bind(this);
        this.renderEdit = this.renderEdit.bind(this);
        this.renderTable = this.renderTable.bind(this);
        this.state = {
            edit: { id: "", show: false },
            table: { show: true },
            items: []
        };
    }

    setEdit(id, showE, showT) {
        console.log(id);
        this.setState({ edit: { id: id, show: showE }, table: { show: showT } });
    }

    setItems(items) {
        this.setState({ items: items });
    }

    renderEdit() {
        if (this.state.edit.show) {
            this.state.table.show = false;
            return (

                <CrudForm
                    ui={formStyle.x1}
                    model={dataModels.paperClass}
                    id={this.state.edit.id}
                    events={{
                        load: () => { },
                        save: () => { },
                        delete: () => { },
                    }}
                    onCancel={() => this.setEdit(null, false, true)}
                    crud={this.state.edit.show}
                />);
        }
    }

    renderTable() {
        if (this.state.table.show) {
            return (
                <Table
                    label="Плотность бумаги"
                    sr={{ textAlign: 'left' }}
                    sh={{ textAlign: 'left' }}
                    model={dataTables.paperClasses}
                    data={this.state.items}
                    loadStrategy={loadStrategy.longPages}
                    onRowClick={(x) => this.setEdit(x.id, true, false)}
                    onUpdate={(n, a) => this.setItems(a)}
                    customControls={(<Button ui={ui.d.success} icon={faPlus} text="Добавить" onClick={() => this.setEdit('', true)} />)}
                    moreBtn={false}
                />
            );
        }
    }

    render() {
        console.log(this.state.editId);
        return (
            <Wrapper>
                <div>
                    {this.renderTable()}
                    {this.renderEdit()}
                </div>
            </Wrapper>
        )
    }
}

const mapDispatchToProps = dispatch => {
    return {
        /* takeAll: () => dispatch(takeAll()),*/
    }
}

function mapStateToProps(state) {
    console.log(state);
    return {

        value: state.paperClasses,
    };
}
export default connect(mapStateToProps, mapDispatchToProps)(withRouter(PaperClass));