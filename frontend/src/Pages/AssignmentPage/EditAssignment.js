import { Form } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

import { message } from "antd";
import "./createAssignment.css"
import ListUser from "./Modal/ListUser";
import ListAsset from "./Modal/ListAsset";
import {Button} from "antd";
import { Input, Space } from 'antd';
const EditAssignment = () => {
  const [gridData, setGridData] = useState([]);
  const [gridData2, setGridData2] = useState([]);
  const token = localStorage.getItem("token");
  const [openPopup2, setOpenPopup2] = useState(false);
  const [openPopup, setOpenPopup] = useState(false);
  const [submitDisabled, setSubmitDisabled] = useState(true);
  const byuserId = localStorage.getItem("userId");
  const today = new Date().toLocaleString();
  const [loading, setLoading] = useState(false);
  const [editAssignment, seteditAssignment] = useState({
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
    seteditAssignment({
      ...editAssignment,
      [evt.target.name]: evt.target.value,

    });
  };


  const toListUser = (evt) => {

    setOpenPopup(true);

  };

  const toListAsset = (evt) => {
    setOpenPopup2(true);
  };
  useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Assignment/detail?assignmentId=${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
    }
    )
      .then(function (response) {
        const resData = response.data;
        seteditAssignment({ ...resData, assignedDate: new Date(resData.assignedDate).toLocaleDateString('en-CA') });
      }, [])
      .catch((error) => {
        console.log(error);
      });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
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
    localStorage.setItem("touserId", "");
    localStorage.removeItem("toUserName", "");
    localStorage.setItem("toAssetId", "");
    localStorage.removeItem("toAssetName", "");
    navigate("/assignment-list");
  }
  const { id } = useParams();
  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    setSubmitDisabled(true);
    axios({
      method: "PUT",
      url: `${process.env.REACT_APP_Backend_URI}/Assignment/update?assignmentId=${id}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },

      data: editAssignment,
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


  })
  useEffect(() => {

    setSubmitDisabled((editAssignment.assignedToUserId === '' || editAssignment.assetId === ''
      || editAssignment.assignedDate === '') ? true : false);
  }, [editAssignment.assignedToUserId, editAssignment.assetId, editAssignment.assignedDate])
  return (
    <div className="App">
      <div className="card-body">
       
            <Space direction="vertical">
          <div className="header-component-text">
          <p>Edit Assignment</p>
          </div>
          <br />
          <Form>
            <Form.Group className="mb-3" controlId="formBasicTitleEditAssignment">
              <div class="input-group mb-3">
                <div class="text-user">
                  <span class="input-group" id="inputGroup-sizing-default">
                    User<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>

                <Search className="textbox-user" placeholder="Seclect User" size="large" value={editAssignment.assignedToUserName} onSearch={toListUser} style={{ width: 300 }} />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleEditAssignment">
              <div class="input-group mb-3">
                <div class="text-asset">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Asset<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>

                <Search className="textbox-asset" placeholder="Select User" size="large" value={editAssignment.assetName} onSearch={toListAsset} style={{ width: 300 }} />

              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleEditAssignment">
              <div class="input-group mb-3">
                <div class="text-assignedDate">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Assigned Date<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>

                <input
                  type="date"
                  onChange={handleChange}
                  value={editAssignment.assignedDate}
                  name="assignedDate"
                  required
                  class="installedDate99"
                  min={today}
                  max="2099-12-31"

                />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitleEditAssignment">
              <div class="input-group mb-3">
                <div class="text-note">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Note&nbsp;
                  </span>

                </div>

                <TextArea class="textbox-note"
                  style={{ width: 289 }} name="note" value={editAssignment.note} onChange={handleChange} rows={4} placeholder="Note something" />
              </div>
            </Form.Group>


            <Button type="primary" danger
            onClick={handleOnSubmit}
           size={"large"} disabled={submitDisabled}>
              Save
            </Button>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <Button onClick={() => backtolist()} type="primary" 
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
        selectedValue={seteditAssignment}
        assignment={editAssignment}
        loading={loading}

      />


      <ListAsset
        openPopup={openPopup2}
        setOpenPopup={setOpenPopup2}
        gridData2={gridData2}
        selectedValue={seteditAssignment}
        assignment={editAssignment}
        loading={loading} />
    </div>
  );
};

export default EditAssignment;
