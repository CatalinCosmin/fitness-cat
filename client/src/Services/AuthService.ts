import axios from "axios";
import { debug } from "console";
import { ApiUrl } from "./Data";
import Moment from 'moment';

const url = ApiUrl() + "auth/";

export const login = async (loginDto: { login: string, password: string, recaptcha: string } | undefined, setToken: any, setErrorMessagesAux: any, errorMessagesAux: any) => {
    const [errorMessages, setErrorMessages] = [errorMessagesAux, setErrorMessagesAux];
    let success = false;
    if (loginDto === undefined) return false;

    setToken('');

    if (/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/.test(loginDto.login)) {
        const email = loginDto.login;
        const password = loginDto.password;
        const recaptcha = loginDto.recaptcha;

        await axios.post(url + "login", { email, password, recaptcha })
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
                    res.response.data.forEach((e: string) => {
                        console.log(e);
                        errors.push({type: "Error", message: e});
                    });
                    setErrorMessages(errors);
                }
                if (res.response.status === 401) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    errors.push({ type: 'Authentication', message: 'Email and password do not match' });
                    setErrorMessages(errors);
                }
            });
    }
    else {
        const username = loginDto.login;
        const password = loginDto.password;
        const recaptcha = loginDto.recaptcha;

        await axios.post(url + "login", { username, password, recaptcha })
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
                    res.response.data.forEach((e: string) => {
                        console.log(e);
                        errors.push({type: "Error", message: e});
                    });
                    setErrorMessages(errors);
                }
                if (res.response.status === 401) {
                    let errors: {
                        type: string,
                        message: string
                    }[] = [];
                    errors.push({ type: 'Authentication', message: 'Username and password do not match' });
                    setErrorMessages(errors);
                }
            });
    }
    return success;
}

export const register = async (registerDto: { username: string, password: string, email: string, birthDate: Date, recaptcha: string}, setErrorMessagesAux: any, errorMessagesAux: any) => {
    const [errorMessages, setErrorMessages] = [errorMessagesAux, setErrorMessagesAux];
    const username = registerDto.username;
    const email = registerDto.email;
    const password = registerDto.password;
    let bd = registerDto.birthDate;
    let birthDate = Moment(bd).format('YYYY-MM-DD');

    const recaptcha = registerDto.recaptcha;
    let success = false;
    await axios.post(url + 'register', { username, email, password, birthDate, recaptcha })
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