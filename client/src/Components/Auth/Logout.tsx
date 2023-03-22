import { useNavigate } from "react-router-dom";

const Logout = (tokenAux: any, setTokenAux: any) => {
    const [token, setToken] = [tokenAux, setTokenAux];
    const navigate = useNavigate();

    setToken('');
}

export default Logout;