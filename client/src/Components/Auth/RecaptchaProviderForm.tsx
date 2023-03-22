import React, { useEffect, useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import { withGoogleReCaptcha } from 'react-google-recaptcha-v3';
import { IWithGoogleReCaptchaProps } from 'react-google-recaptcha-v3/dist/types/with-google-recaptcha';

const ReCaptchaComponent = (props: any) => {
    const [token, setToken] = [props.recaptchaValueAux, props.setRecaptchaValueAux];
    const [onCooldown, setOnCooldown] = [props.onCooldownAux, props.setOnCooldownAux];

    const [checked, setChecked] = useState(false);
    const handleChange = () => {
        if (checked === false && (token === null || token === '')) {
            handleVerifyRecaptcha();
        }
        setIsDisabled(!isDisabled);
        setChecked(!checked);
    };

    useEffect(() => {
        if (onCooldown === true) {
            setIsDisabled(false);
            setChecked(false);
            setToken('');
        }
    }, [onCooldown]);

    const [isDisabled, setIsDisabled] = useState(false);

    const handleVerifyRecaptcha = async () => {
        const { executeRecaptcha } = (props as IWithGoogleReCaptchaProps)
            .googleReCaptchaProps;

        if (!executeRecaptcha) {
            console.log('Recaptcha has not been loaded');
            return;
        }

        const token = await executeRecaptcha(props.action);
        setToken(token);
    };

    return (
        <Form.Group>
            <Form.Check
                type="switch"
                disabled={isDisabled}
                checked={checked}
                label="I am not a robot"
                className='mb-3 text-muted'
                onChange={handleChange}
            />
        </Form.Group>
    );
};

export const RecaptchaProviderForm = withGoogleReCaptcha(ReCaptchaComponent);