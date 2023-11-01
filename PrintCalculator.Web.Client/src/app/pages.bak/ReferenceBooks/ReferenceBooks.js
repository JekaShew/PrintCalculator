import React, { Component } from 'react';
import './ReferenceBooks.css';


import Wrapper from '../Wrapper/Wrapper';
import Carousel from 'react-bootstrap/Carousel';
import CrudForm from '../../controls/form/crud-form';
import { formStyle } from '../../controls/form/form';
import { dataModels } from '../../dataModels';

var ReactRouterDom = require('react-router-dom');

const NavLink = ReactRouterDom.NavLink;
const withRouter = ReactRouterDom.withRouter;


class ReferenceBooks extends React.Component {
    constructor(props) {
        super(props);
        this.showRefferenceBook = this.showRefferenceBook.bind(this);
    }


    showRefferenceBook(title) {
        this.props.history.push('/' + title);
        /*this.props.history.push('/${title}');*/
    };

    render() {
        return (
            <Wrapper>

                <div className="referenceBooks">
             
                    <div className="referenceBookGroup">
                        <div className="refferenceBookTitle">Бумага</div>
                        <div className="refferenceBookGroupBlock">
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("papers")}> Бумага </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("paperclasses")}>Класс Бумаги </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("paperdensities")}>Плотность Бумаги </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("paperformats")}>Формат Бумаги </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("paperpricegroups")}> Ценовая группа Бумаги </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("papertypes")}> Тип Бумаги</div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("papersizes")}> Размер Бумаги</div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("papercoefficients")}> Коэффициент Бумаги</div>
                        </div>
                    </div>

                    <div className="referenceBookGroup">
                        <div className="refferenceBookTitle">ПостОбработка</div>
                        <div className="refferenceBookGroupBlock">
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("packagingtypes")}> Упаковки </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("postprintgroups")}> Группа ПостПринт Обработки </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("postprintoperations")}>ПостПринт Обработка </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("postprintprices")}>Цена ПосПринт Обработки </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("postprintpricegroups")}>Ценовая группа ПостПринт Обработки </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("postprinttargets")}> Цель ПостПринт обработки </div>
                        </div>
                    </div>

                    <div className="referenceBookGroup">
                        <div className="refferenceBookTitle">Склад</div>
                        <div className="refferenceBookGroupBlock">
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("storages")}> Склады </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("storageproducts")}>Товары на скалде </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("categories")}>Категории товаров </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("subcategories")}>Подкатегории товаров </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("unitmeasures")}> Единицы Измерения </div>
                        </div>
                    </div>

                    <div className="referenceBookGroup">
                        <div className="refferenceBookTitle">ТехПроцесс</div>
                        <div className="refferenceBookGroupBlock">
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("techprocesses")}> ТехПроцесс </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("options")}>Опции </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("printtypes")}>Тип Печати </div>
                            <div className="refferenceBookBtn" onClick={() => this.showRefferenceBook("sectors")}>Сектор </div>
                        </div>
                    </div>
                </div>
            </Wrapper>
    )}
}

export default withRouter(ReferenceBooks);