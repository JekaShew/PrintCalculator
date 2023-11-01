import React, { Component } from 'react';
import { faArrowDownWideShort, faArrowUpShortWide, faFileExcel, faFilePdf, faFilter, faPlus, faRotate, faSpinner } from '@fortawesome/free-solid-svg-icons';
import './table.css';
import Button from '../button/button';
import { ui } from '../ui/ui';
import { renderFilter } from './columnFilterRender';
import { backendColumnType, filterFromTable } from '../../service/data-models/data-models';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { utils } from '../../service/utils/utils';
import { apiFetch } from '../../service/remote/api-service';

export const loadStrategy = {
    all: {
        start: 1000,
        size: 1,
        type: 'all',
    },
    shortPages: {
        start: 4,
        size: 4,
        type: 'page',
    },
    mediumPages: {
        start: 12,
        size: 12,
        type: 'page',
    },
    longPages: {
        start: 36,
        size: 36,
        type: 'page',
    },
    custom: (start, size) => ({
        start: start,
        size: size,
        type: 'page',
    }),
};

const postProcess = (filter) => {
    switch (filter["$type"]) {
        case backendColumnType.id:
            return ({
                ...filter,
                id: filter.id && filter.id.value,
            });
        default:
            return filter;
    }
    return filter;
};

class Table extends Component {
    constructor(props) {
        super(props);

        this.renderFilters = this.renderFilters.bind(this);
        this.renderLoading = this.renderLoading.bind(this);
        this.renderMore = this.renderMore.bind(this);
        this.renderMoreBtn = this.renderMoreBtn.bind(this);
        this.renderBody = this.renderBody.bind(this);
        this.onFilterChange = this.onFilterChange.bind(this);
        this.onOrderChange = this.onOrderChange.bind(this);
        this.load = this.load.bind(this);
        this.reload = this.reload.bind(this);
        this.loadMore = this.loadMore.bind(this);
        this.onStart = this.onStart.bind(this);
        this.onReload = this.onReload.bind(this);
        this.onAppend = this.onAppend.bind(this);
        this.onFail = this.onFail.bind(this);
        this.onDone = this.onDone.bind(this);
        this.getData = this.getData.bind(this);

        this.state = {
            showFilters: false,
            loading: false,
            filter: filterFromTable(this.props.model),
            order: this.props.model.defaultOrder,
            canLoadMore: this.props.loadStrategy.type == 'page',
        };

        // TODO : renderbody dont see this.state.loading without this gus
        let rel = this.reload;
        setTimeout(() => rel(), 1);
        //this.reload();
    }

    reload() {
        this.props.onUpdate(this.props.data, []);
        this.setState({
            canLoadMore: this.props.loadStrategy.type == 'page',
        });
        this.load(0, this.props.loadStrategy.start, true);
    }

    loadMore() {
        this.load(this.props.data.length, this.props.loadStrategy.size, false);
    }

    onFilterChange(name, index, value) {
        this.setState({
            filter: {
                ...this.state.filter,
                [name]: {
                    ...this.state.filter[name],
                    [index]: value,
                },
            },
        });
    }

    onOrderChange(name, isAsc) {
        this.setState({
            order: {
                name: name,
                isAsc: isAsc,
            },
        });
    }

    load(skip, take, reset) {
        let remote = {
            url: this.props.model.url,
            type: 'post',
            data: {
                filtersRaw: JSON.stringify(Object.entries(this.state.filter).map(ee => postProcess(ee[1]))),
                skip: skip,
                take: take,
                order: this.state.order.name,
                isOrderAsc: this.state.order.isAsc,
            }
        };
        let events = {
            start: this.onStart,
            success: reset ? this.onReload : this.onAppend,
            fail: this.onFail,
            done: this.onDone,
        };
        apiFetch(remote, events);
    }

    onStart(a) {
        this.setState({
            loading: true,
        });
    }

    onReload(a) {
        if (a.data.length < this.props.loadStrategy.size)
            this.setState({
                canLoadMore: false,
            });
        if (this.props.onUpdate)
            this.props.onUpdate(a.data, a.data);
    }

    onAppend(a) {
        if (a.data.length < this.props.loadStrategy.size)
            this.setState({
                canLoadMore: false,
            });
        let result = utils.array.distinctBy([
            ...this.props.data,
            ...a.data,
        ], x => x.id);
        if (this.props.onUpdate)
            this.props.onUpdate(a.data, result);
    }

    onFail(a) {

    }

    onDone(a) {
        this.setState({
            loading: false,
        });
    }

    getData() {
        return this.props.data;
    }

