const ErrorMessage = (errorMessages: any) => {
    let label = <label></label>;
    errorMessages.forEach((e: any) => {
        label = <label className="w-100 alert-warning alert-auth">{e.message}</label>
        if (e.type === "Username" || e.type === "Email")
            label = <label className="w-100 alert-warning alert-auth">{e.message}</label>
    })
    return label;
}

export default ErrorMessage;