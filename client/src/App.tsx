import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import useLocalStorage from './Components/LocalStorageHook';
import Test from './Components/Test';
import Login from './Components/Auth/Login';
import NavBar from './Components/Navbar/NavBar';
import NavRouter from './Components/NavRouter/NavRouter';
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';

const App = () => {
  const [token, setToken] = useLocalStorage('token', '');
  if (token) {
    const headerToken = 'Bearer ' + token;
    axios.defaults.headers.common['Authorization'] = headerToken;
  }
  else {
    axios.defaults.headers.common['Authorization'] = null;
  }

  return (
    <div>
      <div>
        <BrowserRouter>
          <NavBar token={token} setToken={setToken} />
          <NavRouter token={token} setToken={setToken} />
        </BrowserRouter>
      </div>
    </div>
  );
}


export default App;
