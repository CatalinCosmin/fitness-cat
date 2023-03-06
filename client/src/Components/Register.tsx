import { useEffect, useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";
import { useAsyncError, useNavigate } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import { register } from "../Services/AuthService";
import ErrorToast from "./ErrorToast";
import ToastifyMessage from "./ToastifyMessage";

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
    const [registerDto, setRegisterDto] = useState<{ username: string, email: string, password: string, birthDate: Date }>();

    const [onCooldown, setOnCooldown] = useState(false);


    useEffect(() => {
        setRegisterDto({username: usernameValue, password: passwordValue, email: emailValue, birthDate: birthDateValue});
        console.log(registerDto);
    }, [emailValue, usernameValue, passwordValue, birthDateValue, setEmailValue, setUsernameValue, setPasswordValue, setBirthDateValue]);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        event.stopPropagation();
        
        setErrorMessages([]);
        toast.dismiss();

        if(passwordValue !== confirmPasswordValue)
        {
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
        
        if(registerDto === undefined)
            return;
        const result = (await register(registerDto, setErrorMessages, errorMessages));
        if(result === false)
        {
            errorMessages.forEach((el: {type: string, message: string}) => {
                toast(el.message, {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "dark"
                })
            });
        }
        if(result === true)
            navigate('/login');
    }
    return (
        <>
        <Form onSubmit={handleSubmit} className="w-25 mt-10 mx-auto align-items-center">
            <Row>
                <Form.Group as={Col} sm={4} className="mb-3" controlId="formBasicUsername">
                    {/* <Form.Label>Username</Form.Label> */}
                    <Form.Control
                        type="text"
                        placeholder="Username"
                        required
                        onChange={(e) => setUsernameValue(e.currentTarget.value)}
                    />
                </Form.Group>

                <Form.Group as={Col} sm={8} className="mb-3" controlId="formBasicEmail">
                    {/* <Form.Label>Email address</Form.Label> */}
                    <Form.Control
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
                    type="password"
                    placeholder="Enter password"
                    required
                    onChange={(e) => setPasswordValue(e.currentTarget.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicConfirmPassword">
                {/* <Form.Label>Confirm password</Form.Label> */}
                <Form.Control
                    type="password"
                    placeholder="Re-enter password"
                    required
                    onChange={(e) => setConfirmPasswordValue(e.currentTarget.value)}
                />
            </Form.Group>

            <Row>
                <Form.Group as={Col} sm={8} className="mb-2" controlId="formBasicBirthDate">
                    {/* <Form.Label>Birth Date</Form.Label> */}
                    <Form.Control
                        type="date"
                        required
                        onChange={(e) => setBirthDateValue(new Date(e.currentTarget.value))}
                    />
                </Form.Group>
                <Col></Col>
                <Col></Col>
            </Row>
                <Form.Group as={Col} className="mb-1 font-weight-light" controlId="formBasicCheckbox">
                    <Form.Check
                        type="checkbox"
                        className="mx-auto"
                        label="You agree with our terms of service"
                        required
                    />
                </Form.Group>

            <Form.Group className="mb-3 text-center">
                <Form.Text className="text-muted" >
                    We'll never share your data with anyone else.
                </Form.Text>
            </Form.Group>

            <Button type="submit" className="w-100">
                Submit
            </Button>
        </Form>
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