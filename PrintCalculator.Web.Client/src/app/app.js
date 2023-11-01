import React, { Component } from 'react';
import { BrowserRouter as RoutingRouter, Route as RoutingRoute } from 'react-router-dom'
import { Provider } from 'react-redux';

import ReferenceBooks from '../app/pages/ReferenceBooks/ReferenceBooks';
/*import Main from './main/main';*/
import PaperClass from '../app/pages/Paper/PaperClass/PaperClass';
import PaperSize from './pages/Paper/PaperSize/PaperSize';
import Paper from '../app/pages/Paper/Paper/Paper';
import PaperCoefficient from '../app/pages/Paper/PaperCoefficient/PaperCoefficient';
import PaperDensity from '../app/pages/Paper/PaperDensity/PaperDensity';
import PaperFormat from '../app/pages/Paper/PaperFormat/PaperFormat';
import PaperPriceGroup from '../app/pages/Paper/PaperPriceGroup/PaperPriceGroup';
import PaperType from '../app/pages/Paper/PaperType/PaperType';

import PackagingType from '../app/pages/PostPrint/PackagingType/PackagingType';
import PostPrintGroup from '../app/pages/PostPrint/PostPrintGroup/PostPrintGroup';
import PostPrintOperation from '../app/pages/PostPrint/PostPrintOperation/PostPrintOperation';
import PostPrintPrice from '../app/pages/PostPrint/PostPrintPrice/PostPrintPrice';
import PostPrintPriceGroup from '../app/pages/PostPrint/PostPrintPriceGroup/PostPrintPriceGroup';
import PostPrintTarget from '../app/pages/PostPrint/PostPrintTarget/PostPrintTarget';

import Storage from '../app/pages/Storage/Storage/Storage';
import Category from '../app/pages/Storage/Category/Category';
import SubCategory from '../app/pages/Storage/SubCategory/SubCategory';
import UnitMeasure from '../app/pages/Storage/UnitMeasure/UnitMeasure';
import StorageProduct from '../app/pages/Storage/StorageProduct/StorageProduct';

import TechProcess from '../app/pages/TechProcess/TechProcess/TechProcess';
import TechProcessOption from '../app/pages/TechProcess/TechProcessOption/TechProcessOption';
import Option from '../app/pages/TechProcess/Option/Option';
import Sector from '../app/pages/TechProcess/Sector/Sector';
import PrintType from '../app/pages/TechProcess/PrintType/PrintType';


import Dialog from './service/dialog/dialog';
import Notifications from './service/notifications/notifications';
/*import LoadIndicator from './loadIndicator/loadIndicator';*/
/*import Login from './loginRegistration/login/login';*/

export default class extends Component {
    render() {
        return this.prod();
    }

    prod() {
        return (
            <Provider store={this.props.store}>
                <Dialog />
                <Notifications />
                <RoutingRouter>
                    <RoutingRoute path="/" component={ReferenceBooks} exact />
                    {/*<RoutingRoute path="/Main" component={Main} exact />*/}
                 {/*<RoutingRoute path="/CarDetails/:id" component={CarDetails} exact />*/}

                    <RoutingRoute path="/referencebooks" component={ReferenceBooks} exact />

                    <RoutingRoute path="/paperclasses" component={PaperClass} exact />
                    <RoutingRoute path="/papersizes" component={PaperSize} exact />
                    <RoutingRoute path="/paperformats" component={PaperFormat} exact />
                    <RoutingRoute path="/paperdensities" component={PaperDensity} exact />
                    <RoutingRoute path="/papertypes" component={PaperType} exact />
                    <RoutingRoute path="/papercoefficients" component={PaperCoefficient} exact />
                    <RoutingRoute path="/paperpricegroups" component={PaperPriceGroup} exact />
                    <RoutingRoute path="/papers" component={Paper} exact />

                    <RoutingRoute path="/packagingtypes" component={PackagingType} exact />
                    <RoutingRoute path="/postprintgroups" component={PostPrintGroup} exact />
                    <RoutingRoute path="/postprintoperations" component={PostPrintOperation} exact />
                    <RoutingRoute path="/postprintprices" component={PostPrintPrice} exact />
                    <RoutingRoute path="/postprintpricegroups" component={PostPrintPriceGroup} exact />
                    <RoutingRoute path="/postprinttargets" component={PostPrintTarget} exact />

                    <RoutingRoute path="/categories" component={Category} exact />
                    <RoutingRoute path="/subcategories" component={SubCategory} exact />
                    <RoutingRoute path="/storages" component={Storage} exact />
                    <RoutingRoute path="/storageproducts" component={StorageProduct} exact />
                    <RoutingRoute path="/unitmeasures" component={UnitMeasure} exact />

                    <RoutingRoute path="/options" component={Option} exact />
                    <RoutingRoute path="/techporcessoptions" component={TechProcessOption} exact />
                    <RoutingRoute path="/sectors" component={Sector} exact />
                    <RoutingRoute path="/printtypes" component={PrintType} exact />
                    <RoutingRoute path="/techprocesses" component={TechProcess} exact />

                    {/*<RoutingRoute path="/CarDetailsChange/:id" component={CarDetailsChange} exact />*/}

                    {/*<RoutingRoute path="/Login" component={Login} exact />*/}
                </RoutingRouter>
            </Provider>
        );
    }
}