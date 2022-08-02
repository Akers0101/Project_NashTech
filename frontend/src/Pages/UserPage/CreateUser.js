import { Form, Button } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import "./createUser.css";
import { message } from "antd";
import { Box, Radio, RadioGroup, FormControlLabel } from "@mui/material";
const CreateUser = () => {
  const userId = localStorage.getItem("userId");
  const token = localStorage.getItem("token");

  const [mess1, setMess1] = useState();
  const [mess2, setMess2] = useState();
  const [submitDisabled, setSubmitDisabled] = useState(true);
  const [newUser, setNewUser] = useState({
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    gender: "",
    joinedDate: "",
    role: "",
  });

  const navigate = useNavigate();



  const handleChange = (evt) => {
    const getNewUser ={
      ...newUser,
      [evt.target.name]: evt.target.value,
    };
      setNewUser(getNewUser);
      setSubmitDisabled(Object.values(getNewUser).some((x) => x === "" || x === null));
  };

  useEffect(() => {
    const dob = new Date(newUser.dateOfBirth);
    const today = new Date();

    const joinedDate = new Date(newUser.joinedDate);
    if (today.getYear() - dob.getYear() >= 18) {
      setMess1("");
    } else if (today.getYear() - dob.getYear() <= 0) {
      setMess1("Please input valid date of birth ");
      if(today.getMonth()<dob.getMonth()){
        setMess1("Please input valid date of birth ");
      }
      if(today.getMonth()>dob.getMonth()){
        setMess1("User is under 18. Please select a different date");
      }
      if((today.getMonth()- dob.getMonth())===0){
        if(today.getDate()<dob.getDate()){
          setMess1("Please input valid date of birth ");
        }else{
          setMess1("User is under 18. Please select a different date");
        }
      }
    } else if (today.getYear() - dob.getYear() < 18) {
      setMess1("User is under 18. Please select a different date");
    }

    if (dob.getFullYear() > joinedDate.getFullYear()) {
      setMess2("Joined date is not later than Date of Birth");
    } else if (dob.getFullYear() < joinedDate.getFullYear()) {
      if (today.getYear() < joinedDate.getYear()) {
        setMess2("Please input valid joined date ");
      }
      if (
        today.getDate() < joinedDate.getDate() &&
        today.getMonth() <= joinedDate.getMonth() &&
        today.getYear() <= joinedDate.getYear()
      ) {
        setMess2("Please input valid joined date ");
      } else {
        if (joinedDate.getFullYear() - dob.getFullYear() < 18) {
          setMess2("User is under 18. Please change joined date");
        }else if(today.getYear() - joinedDate.getYear() <0){
          setMess2("Please input valid joined date ");
        } else
         {
          if (joinedDate.getUTCDay() === 0 || joinedDate.getUTCDay() === 6) {
            setMess2(
              "Joined date is Saturday or Sunday. Please select a different date"
            );
          } else {
            setMess2("");
          }
        }
      }
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [newUser.dateOfBirth, newUser.joinedDate]);

  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    setSubmitDisabled(true);
    axios({
      method: "POST",
      url: `${process.env.REACT_APP_Backend_URI}/Users/add?userId=${userId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },

      data: newUser,
    })
      .then(
        function (response) {
          message.success("Successfully");
          navigate("/user-list");
        },
        (error) => {
          if (error?.response.status === 400) {
            message.error(error.response.data.message,2);
            setMess1("");
            setMess2("");
           
          }
        }
      )
      .catch(function (error) {
        console.log(error);
      });
  };

  return (
    <div className="App">
      <div className="card-body">
        <Box
          sx={{
            width: 500,
            maxWidth: "100%",
            margin: "auto",
          }}
        >
          <div className="header-component-text">
          <p>Create New User</p>
          </div>
          <br />
          <Form onSubmit={handleOnSubmit}>
            <Form.Group >
              <div class="input-group mb-3">
                <div class="text-firstName">
                  <span class="input-group" id="inputGroup-sizing-default">
                    First Name<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                
                <input
          inputProps={{ maxLength: 255 }}
                  type="text"
                  value={newUser.firstName}
                  onChange={handleChange}
                  name="firstName"
                  required
                  class="textbox-firstName"
                />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleCreateUser">
              <div class="input-group mb-3">
                <div class="text-firstName">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Last Name<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                
                <input
          inputProps={{ maxLength: 255 }}
                  type="text"
                  value={newUser.lastName}
                  onChange={handleChange}
                  name="lastName"
                  required
                  class="textbox-firstName"
                />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleCreateUser">
              <div class="input-group mb-3">
                <div class="text-DOB">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Date of Birth<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                
                <input
                  type="date"
                  value={newUser.dateOfBirth}
                  onChange={handleChange}
                  name="dateOfBirth"
                  required
                  class="installedDate"
                  min="1980-01-01"
                  max="2099-12-31"
                />
              </div>
              <div style={{ color: "red" }}>{mess1}</div>
            </Form.Group>
            <Form.Group>
              <div class="input-group mb-3">
                <div class="text-gender">
                  <span id="inputGroup-sizing-default">
                    Gender<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <RadioGroup row
                  name="gender"
                  value={newUser.gender}
                  onChange={handleChange}>
                  <div class="checkGender"><FormControlLabel  value={"Male"} control={<Radio />} label="Male" /></div>
                  <div class="checkGender1"><FormControlLabel  value={"Female"} control={<Radio />} label="Female" /></div>
                </RadioGroup>
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleCreateUser">
              <div class="input-group mb-3">
                <div class="text-joinedDate1">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Joined Date<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                
                <input
                  type="date"
                  onChange={handleChange}
                  value={newUser.joinedDate}
                  name="joinedDate"
                  required
                  class="installedDate1"
                  min="1980-01-01"
                  max="2099-12-31"
                />
              </div>
              <div style={{ color: "red" }}>{mess2}</div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleCreateUser">
              <div class="input-group">
                <div class="text-type">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Type<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>

                <Form.Select
                  required
                  value={newUser.role}
                  onChange={handleChange}
                  class="textbox-type"
                  name="role"
                  
                >
                  <option value={""} default={""} selected>Select role</option>
                  <option value={"Staff"}>Staff</option>
                  <option value={"Admin"}>Admin</option>
                </Form.Select>
              </div>
            </Form.Group>
        <Button className="btn-buttom11" variant="danger" type="submit" disabled={submitDisabled} >
          Save
        </Button>
        <Link to="/user-list" style={{ textDecoration: "none" }}>
        <Button variant="outline-secondary">
          Cancel
        </Button>
        </Link>
      </Form>
      </Box>
      </div>
    </div>
  );
};

export default CreateUser;
