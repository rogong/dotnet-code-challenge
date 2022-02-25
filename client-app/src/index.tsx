import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import { Router } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';




export const history = createBrowserHistory();


ReactDOM.render(
  <React.StrictMode>
    <Router history={history}>
    
    
        <App />

    
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);


reportWebVitals();
