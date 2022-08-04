import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import authService from "../../Services/auth-service";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button, Form } from "react-bootstrap";
import "./login.css"
import VisibilityIcon from "@mui/icons-material/Visibility";

import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import { TextField, InputAdornment, IconButton } from "@mui/material";
import AccountCircle from "@mui/icons-material/AccountCircle";
const Login = () => {
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errMessage, setErrMessage] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const handleClickShowPassword = () => setShowPassword(!showPassword);
  const handleMouseDownPassword = () => setShowPassword(!showPassword);
  const [submitDisabled, setSubmitDisabled] = useState(true);
 
  const navigate = useNavigate();

 
  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      await authService.login(userName, password).then(
        (response) => {
          localStorage.setItem("token", response.token);
          localStorage.setItem("userName", response.userName);
          localStorage.setItem("role", response.role);
          localStorage.setItem("isFirstLogin", response.isFirstLogin);
          localStorage.setItem("location", response.location);
          localStorage.setItem("userId", response.userId);
          navigate('/')
        },
        (error) => {
          if (error?.response.status === 400 ||error?.response.status === 500) {
            setErrMessage(
              error.response.data.message
            );
          }
        }
      );
    } catch (err) {
      console.log(err);
      
    }
    };
React.useEffect(() => {
  if ( 0 < password.length && password.length < 2) {
    setErrMessage('Password should be 8-255 characters');
    return false;
  }
  
  else if (password.length >255) {
    setErrMessage('Password should be 8-255 characters');;
    return false;
  } else {
    setErrMessage('');
    return true;
  }
},[password])
  return (
    <div >
      <div >
        {localStorage.getItem("token") ? (
           
          window.location='/'       
        ) : (
          <Form onSubmit={handleLogin}>
            <div className="header-component-text">
          <p>Login</p>
          </div>

            <div>
              <TextField
              className="field-login"
          inputProps={{ maxLength: 255 }}
               class="btn-userName"
                placeholder="Enter Username"
                type="text"
                name="username"
                value={userName}
                onChange={(e) => {setUsername(e.target.value)
      setSubmitDisabled((e.target.value===''||password==='')?true:false);
    }}
                required
                InputProps={{style: { fontSize: 17.2 } ,
                  endAdornment: (
                    <InputAdornment position="end">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
              />
            </div>
            
            <div>
              <TextField
              className="field-login"
          inputProps={{ maxLength: 255 }}
                type={showPassword ? "text" : "password"}
                name="password"
                value={password}
                onChange={(e) => {setPassword(e.target.value);
      setSubmitDisabled((e.target.value===''||userName==='')?true:false);
                }}
                placeholder="Enter Password"
                required
                InputProps={{style: { fontSize: 17 } ,
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton 
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                      >
                        {showPassword ? (
                          <VisibilityIcon />
                        ) : (
                          <VisibilityOffIcon />
                        )}
                      </IconButton>
                    </InputAdornment>
                  ),
                }}
              />
            </div>

            <label
              style={{ color: "red", fontSize: "15px", fontWeight: "bold" }}
            >
              {errMessage}
            </label>
            <div>
              <Button variant="danger" type="submit" disabled={submitDisabled}>
                Login
              </Button>
            </div>
          </Form>
        )}
      </div>
    </div>
  );
};
export default Login;
