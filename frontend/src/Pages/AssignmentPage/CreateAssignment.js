import { Form } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "./createAssignment.css"
import { message } from "antd";
import ListUser from "./Modal/ListUser";
import ListAsset from "./Modal/ListAsset";
import { Input, Space,Button } from "antd";
const CreateAssignment = () => {
  const [gridData, setGridData] = useState([]);
  const [gridData2, setGridData2] = useState([]);
  const token = localStorage.getItem("token");
  const [openPopup2, setOpenPopup2] = useState(false);
  const [openPopup, setOpenPopup] = useState(false);
  const [submitDisabled, setSubmitDisabled] = useState(true);
  const byuserId = localStorage.getItem("userId");
  const [loading, setLoading] = useState(false);
  const [newAssignment, setnewAssignment] = useState({
    assignedByUserId: "",
    assignedToUserId: "",
    assetId: "",
    assignedDate: "",
    note: "",
    assetName: "",
    assignedToUserName: "",
  });

  const navigate = useNavigate();
  const { Search, TextArea } = Input;
  const handleChange = (evt) => {
    const updateThisAssignment ={
      ...newAssignment,
      [evt.target.name]: evt.target.value,
    }
    setnewAssignment(updateThisAssignment);
   
  };
useEffect(() => {
 
  setSubmitDisabled((newAssignment.assignedToUserId ==='' || newAssignment.assetId ===''
  || newAssignment.assignedDate ==='' )?true:false);
},[newAssignment.assignedToUserId, newAssignment.assetId,newAssignment.assignedDate])
 
  const toListUser = (evt) => {
    setOpenPopup(true);
  };

  const toListAsset = (evt) => {
    setOpenPopup2(true);
  };
  useEffect(() => {
    setLoading(true);
    axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Users/GetAllActive?userId=${byuserId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }).then(function (response) {
      setGridData(response.data);
      setLoading(false);
    });
  }, []); // eslint-disable-line react-hooks/exhaustive-deps
  useEffect(() => {
    axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/all?userId=${byuserId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }).then(function (response) {
      setGridData2(response.data);
    });
  }, []); // eslint-disable-line react-hooks/exhaustive-deps
  function backtolist() {
    
    navigate("/assignment-list");
  }
  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    setSubmitDisabled(true);
    axios({
      method: "POST",
      url: `${process.env.REACT_APP_Backend_URI}/Assignment/add`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },

      data: newAssignment,
    })
      .then(
        function (response) {
          message.success("Successfully");
          navigate("/assignment-list");
        },
        (error) => {
          if (error?.response.status === 400) {
            message.error("Create Assignment fail");
          }
        }
      )
      .catch(function (error) {
        console.log(error);
        message.error("Create fail!");
      });
  };
  useEffect(() => {
  });
  const[imess,setIMess]= useState("");
  useEffect(() => {
    const today = new Date();
    const date= new Date(newAssignment.assignedDate);
    if(today.getFullYear() > date.getFullYear()){
      setIMess("Assign Date must be current date or future date");
    }
    else if (today.getFullYear()-date.getFullYear() === 0){
         if(today.getMonth() > date.getMonth()){
           setIMess("Assign Date must be current date or future date");
         }else if(today.getMonth()-date.getMonth() === 0){
           if(today.getDate()>date.getDate()){
             setIMess("Assign Date must be current date or future date");
           }else{
             setIMess("");
           }
         }else{
           setIMess("");
         }
    }
    else{
     setIMess("");
    }
  },[newAssignment.assignedDate])
  // useEffect(() => {
  //   setSubmitDisabled(Object.values(newAssignment).some(x => x === ''))
  // },[newAssignment]);
  return (
    <div className="App">
      <div className="card-body">
        <Space direction="vertical">
        <div className="header-component-text">
          <p>Create New Assignment</p>
          </div>
          <br />
          <Form >
            <Form.Group className="mb-3" controlId="formBasicTitle">
              <div class="input-group mb-3">
                <div class="text-user">
                  <span class="input-group" id="inputGroup-sizing-default">
                    User<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                
                <Search className="textbox-user" placeholder="Select User" size="large" value={newAssignment.assignedToUserName} onChange={handleChange}   onSearch={toListUser} style={{ width: 300 }} />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle">
              <div class="input-group mb-3">
                <div class="text-asset">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Asset<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
               
                <Search className="textbox-asset"  placeholder="Select Asset"  size="large" value={newAssignment.assetName}  onSearch={toListAsset} style={{ width: 300 }} />

              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle">
              <div class="input-group mb-3">
                <div class="text-assignedDate">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Assigned Date<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <input
                  type="date"
                  onChange={handleChange}
                  value={newAssignment.assignedDate}
                  name="assignedDate"
                  required
                  class="installedDate99"
                  min="2000-12-31"
                  max="2099-12-31"
                />
              </div>
              <div style={{ color: "red" }}>{imess}</div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle">
              <div class="input-group mb-3">
                <div class="text-note">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Note&nbsp;
                  </span>
                </div>
                <TextArea
                  name="note"
                  value={newAssignment.note}
                  onChange={handleChange}
                  rows={4}
                  class ="textbox-note"
                  style={{width: 290}}
                  
                />
              </div>
            </Form.Group>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <Button type="primary" danger
           size={"large"}  onClick={handleOnSubmit} disabled={submitDisabled}>
              Save
            </Button>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <Button onClick={()=>backtolist()} type="primary" 
           size={"large"}>
              Cancel
            </Button>
          </Form>
        </Space>
      </div>
      <ListUser
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
        gridData={gridData}
        selectedValue={setnewAssignment}
        assignment={newAssignment}
        loading={loading}
      />

      <ListAsset
        openPopup={openPopup2}
        setOpenPopup={setOpenPopup2}
        gridData2={gridData2}
        selectedValue={setnewAssignment}
        assignment={newAssignment}
        loading={loading}
      />
    </div>
  );
};

export default CreateAssignment;
