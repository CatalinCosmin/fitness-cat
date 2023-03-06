
import axios from "axios"
import { stringify } from "querystring";
import React, { useEffect, useInsertionEffect, useState } from "react"
import { Navigate, useNavigate } from "react-router-dom";
import { login, register } from "../Services/AuthService";
import DatePicker from "react-datepicker";

const Auth = (props: { token: any, setToken: any }) => {
  // const [token, setToken] = [props.token, props.setToken];
  // const [authMode, setAuthMode] = useState("signin");

  // let [euErrorMessage, setEuErrorMessage] = useState('');
  // let [metaErrorMessage, setMetaErrorMessage] = useState('');
  // let [passwordErrorMessage, setPasswordErrorMessage] = useState('');

  // const [errorMessages, setErrorMessages] = useState<{ type: string, message: string }[]>([]);
  // useEffect(() => {

  //   errorMessages.forEach((e: any) => {
  //     if (e.type === "Pasword")
  //       setPasswordErrorMessage(e.message);
  //     else if (e.type === "Email" || e.type === "Username")
  //       setEuErrorMessage(e.message);
  //     else if (e.type === "Meta")
  //       setMetaErrorMessage(e.message);
  //   })
  //   console.log(euErrorMessage);
  // }, [errorMessages, setErrorMessages]);

  // const changeAuthMode = () => {
  //   setAuthMode(authMode === "signin" ? "signup" : "signin");
  //   setErrorMessages([]);
  // }

  // let navigate = useNavigate();
  // if (authMode === "signin") {
  //   const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {
  //     passwordErrorMessage = '';
  //     euErrorMessage = '';
  //     metaErrorMessage = '';
  //     setErrorMessages([]);
  //     let result = (await login(event, setToken, setErrorMessages, errorMessages));
  //     if (result === true) {
  //       navigate('/');
  //     }
  //   }

  //   return (
  //     <div className="Auth-form-container">
  //       <form className="Auth-form" onSubmit={handleLogin}>
  //         <div className="Auth-form-content">
  //           <h3 className="Auth-form-title">Sign In</h3>
  //           <div className="text-center">
  //             Not registered yet?{" "}
  //             <span className="link-primary" onClick={changeAuthMode}>
  //               Sign Up
  //             </span>
  //           </div>
  //           <label>{metaErrorMessage}</label>
  //           <div className="form-group mt-3">
  //             <label>Username or Email address</label>
  //             <input
  //               type="text"
  //               name="userinput"
  //               className="form-control mt-1"
  //               placeholder="Enter username or email"
  //               required
  //               maxLength={320}
  //             />
  //             <label>{euErrorMessage}</label>
  //           </div>
  //           <div className="form-group mt-3">
  //             <label>{ }</label>
  //             <label>Password</label>
  //             <input
  //               type="password"
  //               name="password"
  //               className="form-control mt-1"
  //               placeholder="Enter password"
  //               autoComplete="current-password"
  //               required
  //             />
  //             <label>{passwordErrorMessage}</label>
  //           </div>
  //           <div className="d-grid gap-2 mt-3">
  //             <button type="submit" className="btn btn-primary">
  //               Submit
  //             </button>
  //           </div>
  //           <p className="text-center mt-2">
  //             Forgot <a href="#">password?</a>
  //           </p>
  //         </div>
  //       </form>
  //     </div>
  //   )
  // }


  // const handleRegister = (event: React.FormEvent<HTMLFormElement>) => {
  //   register(event, setErrorMessages, errorMessages);
  // }


  // return (
  //   <div className="Auth-form-container">
  //     <form className="Auth-form" onSubmit={handleRegister}>
  //       <div className="Auth-form-content">
  //         <h3 className="Auth-form-title">Sign In</h3>
  //         <div className="text-center">
  //           Already registered?{" "}
  //           <span className="link-primary" onClick={changeAuthMode}>
  //             Sign In
  //           </span>
  //         </div>
  //         <div className="form-group mt-3">
  //           <input
  //             type="text"
  //             className="form-control mt-1"
  //             placeholder="Username"
  //             required
  //             minLength={6}
  //             maxLength={30}
  //           />
  //         </div>
  //         <div className="form-group mt-3">
  //           <input
  //             type="email"
  //             className="form-control mt-1"
  //             placeholder="Email address"
  //             required
  //             maxLength={320}
  //             pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$"
  //           />
  //         </div>
  //         <div className="form-group mt-3">
  //           <input
  //             type="password"
  //             className="form-control mt-1"
  //             placeholder="Password"
  //             autoComplete="new-password"
  //             required
  //             minLength={8}
  //           />
  //         </div>
  //         <div className="form-group mt-3">
  //           <input
  //             type="password"
  //             className="form-control mt-1"
  //             placeholder="Confirm password"
  //             autoComplete="repeat-password"
  //             required
  //             minLength={8}
  //           />
  //         </div>
  //         <div className="form-group mt-3">
  //           <input 
  //             type="date" 
  //             required
  //           />
  //         </div>
  //         <div className="d-grid gap-2 mt-3">
  //           <button type="submit" className="btn btn-primary">
  //             Submit
  //           </button>
  //         </div>
  //       </div>
  //     </form>
  //   </div>
  // )
}

export default Auth;