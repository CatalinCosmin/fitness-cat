import React, { createRef, useEffect, useRef, useState } from 'react';
import { Col, FormGroup, Row, ToastContainer } from 'react-bootstrap';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate } from 'react-router-dom';
import { login } from '../../Services/AuthService';
import ErrorToast from '../ErrorToast';
import "./Auth.css";
import { RecaptchaForm } from './RecaptchaForm';
import { RecaptchaProviderForm } from './RecaptchaProviderForm';

const Login = (props: { token: any, setToken: any }) => {
    const [token, setToken] = [props.token, props.setToken];
    const navigate = useNavigate();

    const [loginValue, setLoginValue] = useState('');
    const [passwordValue, setPasswordValue] = useState('');

    const [loginDto, setLoginDto] = useState<{ password: string, login: string, recaptcha: any }>();

    const [errorMessages, setErrorMessages] = useState<{ type: string, message: string }[]>([]);
    const [onCooldown, setOnCooldown] = useState(false);

    const [recaptchaValue, setRecaptchaValue] = useState('');
    const [submitted, setSubmitted] = useState(false);

    // const [validated, setValidated] = useState(false);
    const handleSubmit = async (event: any) => {
        event.preventDefault();
        event.stopPropagation();

        if (onCooldown === true)
            return;

        setSubmitted(true);

        if (recaptchaValue === null || recaptchaValue === '') {
            let errorMessagesAux: { type: string, message: string }[] = [];
            errorMessagesAux.push({ type: "Captcha", message: "Must not be empty" });
            setErrorMessages(errorMessagesAux);
            await new Promise(f => setTimeout(f, 1000));
        }
        let result = (await login(loginDto, setToken, setErrorMessages, errorMessages));
        if (result === false) {
            setOnCooldown(true);
            await new Promise(f => setTimeout(f, 3000));
            setOnCooldown(false);
            setErrorMessages([]);
        }
        if (result === true) {
            navigate('/');
        }
    }

    useEffect(() => {
        setLoginDto({ password: passwordValue, login: loginValue, recaptcha: recaptchaValue });
    }, [loginValue, passwordValue, recaptchaValue]);
    return (
        <>
            <div className='h-100 py-5 form-bg'>

                <Form
                    // noValidate
                    // validated={validated}
                    onSubmit={handleSubmit}
                    className="w-50 px-5 mx-auto align-items-center form"
                    action="#"
                >
                    <Form.Group className="form-head">
                        <Row>
                            <Col>
                                <Form.Text className="d-inline form-head-text">
                                    Login
                                </Form.Text>
                            </Col>
                            <Col>
                                <Form.Group className="float-right">
                                    <Form.Text className="d-inline form-head-text">
                                        Need an account?
                                    </Form.Text>
                                    <Link className="nav-link d-inline form-head-text pc" to="/register">Register</Link>
                                </Form.Group>

                            </Col>
                        </Row>
                    </Form.Group>
                    <Form.Group className='form-body'>
                        <Form.Group className="mb-3" controlId="formBasicLogin">
                            <Form.Control
                                className="text-control bg-sc pc"
                                type="text"
                                placeholder="Enter username or email"
                                required
                                onChange={(event) => setLoginValue(event.currentTarget.value)}
                            />
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Control
                                className="text-control bg-sc pc"
                                type="password"
                                placeholder="Enter password"
                                required
                                onChange={(event) => setPasswordValue(event.currentTarget.value)}
                            />
                        </Form.Group>
                        <RecaptchaProviderForm action="login" setRecaptchaValueAux={setRecaptchaValue} recaptchaValueAux={recaptchaValue} onCooldownAux={onCooldown} setOnCooldownAux={setOnCooldown} />
                        <Button type="submit" className='w-100 submit-btn'>
                            Submit
                        </Button>
                        {onCooldown === true &&
                            <>
                                <Form.Label className='text-center mx-auto'>Please wait a few seconds before attempting again.</Form.Label>
                            </>
                        }
                    </Form.Group>
                </Form>
                <Row>
                    <Col sm={3}></Col>
                    <Col></Col>
                    <ToastContainer as={Col} sm={10} position="top-end" className='position-relative mt-5'>
                        <ErrorToast errorMessages={errorMessages} setErrorMessages={setErrorMessages} />
                    </ToastContainer>
                </Row>
            </div >
        </>
    );
}


export default Login;