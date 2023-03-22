import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import "bootstrap/dist/css/bootstrap.min.css";
import { GoogleReCaptchaProvider } from 'react-google-recaptcha-v3';
import { RecaptchaProviderForm } from './Components/Auth/RecaptchaProviderForm';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <GoogleReCaptchaProvider
      useRecaptchaNet
      reCaptchaKey="6LfbrBMlAAAAAGrXCTz7oByR0POBfIpf3IjAgq65"
      useEnterprise
      scriptProps={{ async: true, defer: true, appendTo: 'body' }}
    >
      <App />
    </GoogleReCaptchaProvider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
