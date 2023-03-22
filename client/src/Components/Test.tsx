import React, { useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import DatePicker from "react-datepicker";

const Test = (props: {token: any, setToken: React.Dispatch<any>}) => {
    // const [token, setToken] = useState([...props.]);
    const navigate = useNavigate();
    const deleteToken = () => {
        props.setToken('');
    }
    if (props.token == null || (props.token != null && props.token.length === 2)) {
        return <Navigate to="/auth" replace />
    }
    else {
        return (
            
            <div>
                <DatePicker className="position-static" selected={null} onChange={(date: Date) => date}>Birth date</DatePicker>
                <h1>
                    {props.token?.length}
                </h1>
                <h1>Remove Token</h1>
                <button className="btn btn-primary" onClick={()=>{props.setToken(''); navigate("/");}}>Logout</button>
                <p>{props.token}</p>
            </div>
        )
    }
}

export default Test;