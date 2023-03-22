import { useState } from "react";
import { Form } from "react-bootstrap";
import { useSearchParams } from "react-router-dom";
import { verifyAccount } from "../Services/AuthService";

const EmailVerification = () => {
    const [searchParams] = useSearchParams();
    const [success, setSuccess] = useState(false);
    let token = searchParams.get('token');
    
    const handleVerify = async () => {
        if(token !== undefined)
        {
            let result: boolean = (await verifyAccount(token));
            if(success !== result)
                setSuccess(result);
        }
    }

    window.addEventListener('load', handleVerify);

    return (
        <>
            
            {success === true && 
            <Form.Label className="ms-auto w-100 text-center mt-7 h3">Account verified</Form.Label>}
            {success === false && 
            <Form.Label className="ms-auto w-100 text-center mt-7 h3">Token is not valid</Form.Label>}
        </>
    )
}

export default EmailVerification;