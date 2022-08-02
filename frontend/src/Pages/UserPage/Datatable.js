import React, { useEffect, useState } from "react";
import axios from "axios";
import { makeStyles } from "@mui/styles";
import { Link, useNavigate } from "react-router-dom";
import {Button} from "antd";
import { DataGrid } from "@mui/x-data-grid";
import ClearIcon from '@mui/icons-material/Clear';

import ModeEditOutlineTwoToneIcon from "@mui/icons-material/ModeEditOutlineTwoTone";
import "bootstrap/dist/css/bootstrap.min.css";
import SearchIcon from "@mui/icons-material/Search";
import {
  TextField,
  InputAdornment,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from "@mui/material";
import { message } from "antd";
import Popup2 from "../../Components/Modal/Popup2";
import Custompagination from "../../Components/Pagination/CustomPagination";
import CustomNoRowsOverlay from "../../Components/NoRowsOverlay/CustomNoRowsOverlay";
import moment from "moment";
const styles = makeStyles({
  table: {
    width: "cover",
    margin: "25px 50px 0 50px",
  },
  filterBar: {
    width: 220,
  },
  filterContainer: {
    display: "flex",
    justifyContent: "space-around",
  },
  cancelBtn: {
    marginLeft: "1rem",
  },
});

const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState("");
  const [selectionModel, setSelectionModel] = useState([]);
  const token = localStorage.getItem("token");
  const [openPopup, setOpenPopup] = useState(false);
  const [selectedItem, setSelectedItem] = useState(null);
  const [userType, setUserType] = useState("all");
  const userId = localStorage.getItem("userId");
  const navigate = useNavigate();
  useEffect(() => {
    loadData();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  const loadData = async () => {
    setLoading(true);
    const response = await axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Users/GetAllActive?userId=${userId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    setGridData(
      response.data.map(({ ...item }) => ({
        ...item,
        key: item.userId,
        joinedDate: moment(item.joinedDate).format("DD/MM/YYYY"),
      }))
    );
    setLoading(false);
  };

  const modifiedData = gridData.filter((item) => {
    return userType !== "all"
      ? item.role === userType &&
          (item.userName.includes(searchText) ||
            item.staffCode.includes(searchText) || item.fullName.includes(searchText))
      : item.userName.includes(searchText) ||
          item.staffCode.includes(searchText) || item.fullName.includes(searchText);
  });

  const handleDelete = async (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.filter((item) => item.userId !== value.id);

    await setGridData(filteredData);

    await axios({
      method: "PUT",
      url: `${process.env.REACT_APP_Backend_URI}/Users/disable?id=${value.id}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    })
      .then(
        function (response) {
          message.success("Successfully");
        },
        (error) => {
          if (error?.response.status === 400) {
            message.error(error.response.data.message);
          }
        }
      )
      .catch(function (error) {
        console.log(error);
        message.error("Disable fail!");
        setGridData(modifiedData);
      });
  };

  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "userId",
    },
    {
      headerName: "StaffCode",
      field: "staffCode",
      width: 150,
      disableColumnMenu: true,
    },
    {
      headerName: "Full Name",
      field: "fullName",
      width: 300,
    },
    {
      headerName: "User Name",
      field: "userName",
      width: 250,
    },
    {
      headerName: "Join Date",
      field: "joinedDate",
      width: 200,
    },
    {
      headerName: "Type",
      field: "role",
      width: 150,
    },
    {
      headerName: "Actions",
      field: "actions",
      width: 150,
      sortable: false,
      disableColumnMenu: true,
      renderCell: (item) => {
        return (
          <div>
            <Button

            shape="round" size={"large"}
              onClick={(event) => {
                navigate(`/user-list/edit${item.id}`);
                event.stopPropagation();
              }}
            >
              <ModeEditOutlineTwoToneIcon  />
            </Button>
            &nbsp;&nbsp;
            <Button
             shape="round" size={"large"}
              color="error"
              onClick={(event) => {
                setOpenPopup(true);
                setSelectedItem(item);
                event.stopPropagation();
              }}
            >
              <ClearIcon   />
            </Button>
          </div>
        );
      },
    }
  ];

  const handleSearch = (e) => {
    setSearchText(e.target.value);
  };
  return (
    <div>
      <div className={classes.filterContainer}>
        <FormControl className={classes.filterBar} size="small">
          <InputLabel id="demo-simple-select-label">Type</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={userType}
            label="userType"
            onChange={(e) => setUserType(e.target.value)}
          >
            <MenuItem value={"all"}>
              <em>Default</em>
            </MenuItem>
            <MenuItem value={"Admin"}>Admin</MenuItem>
            <MenuItem value={"Staff"}>Staff</MenuItem>
          </Select>
        </FormControl>
        <TextField
          inputProps={{ maxLength: 255 }}
          id="outlined-basic"
          variant="outlined"
          label="Search"
          onChange={handleSearch}
          value={searchText}
          size="small"
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
        />{" "}
        <Link to="./create" style={{ textDecoration: "none" }}>
          <Button type="primary" danger
         shape="round" size={"large"}>
            Create new user
          </Button>
        </Link>
      </div>

      <div className={classes.table}>
        <DataGrid
          sortingOrder={["desc", "asc"]}
          pagination
          autoHeight
          {...modifiedData}
          columns={columns}
          rows={modifiedData}
          pageSize={10}
          rowsPerPageOptions={[10]}
          loading={loading}
          components={{
            Pagination: Custompagination,
            NoRowsOverlay: CustomNoRowsOverlay,
          }}
          getRowId={(row) => row.userId}
          onSelectionModelChange={(newSelectionModel) => {
            setSelectionModel(newSelectionModel);
            navigate(`/user-list/${newSelectionModel}`);
          }}
          selectionModel={selectionModel}
        />
      </div>
      <Popup2
        title="Are you sure?"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div>
          <p>Do you want to disable this user?</p>
        </div>
     
        <Button
         type="primary" danger
         size={"large"}
          onClick={() => {
            setOpenPopup(false);
            setGridData();
            setSelectedItem(null);
            handleDelete(selectedItem);
          }}
        >
          Disable
        </Button>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
        <Button
          type="primary" 
          size={"large"}
          onClick={() => {
            setOpenPopup(false);
          }}
          className={classes.cancelBtn}
        >
          Cancel
        </Button>
      </Popup2>
    </div>
  );
};

export default Datatable;
