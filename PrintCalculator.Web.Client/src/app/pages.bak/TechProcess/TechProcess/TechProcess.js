import React, { Component } from 'react';
import { connect } from 'react-redux';
import './TechProcess.css';
/*import { takeAll } from './actions';*/
import Wrapper from '../../Wrapper/Wrapper';
import CrudForm from '../../../controls/form/crud-form';
import DetailsForm from '../../../controls/form/details-form';
import { formStyle } from '../../../controls/form/form';
import { dataModels, dataTables } from '../../../dataModels';
import Table, { loadStrategy } from '../../../controls/table/table';
import Button from '../../../controls/button/button';
import { ui } from '../../../controls/ui/ui';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { postPrintGroups } from '../../../../reducers';

var ReactRouterDom = require('react-router-dom');

const NavLink = ReactRouterDom.NavLink;
const withRouter = ReactRouterDom.withRouter;


class TechProcess extends React.Component {
    constructor(props) {
        super(props);
        this.setEdit = this.setEdit.bind(this);
        this.setItems = this.setItems.bind(this);
        this.renderEdit = this.renderEdit.bind(this);
       /* this.renderDetails = this.renderDetails.bind(this);*/
        this.renderTable = this.renderTable.bind(this);
        this.state = {
            edit: { id: "", show: false },
            details: { id: "", show: false },
            table: { show: true },
            items: []
        };
    }

    setEdit(id, showE, showD, showT) {
        console.log(id);
        this.setState({ edit: { id: id, show: showE }, details: {id: id, show: showD}, table: { show: showT } });
    }

    setItems(items) {
        this.setState({ items: items });
    }

    //renderDetails() {
    //    if (this.state.details.show) {
    //        this.state.table.show = false;
    //        this.state.edit.show = false;
    //        return (
    //            <DetailsForm
    //                ui={formStyle.x1}
    //                model={dataModels.techProcess}
    //                id={this.state.details.id}
    //                events={{
    //                    load: () => { },
    //                    save: () => { },
    //                    delete: () => { },
    //                }}
    //                onCancel={() => this.setEdit(null, false, false,  true)}
    //            />);
    //    }
    //}

    renderEdit() {
        console.log("renderEdit");
        console.log(this.state);
        if (this.state.edit.show || this.state.details.show) {
            this.state.table.show = false;
            this.state.details.show = false;
            return (
                <CrudForm
                    ui={formStyle.x1}
                    model={dataModels.techProcess}
                    id={this.state.edit.id}
                    events={{
                        load: () => { },
                        save: () => { },
                        delete: () => { },
                    }}
                    onCancel={() => this.setEdit(null, false, false, true)}
                    onEditBtnClick={(id) => this.setEdit(id, true, false, false)}
                    crud={this.state.edit.show}
                />);
        }
        else
        {

        }
    }

    renderTable() {
        if (this.state.table.show) {
            return (
                <Table
                    label="ТехПроцессы"
                    sr={{ textAlign: 'left' }}
                    sh={{ textAlign: 'left' }}
                    model={dataTables.techProcesses}
                    data={this.state.items}
                    loadStrategy={loadStrategy.longPages}
                    onRowClick={(x) => this.setEdit(x.id, true, false, false)}
                    onUpdate={(n, a) => this.setItems(a)}
                    customControls={(<Button ui={ui.d.success} icon={faPlus} text="Добавить" onClick={() => this.setEdit('', true)} />)}
                    moreBtn={true}
                    onMoreBtnClick={(x) => this.setEdit(x.id, false, true, false)}
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
                   {/* {this.renderDetails()}*/}
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

        value: state.techProcesses,
    };
}
export default connect(mapStateToProps, mapDispatchToProps)(withRouter(TechProcess));