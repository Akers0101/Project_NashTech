import axios from "axios";
import React, { useState,useEffect } from "react";
import "./login.css";
import { Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Popup from "../../Components/Modal/Popup";
import Paper from "@mui/material/Paper";
import VisibilityIcon from '@mui/icons-material/Visibility';
import { makeStyles } from "@mui/styles";
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';

import {message} from "antd";
const FirstLogin = () => {
  const styles = makeStyles({
    formcontrol: {
      padding: "0.375rem 0.85rem",
      fontsize: "1rem",
      fontweight: "400",
      lineheight: "1.5",
      backgroundcolor: "#fff",
      backgroundclip: "padding-box",
      borderradius:" 0.25rem",
  },
  });
  
  const [openPopup, setOpenPopup] = useState(true);
  const token = localStorage.getItem("token");
  const username = localStorage.getItem("userName");
  const [message1, setMessage1] = useState();
  const [submitDisabled, setSubmitDisabled] = useState(true);
  const [data, setData] = useState({
    userName: username,
    newPassword: "",
  });
  useEffect(() => {
    setSubmitDisabled((data.newPassword ==='')?true:false);
  },[data.newPassword])
  const [newPasswordShown, setNewPasswordShown] = useState(false);
  const submit = () => {
   
    axios({
      method: "PUT",
      url: `${process.env.REACT_APP_Backend_URI}/Users/first-login`,
      data: data,
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    })
      .then((res) => {
        localStorage.setItem('isFirstLogin','False');
        setOpenPopup(false);
        message.success("Successfully");
        window.location.reload();
      },
      (error) => {
        if (error?.response.status === 400) {
          setMessage1(error.response.data.message) 
           
           
          }
    })
      .catch((err) => {
        console.log(err)
        setOpenPopup(true);
      });
     
  };
  useEffect(() => {
    if ( 0 < data.newPassword.length && data.newPassword.length < 8) {
      setMessage1('New Password should be 8-255 characters');
      return false;
    }
    
    else if (data.newPassword.length >255) {
      setMessage1('New Password should be 8-255 characters');;
      return false;
    } else {
      setMessage1('');
      return true;
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data.newPassword]);

  const handle = (e) => {
    setData({
      ...data,
      [e.target.name] : e.target.value,
    });
   
   
  };
  const toggleNewPassword = () => {
    setNewPasswordShown(!newPasswordShown);
  };
  const classes = styles();
  return (
    <div className="App">
      <Paper elevation={3}>
        <Popup
          color="error"
          title="You must change password in first login !"
          openPopup={openPopup}
          setOpenPopup={setOpenPopup}
        >
          <p>This is the first time you logged in </p>
          <p>You have to change password to continue</p>
          <div>
            New Password
            <br/>
            <input
          inputProps={{ maxLength: 255 }}
              type={newPasswordShown ? "text" : "password"}
              placeholder="New Password"
              className={classes.formcontrol}
              id="title"
              name="newPassword"
              value={data.newPassword}
              onChange={(e) => handle(e)}
              required
            />
              {newPasswordShown ? <VisibilityIcon onClick={toggleNewPassword} /> : <VisibilityOffIcon onClick={toggleNewPassword}/>}
          </div>
          <div style={{ color: 'red' }}>{message1}</div> 
          <br />
          <Button
          disabled={submitDisabled}
            className="btn btn-danger"
            onClick={() => {
              submit();
            }}
          >
            Save
          </Button>
        </Popup>
      </Paper>
    </div>
  );
};
export default FirstLogin;
