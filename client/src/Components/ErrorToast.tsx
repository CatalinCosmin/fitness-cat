import { ReactElement, useEffect, useState } from "react";
import { JsxElement } from "typescript";
import ToastMessage from "./ToastMessage";

const ErrorToast = (props: {errorMessages: any, setErrorMessages: any}) => {
    const [errorMessages, setErrorMessages] = [props.errorMessages, props.setErrorMessages];
    const [errors, setErrors] = useState<ReactElement[]>([<></>]);

    useEffect(() => {
        setErrors([<></>]);
        let aux: ReactElement<any, any>[] = [];
        errorMessages.forEach((el: any) => {
            aux.push(<ToastMessage header={el.type} message={el.message} type={4} />);
        })
        setErrors(aux);
    }, [errorMessages, setErrorMessages]);

    return (
        <>
        {errors.length > 0 && errors}
        </>
    )
}

export default ErrorToast;