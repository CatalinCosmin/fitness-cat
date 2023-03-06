import { Routes, Route } from "react-router-dom";
import EmailVerification from "./EmailVerification";
import Login from "./Login";
import Register from "./Register";
import Test from "./Test";

const NavRouter = (props: { token: any, setToken: any }) => {
  const [token, setToken] = [props.token, props.setToken];
  return (
    <Routes>
      <Route path="/" element={<></>} />
      {(token === null || token.length <= 2) &&
        <Route path="/login" element={<Login token={token} setToken={setToken} />} />
      }
      {(token === null || token.length <= 2) &&
        <Route path="/register" element={<Register token={token} setToken={setToken} />} />
      }
      {(token !== null && token.length > 2) &&
        <Route path="/jwt" element={<Test token={token} setToken={setToken} />} />
      }

      {(token === null || token.length <= 2) &&
        <Route path="/verify_account" element={<EmailVerification />} />
      }
    </Routes>
  )
}

export default NavRouter;