import { Form } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { Box, Radio, RadioGroup, FormControlLabel } from "@mui/material";
import { Input } from "antd";
import { message } from "antd";
import "./Csses/createAsset.css"
import Popup2 from "../../Components/Modal/Popup2";
import { Link } from "react-router-dom";
import {Button } from "antd"
const CreateAsset = () => {
  const location = localStorage.getItem("location");
  const token = localStorage.getItem("token");
  const [categories, setCategories] = useState([]);
  const [openPopup, setOpenPopup] = useState(false);
  const [submitDisabled, setSubmitDisabled] = useState(true);
  const userId = localStorage.getItem("userId");
  const [newCategory, setNewCategory] = useState({
    categoryName: "",
    perfix: "",
  });
  const [newAsset, setNewAsset] = useState({
    assetName: "",
    categoryId: "",
    specification: "",
    location: location,
    installedDate: "",
    assetState: "",
  });

  const navigate = useNavigate();
  const [imess, setIMess] = useState();
  const [mess, setMess] = useState();
  const handleChange = (evt) => {
    const getNewAsset = {
      ...newAsset,
      [evt.target.name]: evt.target.value,
    };
    setNewAsset(getNewAsset);
    setSubmitDisabled(
      Object.values(getNewAsset).some((x) => x === "" || x === null)
    );
  };
  const handleChangeCate = (evt) => {
    setNewCategory({
      ...newCategory,
      [evt.target.name]: evt.target.value,
    });
  };

  useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Category/all`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }
    )
      .then(function (response) {
        setCategories(response.data);

      })
      .catch((error) => {
        console.log(error);
      });

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [categories]);
  const addCategory = (e) => {
    e.preventDefault();
    axios({
      url: `${process.env.REACT_APP_Backend_URI}/Category`,
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      data: newCategory,
    })
      .then(
        function (response) {
          setOpenPopup(false);
          message.success("Successfully");
          setNewCategory({
            categoryName: "",
            prefix: "",
          });
        },
        (error) => {
          if (error?.response.status === 400) {
            setMess(error.response.data.message);
          }
        }
      )
      .catch(function (error) {
        message.error("Create Category fail");
        console.log(error);
      });
  };
 useEffect(() => {
   const today = new Date();
   const date= new Date(newAsset.installedDate);
   if(today.getFullYear()<date.getFullYear()){
     setIMess("Installed Date must not be in the future");
   }
   else if (today.getFullYear()-date.getFullYear() === 0){
        if(today.getMonth() < date.getMonth()){
          setIMess("Installed Date must not be in the future");
        }else if(today.getMonth()-date.getMonth() === 0){
          if(today.getDate()<date.getDate()){
            setIMess("Installed Date must not be in the future");
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
 },[newAsset.installedDate])
  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    setSubmitDisabled(true);
    axios({
      method: "POST",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/add?userId=${userId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },

      data: newAsset,
    })
      .then(
        function (response) {
          setOpenPopup(false);
          message.success("Successfully");
          navigate("/asset-list");
        },
        (error) => {
          if (error?.response.status === 400) {
            setIMess(error.response.data.message);
          }
        }
      )
      .catch(function (error) {
        console.log(error);
        message.error("Create fail!");
      });
  };
  const handleChangeCategory = (e) => {
    setNewAsset({
      ...newAsset,
      categoryId: e.target.value,
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
          <p>Create New Asset</p>
          </div>
          <br />
          <Form class="btn-form1" >
            <Form.Group className="formBasicTitleCreateAsset1">
              <div class="input-group mb-3">
                <div class="text-assetName">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Asset Name<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <input
          inputProps={{ maxLength: 255 }}
                  type="text"
                  onChange={handleChange}
                  value={newAsset.assetName}
                  name="assetName"
                  required
                  class="textbox-assetName"
                />
              </div>
            </Form.Group>
            <Form.Group >
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Category<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <Form.Select className="formBasicTitleCreateAsset2"
                  required
                  name="categoryId"
                  onChange={handleChangeCategory}
                  value={newAsset.categoryId}
                >
                  <option selected>Select Category</option>
                  {categories.map((item) => (
                    <option value={item.categoryId}>{item.categoryName}</option>
                  ))}
                </Form.Select>
                <div class="input-group-append">
                  <button
                    class="btn-buttom1 btn btn-outline-secondary"
                    type="button"
                    onClick={() => setOpenPopup(true)}
                  >
                    Add Category
                  </button>
                </div>
              </div>
            </Form.Group>
            <Form.Group>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="text-specification" id="inputGroup-sizing-default">
                    Specification<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <textarea
          inputProps={{ maxLength: 255 }}
                  type="text"
                  onChange={handleChange}
                  value={newAsset.specification}
                  name="specification"
                  required
                  class="textbox-specification"
                />
              </div>
            </Form.Group>
            <Form.Group >
              <div class="input-group mb-3">
                <div class="text-DOB">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Installed Date<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <input
                  type="date"
                  onChange={handleChange}
                  value={newAsset.installedDate}
                  name="installedDate"
                  required
                  class="installedDate2000"
                  min="1980-01-01"
                  max="2099-12-31"
                />
              </div>
              <div style={{ color: 'red' }}>{imess}</div> 
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicAuthor">
              <div class="input-group mb-3">
                <div class="text-assetState">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Asset State<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <RadioGroup
                  aria-labelledby="demo-controlled-radio-buttons-group"
                  name="assetState"
                  value={newAsset.assetState}
                  required
                  onChange={handleChange}
                >
                  
                    <FormControlLabel class="checkStatus3"
                      value={"Available"} 
                      control={<Radio />}
                      label="Available"
                    />
                    <FormControlLabel class="checkStatus6"
                      value={"Not Available"}
                      control={<Radio />}
                      label="Not Available"
                    />

                </RadioGroup>
              </div>
            </Form.Group>
            <Button
              type="primary" danger
              size={"large"}
              onClick={handleOnSubmit}
               disabled={submitDisabled}>
              Save
            </Button>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Link to="/asset-list" style={{ textDecoration: "none" }}>
        <Button type="primary" 
           size={"large"}>
              Cancel
            </Button>
        </Link>

            
          </Form>
        </Box>
      </div>
      <Popup2
        title="Add Category"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <Form >
          <div>
            <h5>Category Name:</h5>
          </div>
          <Input
          inputProps={{ maxLength: 255 }}
            type="text"
            onChange={handleChangeCate}
            value={newCategory.categoryName}
            name="categoryName"
            required
            style={{ width: 200 }}
          />

          <div>
            <h5>Prefix:</h5>
          </div>
          <Input
          inputProps={{ maxLength: 50 }}
            type="text"
            onChange={handleChangeCate}
            value={newCategory.perfix}
            name="perfix"
            required
            style={{ width: 200 }}
          />

          <div style={{ color: "red" }}>{mess}</div>
          <br />
          <Button
           type="primary" danger
           size={"large"}
            onClick={addCategory}
          >
            Save
          </Button>
        </Form>
      </Popup2>
    </div>
  );
};

export default CreateAsset;
