import { Form } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Csses/createAsset.css"
import { Link, useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import { Box, Radio, RadioGroup, FormControlLabel } from "@mui/material";
import {message} from "antd";
import {Button} from "antd";
const EditAsset = () => {
 
  const token = localStorage.getItem("token");
  const [categories, setCategories] = useState([]);
  const [submitDisabled, setSubmitDisabled] = useState(true);

  const [updateAsset, setUpdateAsset] = useState({
    assetName: "",
    categoryId: "",
     specification: "",
    assetState: "",
    installedDate:""
  });

  const navigate = useNavigate();
  const [imess, setIMess] = useState();


  const handleChange = (evt) => {
    const getUpdateAsset={
      ...updateAsset,
      [evt.target.name]: evt.target.value,
    }
    setUpdateAsset(getUpdateAsset);
    setSubmitDisabled(Object.values(getUpdateAsset).some((x) => x === "" || x === null))
  };
 

 const handleChangeCategory = (e) => {
  setUpdateAsset({
      ...updateAsset,
      categoryId: e.target.value
  });
  
}
 const { id } = useParams();
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_Backend_URI}/Category/all`)
      .then(function (response) {
        setCategories(response.data);
      }, [])
      .catch((error) => {
        console.log(error);
      });
  }, []);
  useEffect(() => {
    axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
    }})
   
      .then(function (response) {
        const resData =response.data;
        
      setUpdateAsset({...resData,installedDate:new Date(resData.installedDate).toLocaleDateString('en-CA')});
      }, [])
      .catch((error) => {
        console.log(error);
      });
  // eslint-disable-next-line react-hooks/exhaustive-deps
  },[]);


  const handleOnSubmit = (evt) => {
    evt.preventDefault();
  setSubmitDisabled(true);
    axios({
      method: "PUT",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/update?id=${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
    },

     data: updateAsset

    })
      .then(function (response) {
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
        setIMess(error.response.data.message);
       
      });
  };
  useEffect(() => {
    const today = new Date();
    const date= new Date(updateAsset.installedDate);
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
  },[updateAsset.installedDate])
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
          <p >Edit Asset Page</p>
          </div>
          <br />
          <Form >
            <Form.Group className="mb-3" controlId="formBasicTitle1">
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
                  value={updateAsset.assetName}
                  name="assetName"
                  required
                  class="form-control"
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
                <Form.Select
                className ="btn-category1"
                  required
                  disabled
                  name="categoryId"  onChange={handleChangeCategory} value={updateAsset.categoryId}
                >
                  <option selected>Select Category</option>
                  {categories.map((item) => (
                    <option
                    value={item.categoryId}
                    >
                      {item.categoryName}
                    </option>
                    
                   ))}
                </Form.Select>
                <div class="input-group-append">
                </div>
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle1">
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
                  value={updateAsset.specification}
                  name="specification"
                  required
                  class="textbox-specification"
                />
              </div>
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle1">
              <div class="input-group mb-3">
                <div class="text-DOB">
                  <span class="input-group" id="inputGroup-sizing-default">
                    Installed Date<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                  <input
                  type="date"
                  onChange={handleChange}
                  value={updateAsset.installedDate}
                  name="installedDate"
                  required
                  class="form-control"
                  min="1980-01-01" max="2099-12-31"
                />
              </div>
              <div style={{ color: 'red' }}>{imess}</div> 
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicTitle1">
              <div class="input-group mb-3">
                <div>
                  <span class="input-group" id="inputGroup-sizing-default">
                    Asset State<p style={{ color:"#f83245"}}>*</p>
                  </span>
                </div>
                <RadioGroup
                  aria-labelledby="demo-controlled-radio-buttons-group"
                  name="assetState"
                  value={updateAsset.assetState}
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
                    <FormControlLabel class="checkStatus5"
                    value={"Waiting For Recycling"}
                    control={<Radio />}
                    label="Waiting For Recycling"
                  />
                  <FormControlLabel class="checkStatus3"
                    value={"Recycled"}
                    control={<Radio />}
                    label="Recycled"
                  />
                </RadioGroup>
              </div>
            </Form.Group>
            <Button type="primary" danger
           size={"large"}
           onClick={handleOnSubmit}
           disabled={submitDisabled}>
              Save
            </Button>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
      
    </div>
   
  );
};

export default EditAsset;
