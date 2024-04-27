import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import './styles/css/bootstrap.min.css'
import './styles/css/all.min.css'
import './styles/css/style.css'
import './styles/scss/style.scss'
import 'swiper/scss';
import 'swiper/scss/navigation';
import 'swiper/scss/pagination';
import 'react-toastify/dist/ReactToastify.css';
import { WatchContextProvider } from './context/WatchContext.jsx'
import { ToastContainer } from 'react-toastify';
import { Provider } from 'react-redux';
import store from './Storage/Redux/store.js';
import { BrowserRouter } from 'react-router-dom';
import ScrollToTop from './utilities/Scroll.js';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>

      <Provider store={store}>
        <WatchContextProvider>
          <ScrollToTop />
          <App />
          <ToastContainer />
        </WatchContextProvider>
      </Provider>
    </BrowserRouter>
  </React.StrictMode>,
)
