import React, {  useState } from "react";

import { makeStyles, styled } from "@mui/styles";
import {
  DataGrid,
  gridPageCountSelector,
  gridPageSelector,
  useGridApiContext,
  useGridSelector,
} from "@mui/x-data-grid";
import CloseIcon from '@mui/icons-material/Close';
import Pagination from "@mui/material/Pagination";
import "bootstrap/dist/css/bootstrap.min.css";
import { Button } from "react-bootstrap";
import SearchIcon from "@mui/icons-material/Search";
import { TextField, InputAdornment, Box,Radio,  Dialog, DialogTitle, DialogContent, Typography } from "@mui/material";
import ActionButton from"../../../Components/ActionButton/ActionButton";
function CustomPagination() {
  const apiRef = useGridApiContext();
  const page = useGridSelector(apiRef, gridPageSelector);
  const pageCount = useGridSelector(apiRef, gridPageCountSelector);

  return (
    <Pagination
      color="error"
      count={pageCount}
      page={page + 1}
      onChange={(event, value) => apiRef.current.setPage(value - 1)}
    />
  );
}
const useStyles1 = makeStyles(theme => ({
  dialogWrapper: {
      padding: theme.spacing(2),
      // position: 'absolute',
      top: theme.spacing(5)
  },
  dialogTitle: {
      paddingRight: '0px'
  }
}));
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
    paddingleft: "20px",
  },
  
});

const StyledGridOverlay = styled("div")(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  justifyContent: "center",
  height: "100%",
  "& .ant-empty-img-1": {
    fill: theme.palette.mode === "light" ? "#aeb8c2" : "#262626",
  },
  "& .ant-empty-img-2": {
    fill: theme.palette.mode === "light" ? "#f5f5f7" : "#595959",
  },
  "& .ant-empty-img-3": {
    fill: theme.palette.mode === "light" ? "#dce0e6" : "#434343",
  },
  "& .ant-empty-img-4": {
    fill: theme.palette.mode === "light" ? "#fff" : "#1c1c1c",
  },
  "& .ant-empty-img-5": {
    fillOpacity: theme.palette.mode === "light" ? "0.8" : "0.08",
    fill: theme.palette.mode === "light" ? "#f5f5f5" : "#fff",
  },
}));

