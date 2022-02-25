import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';
import { useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import AboutPage from '../../features/about/AboutPage';
import Home from '../../features/home/Home';
import 'react-toastify/dist/ReactToastify.css';

import Header from './Header';
import NotFound from '../errors/NotFound';
import ContactPage from '../../features/contact/ContactPage';
import CarOwnerInoForm from '../../features/carownerinfo/CarOwnerInoForm';
import fuellingstationinfo from '../../features/fuellingstationinfo/fuellingstationinfo';

function App() {
const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? 'dark' : 'light';

  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea' : '#121212',
      },

    },
  });




  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <CssBaseline />
      <Header  />

      <Switch>
        <Route exact path="/" component={Home} />
       
        <Route path="/about" component={AboutPage} />
        <Route path="/contact" component={ContactPage} />
        
        <Route path="/carownerinfo-apply" component={CarOwnerInoForm} />
        <Route path="/fuellinstationinfo-apply" component={fuellingstationinfo} />
        <Route component={NotFound} />
      </Switch>
    </ThemeProvider>
  );
}

export default App;
