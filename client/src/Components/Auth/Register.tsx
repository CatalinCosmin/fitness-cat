import { useEffect, useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useAsyncError, useNavigate } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import { register } from "../../Services/AuthService";
import ErrorToast from "../ErrorToast";
import ToastifyMessage from "../ToastifyMessage";
import "./Auth.css";
import { RecaptchaProviderForm } from "./RecaptchaProviderForm";

const Register = (props: { token: any, setToken: any }) => {
    const [token, setToken] = [props.token, props.setToken];
    const [validated, setValidated] = useState(false);
    const [errorMessages, setErrorMessages] = useState<{ type: string, message: string }[]>([])
    const navigate = useNavigate();

    const [emailValue, setEmailValue] = useState('');
    const [usernameValue, setUsernameValue] = useState('');
    const [passwordValue, setPasswordValue] = useState('');
    const [confirmPasswordValue, setConfirmPasswordValue] = useState('');
    const [birthDateValue, setBirthDateValue] = useState<Date>(new Date());
    const [registerDto, setRegisterDto] = useState<{ username: string, email: string, password: string, birthDate: Date, recaptcha: string }>();

    const [onCooldown, setOnCooldown] = useState(false);

    const [recaptchaValue, setRecaptchaValue] = useState('');
    const [submitted, setSubmitted] = useState(false);

    useEffect(() => {
        setRegisterDto({ username: usernameValue, password: passwordValue, email: emailValue, birthDate: birthDateValue, recaptcha: recaptchaValue });
    }, [emailValue, usernameValue, passwordValue, birthDateValue, recaptchaValue]);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
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

        if (passwordValue !== confirmPasswordValue) {
            toast("Confirm password and password do not match.", {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark"
            })
        }

        if (registerDto === undefined)
            return;

        console.log(recaptchaValue);
        const result = (await register(registerDto, setErrorMessages, errorMessages));
        if (result === false) {
            // errorMessages.forEach((el: { type: string, message: string }) => {
            //     toast(el.message, {
            //         position: "top-right",
            //         autoClose: 5000,
            //         hideProgressBar: false,
            //         closeOnClick: true,
            //         pauseOnHover: true,
            //         draggable: true,
            //         progress: undefined,
            //         theme: "dark"
            //     })
            // });
            setOnCooldown(true);
            await new Promise(f => setTimeout(f, 3000));
            setOnCooldown(false);
            setErrorMessages([]);
        }
        if (result === true)
            navigate('/login');
    }
    return (
        <>
            <div className='h-100 py-4 form-bg'>
                <Form
                    // noValidate
                    // validated={validated}
                    onSubmit={handleSubmit}
                    className="w-50 px-5 mx-autoalign-items-center form"
                >
                    <Form.Group className="form-head">
                        <Row>
                            <Col md={3}>
                                <Form.Text className='ml-3 pr py-auto'>
                                    Sign-Up
                                </Form.Text>
                            </Col>
                            <Col md="8">
                                <Form.Group className="float-end py-auto">
                                    <Form.Text className="d-inline pr-muted mr-1 py-auto font-sm">
                                        Already have an account?
                                    </Form.Text>
                                    <Link className="nav-link d-inline pc" to="/login"><Button className='d-inline bc bg-sc submit-btn font-sm'>Sign-In</Button></Link>
                                </Form.Group>
                            </Col>
                        </Row>
                    </Form.Group>
                    <Form.Group className="form-body">
                        <Row>
                            <Form.Group as={Col} sm={4} className="mb-3" controlId="formBasicUsername">
                                {/* <Form.Label>Username</Form.Label> */}
                                <Form.Control
                                    className="text-control bg-sc pc"
                                    type="text"
                                    placeholder="Username"
                                    required
                                    onChange={(e) => setUsernameValue(e.currentTarget.value)}
                                />
                            </Form.Group>

                            <Form.Group as={Col} sm={8} className="mb-3" controlId="formBasicEmail">
                                {/* <Form.Label>Email address</Form.Label> */}
                                <Form.Control
                                    className="text-control bg-sc pc"
                                    type="email"
                                    placeholder="Email"
                                    required
                                    onChange={(e) => setEmailValue(e.currentTarget.value)}
                                />
                            </Form.Group>
                        </Row>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            {/* <Form.Label>Password</Form.Label> */}
                            <Form.Control
                                className="text-control bg-sc pc"
                                type="password"
                                placeholder="Enter password"
                                required
                                onChange={(e) => setPasswordValue(e.currentTarget.value)}
                            />
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicConfirmPassword">
                            {/* <Form.Label>Confirm password</Form.Label> */}
                            <Form.Control
                                className="text-control bg-sc pc"
                                type="password"
                                placeholder="Re-enter password"
                                required
                                onChange={(e) => setConfirmPasswordValue(e.currentTarget.value)}
                            />
                        </Form.Group>

                        <Row>
                            <Form.Group as={Col} sm={4} className="mb-2" controlId="formBasicBirthDate">
                                {/* <Form.Label>Birth Date</Form.Label> */}
                                <Form.Control
                                    className="text-control bg-sc pc"
                                    type="date"
                                    required
                                    onChange={(e) => setBirthDateValue(new Date(e.currentTarget.value))}
                                />
                            </Form.Group>
                            <Col></Col>
                            <Col></Col>
                        </Row>
                        <Form.Group as={Col} className="mb- font-weight-light" controlId="formBasicCheckbox">
                            <Form.Check
                                type="switch"
                                className="mx-auto text-muted d-inline"
                                required
                            >
                            </Form.Check>
                            <Form.Label className="ml-1 text-muted">You agree with our <Link to="/tos" className="tr">terms of service</Link> </Form.Label>
                            <RecaptchaProviderForm className="my-2" action="register" setRecaptchaValueAux={setRecaptchaValue} recaptchaValueAux={recaptchaValue} onCooldownAux={onCooldown} setOnCooldownAux={setOnCooldown} />
                        </Form.Group>
                        <Button type="submit" className="bc bg-sc w-100 submit-btn">
                            Submit
                        </Button>
                        {/* <Form.Group className="mb-3 text-center">
                            <Form.Text className="text-muted" >
                                We'll never share your data with anyone else.
                            </Form.Text>
                        </Form.Group> */}
                    </Form.Group>
                </Form>
            </div>
            <ToastContainer
                position="top-right"
                autoClose={5000}
                hideProgressBar={false}
                newestOnTop={false}
                closeOnClick
                rtl={false}
                pauseOnFocusLoss
                draggable
                pauseOnHover
                theme="light"
            />
        </>
    )
}

export default Register;