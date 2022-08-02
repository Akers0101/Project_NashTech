import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import { makeStyles } from "@mui/styles";
import {Button} from "antd";
import "./Csses/createAsset.css"
import SearchIcon from "@mui/icons-material/Search";
import {
  TextField,
  InputAdornment,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from "@mui/material";
import {
  DataGrid,
} from "@mui/x-data-grid";
import ClearIcon from '@mui/icons-material/Clear';
import ModeEditOutlineTwoToneIcon from "@mui/icons-material/ModeEditOutlineTwoTone";
import Popup from "../../Components/Modal/Popup";
import { useNavigate } from "react-router-dom";
import { message } from "antd";
import Custompagination from "../../Components/Pagination/CustomPagination";
import CustomNoRowsOverlay from "../../Components/NoRowsOverlay/CustomNoRowsOverlay";
import PopupForError from "../../Components/Modal/PopupForError";

const styles = makeStyles({
  table: {
    width: "cover",
    margin: "25px 50px 0 50px",
  },
  filterContainer: {
    display: "flex",
    justifyContent: "space-around",
  },
  searchBar: {
    width: 300,
  },
  filterBar: {
    width: 220,
  },
});


const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState([]);
  const [openPopup, setOpenPopup] = useState(false);
  const [selectedItem, setSelectedItem] = useState({ row: {} });
  const [selectionModel, setSelectionModel] = useState([]);
  const [assetState, setAssetState] = useState("all");
  const [categoryName, setCategoryName] = useState("all");
  const [categories, setCategories] = useState([]);
  const [openErrorPopup, setOpenErrorPopup] = useState(false);
  // const [openPopupFail,setOpenPopupFail]= useState(false);
  const token = localStorage.getItem("token");
  const userId = localStorage.getItem("userId");
  useEffect(() => {
    loadData();
    loadCategory();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  const navigate = useNavigate();
  const loadCategory = async () => {
    const response = await axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Category/all`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    setCategories([...new Set(response.data.map((a) => a.categoryName))]);
  };

  const loadData = async () => {
    setLoading(true);
    const response = await axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/all?userId=${userId}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    setGridData(response.data);
    setLoading(false);
  };

  const modifiedData = gridData
    .filter((item) => {
      return assetState !== "all" || categoryName !== "all"
        ? (item.assetState === assetState ||
          item.categoryName === categoryName) &&
        (item.assetName.includes(searchText) ||
          item.assetCode.includes(searchText))
        : item.assetName.includes(searchText) ||
        item.assetCode.includes(searchText);
    })
    .map(({ ...item }) => ({
      ...item,
      key: item.assetId,
    }));

  const handleDelete = async (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.filter((item) => item.assetId !== value.id);

    await setGridData(filteredData);
    await axios({
      method: "DELETE",
      url: `${process.env.REACT_APP_Backend_URI}/Asset/delete?assetId=${value.id}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    })
      .then(
        (response) => {
          message.success("Successfully");
        },

        (error) => {
          if (error?.response.status === 400) {
            setOpenErrorPopup(true);

           
          }
        }
      )
      .catch((error) => {
        console.log(error);
        setOpenErrorPopup(true);

      });
  };

  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "assetId",
      width: 100,
      disableColumnMenu: true,
    },
    {
      headerName: "Asset Code",
      field: "assetCode",
      width: 250,
    },
    {
      headerName: "Asset Name",
      field: "assetName",
      width: 250,
    },
    {
      headerName: "Category",
      field: "categoryName",
      width: 350,
    },
    {
      headerName: "State",
      field: "assetState",
      width: 200,
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
              disabled={item.row.assetState === "Assigned" ? true : false}
              shape="round" size={"large"}
              onClick={(event) => {
                navigate(`/asset-list/edit${item.id}`);
                event.stopPropagation();
              }}
            >
              <ModeEditOutlineTwoToneIcon />
            </Button>
            &nbsp;&nbsp;
            <Button
               shape="round" size={"large"}
             
              disabled={item.row.assetState === "Assigned" ? true : false}
              onClick={(event) => {
                
                  setOpenPopup(true);
                  setSelectedItem(item);
                  event.stopPropagation();
                
              }}
            >
              <ClearIcon  />
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
          <InputLabel id="demo-simple-select-label">Asset State</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={assetState}
            label="assetState"
            onChange={(e) => setAssetState(e.target.value)}
          >
            <MenuItem value={"all"}>
              <em>Default</em>
            </MenuItem>
            <MenuItem value={"Available"}>Available</MenuItem>
            <MenuItem value={"Not Available"}>Not Available</MenuItem>
            <MenuItem value={"Assigned"}>Assigned</MenuItem>
          </Select>
        </FormControl>
        <FormControl className={classes.filterBar} size="small">
          <InputLabel id="demo-simple-select-label">Category</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={categoryName}
            label="categoryName"
            onChange={(e) => setCategoryName(e.target.value)}
          >
            <MenuItem value={"all"}>
              <em>Default</em>
            </MenuItem>
            {categories.map((categoryName, index) => (
              <MenuItem key={index} value={categoryName}>
                {categoryName}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
          className={classes.searchBar}
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
        <Link to="./create" style={{ textDecoration: "none" }}>
          <Button
          type="primary" danger
           size={"large"} shape="round">
            Create new asset
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
          getRowId={(row) => row.assetId}
          onSelectionModelChange={(newSelectionModel) => {
            setSelectionModel(newSelectionModel);
            navigate(`./${newSelectionModel}`);
          }}
          selectionModel={selectionModel}
        />
      </div>

      <Popup
        title="Are you sure?"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div className="messageDelete">
          <p>Do you want to delete this asset ?</p>
        </div>
        <Button
         type="primary" danger
         size={"large"}
         
          onClick={() => {
            setOpenPopup(false);
            setGridData();
            
            handleDelete(selectedItem);
          }}
        >
          Yes
        </Button>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
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
      <PopupForError
        title="Cannot delete asset"
        openErrorPopup={openErrorPopup}
        setOpenErrorPopup={setOpenErrorPopup}
      >
        <div>
          <p>Cannot delete the asset because it belongs to one or more historical assignments.
            If the asset is not able to be used anymore, please update its state in <Link to={`/asset-list/edit${selectedItem.row.assetId}`}> Edit Asset page</Link></p>

        </div>
      </PopupForError>
    </div>
  );
};

export default Datatable;
