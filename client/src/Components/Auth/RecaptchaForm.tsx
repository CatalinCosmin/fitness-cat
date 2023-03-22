import React, { useEffect } from 'react';
import ReactDOM from 'react-dom';
import Recaptcha from 'react-recaptcha';
import { useLocation } from 'react-router-dom';
import Form from 'react-bootstrap/Form';
import "bootstrap";

// site key
const sitekey = "6Le_aw8lAAAAAB5zjTqXi3ojS3GrOqgO84WsCwK9";

// specifying your onload callback function
const callback = () => {
    console.log('Done!!!!');
};

const verifyCallback = (response: any) => {
    console.log("da");
    console.log(response);
};

const expiredCallback = () => {
    console.log(`Recaptcha expired`);
};

// define a variable to store the recaptcha instance
let recaptchaInstance: Recaptcha | null;

// handle reset
const resetRecaptcha = () => {
    if (recaptchaInstance == null)
        return;
    recaptchaInstance.reset();
};

export const RecaptchaForm = () => {
    
    return (
        <Form.Group>

            <Form.Label className="pc py-3 h6">Google Recaptcha</Form.Label>
            <Recaptcha
                ref={e => recaptchaInstance = e}
                sitekey={sitekey}
                theme="dark"
                size="normal"
                render="explicit"
                verifyCallback={(data) => console.log(data)}
                expiredCallback={expiredCallback}
            />
        </Form.Group>
    );
}
