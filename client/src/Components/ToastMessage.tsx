import { useState } from "react";
import { Col, Row, Toast } from "react-bootstrap";

const ToastMessage = (props: {header: string, message: string, type: number}) => {
    const [show, setShow] = useState(true);
    const variant = [
        'Primary',
        'Secondary',
        'Success',
        'Danger',
        'Warning',
        'Info',
        'Light',
        'Dark'
    ];

    return (
                <Toast 
                    bg={variant.at(props.type)?.toLowerCase()}
                    onClose={() => setShow(false)} 
                    show={show} 
                    delay={2000} 
                    autohide
                    className="mb-3 mr-3"
                >
                    <Toast.Header>
                        <img
                            src="holder.js/20x20?text=%20"
                            className="rounded me-2"
                            alt=""
                        />
                        <strong className="me-auto">{props.header}</strong>
                        <small>now</small>
                    </Toast.Header>
                    <Toast.Body className="bc">{props.message}</Toast.Body>
                </Toast>
    )
}

export default ToastMessage;