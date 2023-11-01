import React, { Component } from 'react';
import { dialog } from '../../service/dialog/service';
import { notifications } from '../../service/notifications/service';
import { apiFetch } from '../../service/remote/api-service';
import { utils } from '../../service/utils/utils';
import Widget from '../../service/widget/widget';
import Form, { propDefault } from './form';

export const buildModelFromProps = (props) => Object.fromEntries([
    ...props.map(prop => [prop.name, propDefault[prop.type](prop)]),
]);

export const buildModelFromPropsExtended = (rows) => {
    let props = rows.map(row =>
        row.columns.map(col => col.props)
    ).reduce((r, c) => [...r, ...c]).reduce((r, c) => [...r, ...c]);
    return buildModelFromProps(props);
};

class CrudForm extends Component {
    constructor(props) {
        super(props);

        this.onChange = this.onChange.bind(this);
        this.init = this.init.bind(this);
        this.save = this.save.bind(this);
        this.cancel = this.cancel.bind(this);
        this.delete = this.delete.bind(this);
        this.getControls = this.getControls.bind(this);

        this.state = {
            id: this.props.id,
            data: {},
            errors: {},
        };
        this.init();
    }

    componentWillReceiveProps(nextProps) {
        this.setState({
            data: {
                ...this.state.data,
                ...nextProps.subData,
            },
        });
    }

    init() {
        let self = this;
        if (this.state.id) {
            let remote = {
                url: this.props.model.url + '/' + this.state.id,
                type: 'get',
            };
            let events = {
                success: (data) => {
                    let result = {
                        ...data,
                        ...self.props.events.subData,
                    };
                    self.setState({ data: result });
                    if (self.props.events && self.props.events.load)
                        self.props.events.load(result);
                }
            };
            apiFetch(remote, events);
        } else {
            let data = self.props.model.rows ? buildModelFromPropsExtended(self.props.model.rows) : buildModelFromProps(self.props.model.props);
            let result = {
                ...data,
                ...self.props.subData,
            };
            let us = () => self.setState({
                data: result,
            });
            setTimeout(() => us(), 1);
            if (self.props.events && self.props.events.load)
                self.props.events.load(result);
        }
    }

    onChange(name, value) {
        this.setState({
            data: {
                ...this.state.data,
                [name]: value,
            },
            errors: {
                ...this.state.errors,
                [name]: undefined,
            }
        });
    }

    save(data) {
        let self = this;
        let request = {
            ...data,
            ...this.props.subData,
        };
        let remote = this.state.id ? ({
            url: this.props.model.url,
            type: 'put',
            data: utils.form.fromJson(request),
            contentType: 'application/x-www-form-urlencoded',
        }) : ({
            url: this.props.model.url,
            type: 'post',
            data: utils.form.fromJson(request),
            contentType: 'application/x-www-form-urlencoded',
        });
        let events = {
            success: (response) => {
                notifications.preset.success({
                    title: 'Изменения сохранены',
                });
                if (!self.state.id) {
                    self.setState({
                        id: response.id,
                        data: response,
                    });
                } else {
                    self.setState({
                        data: response,
                    });
                }
                if (self.props.events.save)
                    self.props.events.save(response);
            },
            fail: (response) => {
                if (response && response.type == "ValidationError") {
                    notifications.preset.danger({
                        title: 'Проверьте введенные данные',
                    });
                    self.setState({
                        errors: response.errors,
                    });
                }
            },
            done: () => self.setState({}),
        };
        apiFetch(remote, events);
    }

    cancel() {
        this.props.onCancel();
    }

    delete() {
        let self = this;
        dialog.ok({
            label: 'Удаление данных',
            content: 'Вы уверены что хотите удалить ' + self.props.model.label + '?',
            yes: () => {
                let remote = {
                    url: self.props.model.url + '/' + self.state.id,
                    type: 'delete',
                };
                let events = {
                    success: () => {
                        notifications.preset.success({
                            title: 'Удалено',
                        });
                        if (self.props.events && self.props.events.delete)
                            self.props.events.delete(self.state.id);
                        self.cancel();
                    },
                };
                apiFetch(remote, events);
            },
            no: () => { },
        })();
    }

    getControls() {
        if (!this.props.roles) {
            if (this.state.id) {
                return ({
                    save: this.save,
                    cancel: this.cancel,
                    delete: this.delete,
                });
            } else {
                return ({
                    save: this.save,
                    cancel: this.cancel,
                });
            }
        } else {
            let self = this;
            const checkRole = (role) => self.props.roles.current.includes(role);
            const checkOwn = (role) => {
                if (!checkRole(role))
                    return false;
                if (!self.state.data)
                    return false;
                var dataDate = new Date(self.state.data.updatedOn);
                var maxDate = new Date();
                maxDate.setHours(maxDate.getHours() - 24);
                return self.state.data.updatedBy == self.props.roles.userId && dataDate > maxDate;
            };

            let result = {
                cancel: this.cancel,
            };
            if ((this.state.id && (checkRole(this.props.roles.allowed.update) || checkOwn(this.props.roles.allowed.add)))
                || (!this.state.id && checkRole(this.props.roles.allowed.add))
            )
                result = {
                    ...result,
                    save: this.save,
                };
            if (this.state.id && (checkRole(this.props.roles.allowed.delete) || checkOwn(this.props.roles.allowed.add)))
                result = {
                    ...result,
                    delete: this.delete,
                };
            return result;
        }
    }

    onEditBtnClick(id) {
        this.props.onEditBtnClick(id);
    }

    renderForm() { }
    renderDetailsForm() {}

    render() {
        return (
            <Widget
                label={this.props.model.editLabel}
                onClose={this.cancel}
            >
                <Form
                    data={this.state.data}
                    errors={this.state.errors}
                    ui={this.props.ui}
                    model={this.props.model}
                    onChange={(n, v) => this.onChange(n, v)}
                    controls={this.getControls()}
                    crud={this.props.crud}
                    onEditBtnClick={ (id) => this.onEditBtnClick(id)}
                >
                    {this.props.children}
                </Form>
            </Widget>
        );
    }
}

export default CrudForm