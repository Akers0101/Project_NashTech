import React, { useEffect, useState } from "react";
import axios from "axios";
import { makeStyles } from "@mui/styles";
import {Button} from "antd";
import { Link, useNavigate } from "react-router-dom";
import TextField from "@mui/material/TextField";
import { DataGrid } from "@mui/x-data-grid";
import Popup from "../../Components/Modal/Popup";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import Custompagination from "../../Components/Pagination/CustomPagination";
import { FormControl, InputAdornment, InputLabel, MenuItem, Select } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import ModeEditOutlineTwoToneIcon from "@mui/icons-material/ModeEditOutlineTwoTone";
import CustomNoRowsOverlay from "../../Components/NoRowsOverlay/CustomNoRowsOverlay";
import moment from "moment"
const styles = makeStyles({
  table: {
    // boxShadow: "2px 2px 5px -1px rgba(0,0,0,0.75)",
    width: "cover",
    margin: "25px 50px 0 50px",
  },
  filterBar: {
    width: 300,
  },
  filterContainer: {
    display: "flex",
    justifyContent: "space-around",
  },
});
const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState("");
  const [openPopup, setOpenPopup] = useState(false);
  const [selectedItem, setSelectedItem] = useState({row:{}});
  const token = localStorage.getItem("token");
  const userId = localStorage.getItem("userId");
  const [, setSelectionModel] = useState([]);
  const [assignmentState, setAssignmentState] = useState("all");

  const navigate = useNavigate();

  useEffect(() => {
    loadData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const loadData = async () => {
    setLoading(true);
    const response = await axios.get(
      `${process.env.REACT_APP_Backend_URI}/Assignment/get-by-location?userId=${userId}`,
      {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      }
    );
    setGridData(response.data);
    setLoading(false);
  };

  const modifiedData = gridData
    .filter((item) => {
      return assignmentState !== "all"
      ? item.assignmentState === assignmentState &&
      (item.assetName.includes(searchText) ||
        item.assignedToUserName.includes(searchText) || item.assetCode.includes(searchText))
        : (item.assetName.includes(searchText) ||
            item.assignedToUserName.includes(searchText) || item.assetCode.includes(searchText));
    })
    .map(({ ...item }) => ({
      ...item,
      key: item.assetCode,
      assignedDate : moment(item.assignedDate).format('DD/MM/YYYY')
    }));


    const toggleChangeStatus = async (value) => {
      const dataSource = [...gridData];
      const filteredData = dataSource.map((item) => {
        if (item.assignmentId === value.id) {
          return {
            ...item,
            // isDisable: !item.isDisable,
            assignmentState: "Returned",
          };
        }
        return item;
      });
      await setGridData(filteredData);

      await axios({
        method: "PUT",
        url: `${process.env.REACT_APP_Backend_URI}/Assignment/complete?assignmetnId=${value.id}`,
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      });
    };

  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "assignmentId",
    },
    {
      headerName: "Asset Code",
      field: "assetCode",
      width: 150,
    },
    {
      headerName: "Asset Name",
      field: "assetName",
      width: 160,
    },
    {
      headerName: "Assigned To",
      field: "assignedToUserName",
      width: 160,
    },
    {
      headerName: "Assigned By",
      field: "assignedByUserName",
      width: 200,
    },
    {
      headerName: "Assigned Date",
      field: "assignedDate",
      width: 170,
    },
    {
      headerName: "State",
      field: "assignmentState",
      width: 230,
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
              disabled={item.row.assignmentState === "Waiting For Acceptance" ? false : true}
              shape="round" size={"large"}
              onClick={(event) => {
                navigate(`/assignment-list/edit${item.id}`);
                event.stopPropagation();
              }}
            >
              <ModeEditOutlineTwoToneIcon />
            </Button>
            &nbsp;&nbsp;
            <Button
              disabled={item.row.assignmentState === ("Accepted")?false:true}
              shape="round" size={"large"}
              color="secondary"
              onClick={(event) => {
                setOpenPopup(true);
                setSelectedItem(item);
                event.stopPropagation();
              }}
            >
              <DoneAllIcon   />
            </Button>
          </div>
        );
      },
    },
  ];

  const handleSearch = (e) => {
    setSearchText(e.target.value);
  };
  return (
    <div>
      <div className={classes.filterContainer}>
        <FormControl className={classes.filterBar} size="small">
          <InputLabel id="state-select-label">Assignment State</InputLabel>
          <Select
            labelId="state-select-label"
            value={assignmentState}
            label="assignmentState"
            onChange={(e) => setAssignmentState(e.target.value)}
          >
            <MenuItem value={"all"}>
              <em>Default</em>
            </MenuItem>
            <MenuItem value={"Accepted"}>Accepted</MenuItem>
            <MenuItem value={"Waiting For Acceptance"}> Waiting For Acceptance </MenuItem>
            <MenuItem value={"Rejected"}> Rejected </MenuItem>
            <MenuItem value={"Returned"}>Returned</MenuItem>
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
        />
         <Link to="./create" style={{textDecoration:"none"}}>
          <Button
         type="primary" danger
         shape="round" size={"large"}
        >
          Create new assignment
        </Button>
        </Link>
      </div>

      <div className={classes.table}>
        <DataGrid
         sortingOrder={['desc', 'asc']}
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
          getRowId={(row) => row.assignmentId}
          onSelectionModelChange={(newSelectionModel) => {
            setSelectionModel(newSelectionModel);
            navigate(`/assignment/${newSelectionModel}`);
          }}
        />
      </div>

      <Popup
        title="Are you sure?"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div>
          <p>Do you want to mark this returning request as "Returned" ?</p>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Button
           type="primary" danger
           size={"large"}
          onClick={() => {
            setOpenPopup(false);
            setGridData();
            setSelectedItem(null);
            toggleChangeStatus(selectedItem);
          }}
        >
          Yes
        </Button>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Button
          type="primary" 
          size={"large"}
          onClick={() => {
            setOpenPopup(false);
          }}
        >
          No
        </Button>
      </Popup>
    </div>
  );
};

export default Datatable;