function CustomNoRowsOverlay() {
  return (
    <StyledGridOverlay>
      <svg
        width="60"
        height="50"
        viewBox="0 0 184 152"
        aria-hidden
        focusable="false"
      >
        <g fill="none" fillRule="evenodd">
          <g transform="translate(24 31.67)">
            <ellipse
              className="ant-empty-img-5"
              cx="67.797"
              cy="106.89"
              rx="67.797"
              ry="12.668"
            />
            <path
              className="ant-empty-img-1"
              d="M122.034 69.674L98.109 40.229c-1.148-1.386-2.826-2.225-4.593-2.225h-51.44c-1.766 0-3.444.839-4.592 2.225L13.56 69.674v15.383h108.475V69.674z"
            />
            <path
              className="ant-empty-img-2"
              d="M33.83 0h67.933a4 4 0 0 1 4 4v93.344a4 4 0 0 1-4 4H33.83a4 4 0 0 1-4-4V4a4 4 0 0 1 4-4z"
            />
            <path
              className="ant-empty-img-3"
              d="M42.678 9.953h50.237a2 2 0 0 1 2 2V36.91a2 2 0 0 1-2 2H42.678a2 2 0 0 1-2-2V11.953a2 2 0 0 1 2-2zM42.94 49.767h49.713a2.262 2.262 0 1 1 0 4.524H42.94a2.262 2.262 0 0 1 0-4.524zM42.94 61.53h49.713a2.262 2.262 0 1 1 0 4.525H42.94a2.262 2.262 0 0 1 0-4.525zM121.813 105.032c-.775 3.071-3.497 5.36-6.735 5.36H20.515c-3.238 0-5.96-2.29-6.734-5.36a7.309 7.309 0 0 1-.222-1.79V69.675h26.318c2.907 0 5.25 2.448 5.25 5.42v.04c0 2.971 2.37 5.37 5.277 5.37h34.785c2.907 0 5.277-2.421 5.277-5.393V75.1c0-2.972 2.343-5.426 5.25-5.426h26.318v33.569c0 .617-.077 1.216-.221 1.789z"
            />
          </g>
          <path
            className="ant-empty-img-3"
            d="M149.121 33.292l-6.83 2.65a1 1 0 0 1-1.317-1.23l1.937-6.207c-2.589-2.944-4.109-6.534-4.109-10.408C138.802 8.102 148.92 0 161.402 0 173.881 0 184 8.102 184 18.097c0 9.995-10.118 18.097-22.599 18.097-4.528 0-8.744-1.066-12.28-2.902z"
          />
          <g className="ant-empty-img-4" transform="translate(149.65 15.383)">
            <ellipse cx="20.654" cy="3.167" rx="2.849" ry="2.815" />
            <path d="M5.698 5.63H0L2.898.704zM9.259.704h4.985V5.63H9.259z" />
          </g>
        </g>
      </svg>
      <Box sx={{ mt: 1 }}>No Result Found</Box>
    </StyledGridOverlay>
  );
}
function ListUser(props) {
 

  const [searchText, setSearchText] = useState("");
  const { loading ,gridData, openPopup, setOpenPopup, selectedValue, assignment } = props;
const [userResponse,setUserResponse] = useState({
  touserId: "",
  username:""
});

  
 
  
 
  const modifiedData = gridData
    .filter((item) => {
      return ((
        item.fullName.includes(searchText) ||
        item.staffCode.includes(searchText))  
      );
    })
    .map((item) => ({
      ...item,
      key: item.userId,
    }));
    const handleChooseUser = (item) => {
      
      setUserResponse({
        ...userResponse,
        touserId: item.id,
          username: item.row.userName
      });
     
     

  }

  const handleShow = () => {
    
    selectedValue({
      ...assignment,
      assetId: assignment.assetId,
      assignedByUserId:assignment.assignedByUserId,
      assignedToUserId:userResponse.touserId,
      assetName: assignment.assetName,
      assignedDate: assignment.assignedDate,
      note: assignment.note,
      assignedToUserName: userResponse.username
  });
  setOpenPopup(false);
   
}
    const classes1 = useStyles1();
  const classes = styles();
  const columns = [
    {
      field: 'radio',
      headerName: ' ',
      width: 40,
      sortable: false,
      disableColumnMenu: true,
      renderCell: (item) => {
        return (
          <Radio 
          key={item.userId}
          checked={ userResponse.touserId === item.id } 
          onClick={() =>handleChooseUser(item)}
          />
         )
      }
    },
    {
      headerName: "StaffCode",
      field: "staffCode",
      width: 100,
      disableColumnMenu: true,
    },
    {
      headerName: "Full Name",
      field: "fullName",
      width: 150,
    },
    {
      headerName: "Type",
      field: "role",
      width: 100,
    },
  ];

  const handleSearch = (e) => {
    setSearchText(e.target.value);
  };
  
 
    
  return (
<Dialog    open={openPopup} maxWidth="md" classes={{ paper: classes1.dialogWrapper }}>
            <DialogTitle className={classes1.dialogTitle}>
                <div style={{ display: 'flex' }}>
                    <Typography variant="h6" component="div" style={{ flexGrow: 1 , color: '#cf2338'}}>
                        List User
                    </Typography>
                    <ActionButton
                        color="secondary"
                        onClick={()=>{
                            setOpenPopup(false);
                           
                            }}>
                        <CloseIcon />
                    </ActionButton>
                </div>
            </DialogTitle>
            <DialogContent dividers>
    <div style={{ width: 520 }}>
      
      <div className={classes.filterContainer}>
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
      </div>

      <div className={classes.table}>
        <DataGrid
         sortingOrder={['desc', 'asc']}
          pagination
          autoHeight
          {...modifiedData}
          disableSelectionOnClick 
          columns={columns}
          rows={modifiedData}
          pageSize={5}
          rowsPerPageOptions={[100]}
          loading={loading}
          components={{
            Pagination: CustomPagination,
            NoRowsOverlay: CustomNoRowsOverlay,
          }}
          getRowId={(row) => row.userId}
         
        />
      </div>
      
      <br/>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Button onClick={handleShow}  variant="danger" type="submit" >
          Save
        </Button>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <Button onClick={()=> setOpenPopup(false)}  variant="outline-secondary">
          Cancel
        </Button>
    </div>
    </DialogContent>
    </Dialog>
  );
};

export default ListUser;
