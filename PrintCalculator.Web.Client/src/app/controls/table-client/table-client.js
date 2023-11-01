import React, { Component } from 'react';
import { faFileExcel, faFilePdf } from '@fortawesome/free-solid-svg-icons';
import './table-client.css';
import Button from '../button/button';
import { ui } from '../ui/ui';

class TableClient extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="table-client">
                <div className="header">
                    <div className="label">
                        {this.props.label}
                    </div>
                    <div className="controls">
                        <Button ui={ui.d.primary} icon={faFileExcel} />
                        <Button ui={ui.d.primary} icon={faFilePdf} />
                    </div>
                </div>
                <table className="table-client">
                    <thead>
                        <tr>
                            {
                                this.props.columns.map((x, i) => (
                                    <th key={i} style={{ width: x.width, ...this.props.sh, ...x.sh }}>
                                        {x.label}
                                    </th>
                                ))
                            }
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.props.rows && this.props.rows.map(x => (
                                <tr key={x.id}>
                                    {
                                        this.props.columns.map((c, i) => (
                                            <td key={i} style={{ width: c.width, ...this.props.sr, ...c.sr }}>
                                                {x[c.name] || '-'}
                                            </td>
                                        ))
                                    }
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

export default TableClient;