import axios from "axios";
import { debug } from "console";
import { ApiUrl } from "./Data";
import Moment from 'moment';

const url = ApiUrl();

export const login = async (loginDto: { login: string, password: string, tos: boolean } | undefined, setToken: any, setErrorMessagesAux: any, errorMessagesAux: any) => {
    const [errorMessages, setErrorMessages] = [errorMessagesAux, setErrorMessagesAux];
    let success = false;
    if (loginDto === undefined) return false;

    setToken('');

    if (/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/.test(loginDto.login)) {
        const email = loginDto.login;
        const password = loginDto.password;

        await axios.post(url + "login", { email, password })
            .then(res => {
                if (res.status === 200) {
                    setToken(res.data);
                    success = true;
                }
            })
            .catch(res => {
                if (res.response.status === 400) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    res.response.data.forEach((e: { type: string, message: string }) => {
                        errors.push(e);
                    });
                    setErrorMessages(errors);
                }
                if (res.response.status === 401) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    errors.push({ type: 'Authentication', message: 'Username/email and password do not match' });
                    setErrorMessages(errors);
                }
            });
    }
    else {
        const username = loginDto.login;
        const password = loginDto.password;

        await axios.post(url + "login", { username, password })
            .then(res => {
                if (res.status === 200) {
                    setToken(res.data);
                    success = true;
                }
            })
            .catch(res => {

                if (res.response.status === 400) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    res.response.data.forEach((e: { type: string, message: string }) => {
                        errors.push(e);
                    });
                    setErrorMessages(errors);
                }
                if (res.response.status === 401) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    errors.push({ type: 'Authentication', message: "Username/email and password do not match" });
                    setErrorMessages(errors);
                }
            });
    }
    return success;
}

export const register = async (registerDto: { username: string, password: string, email: string, birthDate: Date }, setErrorMessagesAux: any, errorMessagesAux: any) => {
    const [errorMessages, setErrorMessages] = [errorMessagesAux, setErrorMessagesAux];
    const username = registerDto.username;
    const email = registerDto.email;
    const password = registerDto.password;
    let bd = registerDto.birthDate;
    let birthDate = Moment(bd).format('YYYY-MM-DD');

    let success = false;
    await axios.post(url + 'register', { username, email, password, birthDate })
        .then((res) => {
            success = true;
        })
        .catch(res => {
            if (res.response.status === 201) {
                success = true;
                console.log(success);
            }
            if (res.response.status === 400) {
                let errors: {
                    type: string,
                    message: string
                }[] = [];
                res.response.data.forEach((e: { type: string, message: string }) => {
                    errors.push(e);
                });
                setErrorMessages(errors);
                console.log(errorMessages)
            }
        });
    return success;
}

export const verifyAccount = async (token: any) => {
    let success = false;
    await axios.post(url + "verify_account", {token})
        .then(res => {
            success = true;
        })
        .catch((res) => {
            console.log(res.response.data);
        })
    return success;
}