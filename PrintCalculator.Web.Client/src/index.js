import React from 'react';
import App from './app/app';
import ReactDOM from 'react-dom';
import './index.css';
import store from './store';

ReactDOM.render(
    <App store={store} />,
    document.getElementById('root')
);
