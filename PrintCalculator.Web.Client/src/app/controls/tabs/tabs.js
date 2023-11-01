import React, { Component } from "react";
import '../ui/ui.css';
import './tabs.css';

export class Tab extends Component {
    render() {
        return (
            <div
                className={"tab" + (this.props.display ? ' active' : '')}
                style={this.props.display ? ({}) : ({ display: 'none' })}
            >
                {this.props.children}
            </div>
        );
    }
}

class Tabs extends Component {
    constructor(props) {
        super(props);

        this.renderSelector = this.renderSelector.bind(this);
        this.renderChildren = this.renderChildren.bind(this);

        this.state = {
            current: React.Children.toArray(this.props.children)[0].props.name,
        };
    }

    renderLabel() {
        if (this.props.label) {
            return (
                <div className="label">
                    {this.props.label}
                </div>
            );
        }
    }

    renderSelector() {
        return (
            <div className="selector">
                {
                    React.Children.map(this.props.children, child => {
                        if (React.isValidElement(child)) {
                            return (
                                <div
                                    className={"item" + (child.props.name == this.state.current ? ' active' : '')}
                                    onClick={() => this.setState({ current: child.props.name })}
                                >
                                    {child.props.label}
                                </div>
                            );
                        }
                        return child;
                    })
                }
            </div>  
        );
    }

    renderChildren() {
        let self = this;
        return (
            <div className="content">
                {
                    React.Children.map(this.props.children, child => {
                        if (React.isValidElement(child)) {
                            return React.cloneElement(child, { display: self.state.current == child.props.name });
                        }
                        return child;
                    })
                }
            </div>    
        );
    }

    render() {
        return (
            <div className="tabs">
                {this.renderSelector()}
                {this.renderChildren()}
            </div>
        );
    }
}

export default Tabs;