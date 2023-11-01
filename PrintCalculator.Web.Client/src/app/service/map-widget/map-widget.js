import { Component } from "react";
import {
    GoogleMap,
    Polygon,
    withScriptjs,
    withGoogleMap,
    TrafficLayer,
    Polyline,
    Marker,
} from "react-google-maps";
import MarkerWithLabel from 'react-google-maps/lib/components/addons/MarkerWithLabel';
import { assets } from "../../../assets/assets";
import { utils } from '../utils/utils';

const colors = {
    edit: {
        b: '#147a40',
        f: '#25c245',
    },
    default: {
        b: '#3eb1c6',
        f: '#54d1e8',
    },
    active: {
        b: '#3c82b4',
        f: '#4495cf',
    },
}

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.onMouseMove = this.onMouseMove.bind(this);
        this.onClick = this.onClick.bind(this);
        this.onRightClick = this.onRightClick.bind(this);
        this.onPointDrag = this.onPointDrag.bind(this);
        this.insertPoint = this.insertPoint.bind(this);
        this.removePoint = this.removePoint.bind(this);

        this.renderFields = this.renderFields.bind(this);
        this.renderEditField = this.renderEditField.bind(this);

        this.state = {
            newPoint: null,
        };
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.edit.show && !this.props.edit.show) {
            if (nextProps.edit.id) {
                this.setState({
                    newPoint: null,
                });
            } else {
                this.setState({
                    newPoint: {
                        lat: 0,
                        lng: 0,
                    },
                });
            }
        }
    }

    onMouseMove(eventargs) {
        if (this.props.edit && this.state.newPoint) {
            this.setState({
                newPoint: {
                    lat: eventargs.latLng.lat(),
                    lng: eventargs.latLng.lng(),
                },
            });
        }
    }

    onClick(eventargs) {
        if (this.props.edit && this.state.newPoint) {
            this.props.setCoords([
                ...this.props.edit.coords,
                {
                    lat: eventargs.latLng.lat(),
                    lng: eventargs.latLng.lng(),
                },
            ]);
        }
    }

    onRightClick(eventargs) {
        if (this.props.edit && this.state.newPoint && this.props.edit.coords.length > 2) {
            this.setState({
                newPoint: null,
            });
        }
    }

    onPointDrag(i, eventargs) {
        if (this.props.edit && !this.state.newPoint) {
            this.props.setCoords([
                ...this.props.edit.coords.slice(0, i),
                {
                    lat: eventargs.latLng.lat(),
                    lng: eventargs.latLng.lng(),
                },
                ...this.props.edit.coords.slice(i + 1),
            ]);
        }
    }

    insertPoint(i, eventargs) {
        if (this.props.edit && !this.state.newPoint) {
            this.props.setCoords([
                ...this.props.edit.coords.slice(0, i + 1),
                {
                    lat: eventargs.latLng.lat(),
                    lng: eventargs.latLng.lng(),
                },
                ...this.props.edit.coords.slice(i + 1),
            ]);
        }
    }

    removePoint(i, eventargs) {
        if (this.props.edit && !this.state.newPoint) {
            if (this.props.edit.coords.length <= 3) {
                this.props.setCoords([]);
                this.setState({
                    newPoint: {
                        lat: 0,
                        lng: 0,
                    },
                });
            } else {
                this.props.setCoords([
                    ...this.props.edit.coords.slice(0, i),
                    ...this.props.edit.coords.slice(i + 1),
                ]);
            }
        }
    }

    renderEditField() {
        if (this.props.edit.show) {
            if (this.state.newPoint) {
                return [(
                    <Polyline path={this.props.edit.coords.concat([this.state.newPoint])}
                        key={1}
                        onClick={this.onClick}
                        onRightClick={this.onRightClick}
                        onMouseMove={this.onMouseMove}
                        options={{
                            fillColor: colors.edit.f,
                            fillOpacity: 0.4,
                            strokeColor: colors.edit.b,
                            strokeOpacity: 1,
                            strokeWeight: 3
                        }}
                    />
                )];
            } else {
                return [
                    (
                        <Polygon path={this.state.newPoint ? this.props.edit.coords.concat(this.state.newPoint) : this.props.edit.coords}
                            onClick={this.onClick}
                            onRightClick={this.onRightClick}
                            options={{
                                fillColor: colors.edit.f,
                                fillOpacity: 0.4,
                                strokeColor: colors.edit.b,
                                strokeOpacity: 1,
                                strokeWeight: 3
                            }}
                        />
                    ),
                    ...this.props.edit.coords.map((cc, i) => (
                        <Marker
                            draggable={true}
                            options={{
                                fillColor: colors.edit.f,
                                fillOpacity: 0.4,
                                strokeColor: colors.edit.b,
                                strokeOpacity: 1,
                                strokeWeight: 3,
                            }}
                            icon={assets.icons.round}
                            position={cc}
                            labelAnchor={{ x: 0, y: 0 }}
                            onDrag={e => this.onPointDrag(i, e)}
                            onRightClick={e => this.removePoint(i, e)}
                        />
                    )),
                    ...this.props.edit.coords.slice(1).map((cc, i) => (
                        <Marker
                            key={i}
                            options={{
                                fillColor: colors.edit.f,
                                fillOpacity: 0.4,
                                strokeColor: colors.edit.b,
                                strokeOpacity: 1,
                                strokeWeight: 3,
                            }}
                            icon={assets.icons.circle}
                            position={utils.map.getBetweenPoint(this.props.edit.coords[i], cc)}
                            labelAnchor={{ x: 0, y: 0 }}
                            onClick={e => this.insertPoint(i, e)}
                        />
                    )),
                    (
                        <Marker
                            options={{
                                fillColor: colors.edit.f,
                                fillOpacity: 0.4,
                                strokeColor: colors.edit.b,
                                strokeOpacity: 1,
                                strokeWeight: 3,
                            }}
                            icon={assets.icons.circle}
                            position={utils.map.getBetweenPoint(this.props.edit.coords[0], this.props.edit.coords[this.props.edit.coords.length - 1])}
                            labelAnchor={{ x: 0, y: 0 }}
                            onClick={e => this.insertPoint(this.props.edit.coords.length - 1, e)}
                        />
                    )
                ];
            }
        }
    }

    renderFields() {
        let fields = this.props.fields.filter(x => !this.props.edit || this.props.edit.id != x.id);
        let activeField = this.props.activeField;
        let onFieldClick = this.props.onFieldClick;

        return fields.map(x => [(
            <Polygon
                key={x.id + 'p'}
                path={x.coords}
                options={{
                    fillColor: (x.id == activeField ? colors.active.f : colors.default.f),
                    fillOpacity: 0.4,
                    strokeColor: (x.id == activeField ? colors.active.b : colors.default.b),
                    strokeOpacity: 1,
                    strokeWeight: 1
                }}
                onClick={e => onFieldClick(x, e)}
            />
        ), (
            <MarkerWithLabel
                key={x.id + 'mwl'}
                icon={assets.icons.circle}
                position={utils.map.getPolygonCenter(x.coords)}
                labelAnchor={new window.google.maps.Point(0, 0)}
                labelStyle={{
                    backgroundColor: "white",
                    fontSize: "calc(1rem * var(--font-multiplier)",
                    padding: "8px",
                    transform: "translate(-50%, -50%)",
                }}
                onClick={e => onFieldClick(x, e)}
            >
                <div>{utils.map.getPolygonArea(x.coords)}</div>
            </MarkerWithLabel>
        )]);
    } 

    render() {
        return (
            <GoogleMap
                onMouseMove={this.onMouseMove}
                onClick={this.onClick}
                onRightClick={this.onRightClick}
                options={{
                    streetViewControl: false,
                    draggable: true, // make map draggable
                    zoomControlOptions: { position: 9 },
                    keyboardShortcuts: false, // disable keyboard shortcuts
                    scaleControl: true, // allow scale controle
                    scrollwheel: true, // allow scroll wheel
                    mapTypeId: 'hybrid',//google.maps.MapTypeId.TERRAIN,
                }}
                center={this.props.center}
                defaultZoom={13}
            >
                {this.renderEditField()}
                {
                    this.renderFields(
                        this.props.fields.filter(x => !this.props.edit || this.props.edit.id != x.id),
                        this.props.activeField,
                        this.props.onFieldClick
                    )
                }
            </GoogleMap>
        );
    }
};

export default withGoogleMap(MapWidget);