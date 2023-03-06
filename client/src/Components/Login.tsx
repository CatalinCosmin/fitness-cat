import React, { useEffect, useState } from 'react';
import { Col, Row, ToastContainer } from 'react-bootstrap';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import { login } from '../Services/AuthService';
import ErrorToast from './ErrorToast';

const Login = (props: { token: any, setToken: any }) => {
    const [token, setToken] = [props.token, props.setToken];
    const navigate = useNavigate();

    const [loginValue, setLoginValue] = useState('');
    const [passwordValue, setPasswordValue] = useState('');
    const [tosValue, setTosValue] = useState(false);

    const [loginDto, setLoginDto] = useState<{ password: string, login: string, tos: boolean }>();


    const [errorMessages, setErrorMessages] = useState<{ type: string, message: string }[]>([]);
    const [onCooldown, setOnCooldown] = useState(false);

    // const [validated, setValidated] = useState(false);
    const handleSubmit = async (event: any) => {
        event.preventDefault();
        event.stopPropagation();

        // const form = event.currentTarget;
        // if (form.checkValidity() === false) {
        //     setValidated(false);
        //     return;
        // }
        // setValidated(true);
        if (onCooldown === true)
            return;
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
        setLoginDto({ password: passwordValue, login: loginValue, tos: tosValue });
    }, [loginValue, passwordValue, tosValue]);
    return (
        <>
            <Form
                // noValidate
                // validated={validated}
                onSubmit={handleSubmit}
                className="w-25 mx-auto mt-10"
            >
                <Form.Group className="mb-3" controlId="formBasicLogin">
                    <Form.Control
                        type="text"
                        placeholder="Enter username or email"
                        required
                        onChange={(event) => setLoginValue(event.currentTarget.value)}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Control
                        type="password"
                        placeholder="Enter password"
                        required
                        onChange={(event) => setPasswordValue(event.currentTarget.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicCheckbox">
                    <Form.Check
                        type="checkbox"
                        label="I am not a robot."
                        required
                        onChange={(event) => setTosValue(event.currentTarget.checked)}
                    />
                </Form.Group>
                <Button type="submit" className='w-100'>
                    Submit
                </Button>
                {onCooldown === true &&
                    <Form.Label className='text-center mx-auto'>Please wait a few seconds before attempting again.</Form.Label>
                }
            </Form>
            <Row>
                <Col sm={3}></Col>
                <Col></Col>
                <ToastContainer as={Col} sm={10} position="bottom-end" className='position-relative'>
                    <ErrorToast errorMessages={errorMessages} setErrorMessages={setErrorMessages} />
                </ToastContainer>
            </Row>
        </>
    );
}


export default Login;