    renderFilters() {
        if (this.state.showFilters) {
            return (
                <tr className="filters">
                    {
                        this.props.model.columns.map((x, i) => (
                            <th key={i} style={{ width: x.display.width, ...this.props.sh, ...x.sh }}>
                                {renderFilter(this.state.filter, this.onFilterChange, x)}
                            </th>
                        ))
                    }
                </tr>
            );
        }
    }

    renderLoading() {
        if (this.state.loading) {
            return (
                <tr className="loading">
                    <td colSpan={this.props.model.columns.length}>
                        <FontAwesomeIcon icon={faSpinner} />
                    </td>
                </tr>
            );
        } else
            return null;
    }

    renderMoreBtn(more, x) {
        if (more == true) {
            return (
                <td
                    style={{ width: '10%'}}
                >
                    <Button
                        text="Подробнее"
                        ui={ui.d.secondary}
                        onClick={() => this.props.onMoreBtnClick(x)}
                    />
                        
                    
                </td>
            )
        }
        else
            return (null)
    }
                                    
    

    renderMore() {
        if (this.state.canLoadMore) {
            if (this.state.loading)
                return (
                    <tr className="loadmore working">
                        <td colSpan={this.props.model.columns.length} style={{ width: '100%', ...this.props.sr }}>
                            <Button ui={ui.d.primary} icon={faSpinner} text="Загрузить еще" />
                        </td>
                    </tr>
                );
            else
                return (
                    <tr className="loadmore">
                        <td colSpan={this.props.model.columns.length} style={{ width: '100%', ...this.props.sr }}>
                            <Button ui={ui.d.primary} icon={faPlus} text="Загрузить еще" onClick={() => this.loadMore()} />
                        </td>
                    </tr>
                );
        } else {
            return null;
        }
    }
    renderHead(more) {
       
        return(
            <thead>
                <tr className="labels">
                    {
                        this.props.model.columns.map((x, i) => (
                            <th key={i} style={{ width: x.display.width, ...this.props.sh, ...x.sh }}>
                                <div className="label">{x.display.label}</div>
                                <div className="order">
                                    <Button
                                        ui={(this.state.order.isAsc && this.state.order.name == (x.data.orderName || x.data.name) ? ui.o.primary : ui.d.primary)}
                                        icon={faArrowUpShortWide}
                                        onClick={() => this.onOrderChange(x.data.orderName || x.data.name, true)}
                                    />
                                    <Button
                                        ui={(!this.state.order.isAsc && this.state.order.name == (x.data.orderName || x.data.name) ? ui.o.primary : ui.d.primary)}
                                        icon={faArrowDownWideShort}
                                        onClick={() => this.onOrderChange(x.data.orderName || x.data.name, false)}
                                    />
                                </div>
                            </th>
                        ))
                    }
                    {(more) ? <th></th> : null}
                </tr>
                {this.renderFilters()}
            </thead>
        )
    }
    renderBody(more) {
        if ((this.props.data && this.props.data.length > 0) || this.state.loading) {
            return (
                <tbody>
                    {
                        this.getData().map(x => (
                           
                                <tr
                                    key={x.id}
                                    
                                    className={(this.props.onRowClick ? 'hoverable' : '')}
                                >
                                    {
                                        this.props.model.columns.map((c, i) => (
                                            <td
                                                key={i}
                                                style={{ width: c.display.width, ...this.props.sr, ...c.sr }}
                                                onClick={() => this.props.onRowClick(x)}
                                            >
                                                {c.display.transform
                                                    ? c.display.transform(x[c.display.name])
                                                    : x[c.display.name] || '-'}
                                            </td>
                                        ))

                                    }
                                    { this.renderMoreBtn(more, x)}
                                </tr>
                                
                            
                        ))
                    }
                    {this.renderLoading()}
                    {this.renderMore()}
                </tbody>
            );
        } else {
            return (
                <tbody>
                    <tr className="nodata">
                        <td colSpan={this.props.model.columns.length}>
                            Нет данных
                        </td>
                    </tr>
                </tbody>
            );
        }
    }

    render() {
        let customControls = null;
        if (this.props.customControls)
            customControls = (
                <div className="custom-controls">
                    {this.props.customControls}
                </div>
            );
        return (
            <div className="table">
                <div className="header">
                    {customControls}
                    <div className="label">
                        {this.props.label}
                    </div>
                    <div className="controls">
                        <Button ui={ui.d.primary} icon={faFileExcel} />
                        <Button ui={ui.d.primary} icon={faFilePdf} />
                        <Button ui={ui.d.secondary} icon={faFilter} onClick={() => this.setState({ showFilters: !this.state.showFilters })} />
                        <Button ui={ui.d.success} icon={faRotate} onClick={() => this.reload()} />
                    </div>
                </div>
                <table className="table">
                   
                    {this.renderHead(this.props.moreBtn)}
                    {this.renderBody(this.props.moreBtn)}
                </table>
            </div>
        );
    }
}

export default Table;