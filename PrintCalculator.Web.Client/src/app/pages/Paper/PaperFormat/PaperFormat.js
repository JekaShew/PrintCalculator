import React, { Component } from 'react';
import { connect } from 'react-redux';
import './PaperFormat.css';
/*import { takeAll } from './actions';*/
import Wrapper from '../../Wrapper/Wrapper';
import CrudForm from '../../../controls/form/crud-form';
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


class PaperFormat extends React.Component {
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
                    model={dataModels.paperFormat}
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
                    model={dataTables.paperFormats}
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

        value: state.paperFormats,
    };
}
export default connect(mapStateToProps, mapDispatchToProps)(withRouter(PaperFormat));