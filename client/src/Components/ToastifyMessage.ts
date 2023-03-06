import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ToastifyMessage = (props: { errorMessages: any, setErrorMessages: any }) => {
    const [errorMessages, setErrorMessages] = [props.errorMessages, props.setErrorMessages];
    if (errorMessages === undefined || errorMessages.length === 0)
        return;
    
    errorMessages.forEach((el: {type: string, message: string}) => {
        toast(el.message, {
            position: "top-right",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            theme: "light",
        })
    });
}

export default ToastifyMessage;