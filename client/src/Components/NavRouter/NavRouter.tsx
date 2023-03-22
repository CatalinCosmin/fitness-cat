import { Routes, Route } from "react-router-dom";
import EmailVerification from "../EmailVerification";
import Login from "../Auth/Login";
import Register from "../Auth/Register";
import Test from "../Test";
import WorkoutRoutines from "../Workout/WorkoutRoutine/WorkoutRoutines";
import Home from "../Home";

const NavRouter = (props: { token: any, setToken: any }) => {
  const [token, setToken] = [props.token, props.setToken];
  return (
    <Routes>
      {(token !== null && token.length > 2) &&
        <Route path="/workoutroutines/:id?" element={<WorkoutRoutines token={token} setToken={setToken} />} />
      }
      <Route path="/" element={<Home />} />
      {(token === null || token.length <= 2) &&
        <Route id="login" path="/login" element={<Login token={token} setToken={setToken} />} />
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